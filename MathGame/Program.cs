namespace MathGame;

class Program
{

    static char[] mathSigns = [
        '+', '-', '*'
    ];

    static List<int> scores = new List<int>();

    static void Main(string[] args)
    {
        ShowMainMenu();
    }

    class Question
    {

        int a, b;
        char op;

        int result;

        public bool? Solved { get; set; }

        public Question(int a, int b, char op)
        {
            this.a = a;
            this.b = b;
            this.op = op;
            Solved = null;

            switch (op)
            {
                case '+':
                    result = a + b;
                    break;
                case '-':
                    result = a - b;
                    break;
                case '*':
                    result = a * b;
                    break;
                case '/':
                    result = a / b;
                    break;
            }
        }

        public int GetResult() => result;

        public string GetQuestionString() => $"{a} {op} {b}";
    }

    static void ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine("****************** Math Game ******************");
        Console.WriteLine("Games played: {0}", scores.Count);

        Console.WriteLine();

        Console.WriteLine("Main Menu");
        Console.WriteLine("1. Play Round");
        Console.WriteLine("2. History");
        Console.WriteLine("3. Quit");

        Console.Write("Selection: ");
        int decision = 0;
        try
        {
            decision = int.Parse(Console.ReadLine());

        }
        catch (FormatException)
        {

        }
        switch (decision)
        {
            case 1:
                PlayRound();
                break;
            case 2:
                ViewHistory();
                break;
            case 3:
                Environment.Exit(0);
                break;
            default:
                ShowMainMenu();
                break;
        }
    }

    static void PlayRound()
    {

        Random rand = new Random();
        List<Question> questions = new List<Question>();
        int score = 0;
        for (int i = 0; i < 5; i++)
        {

            int a = rand.Next(1, 50);
            int b = rand.Next(1, 50);
            int signInt = rand.Next(0, 3);
            Console.WriteLine(signInt);
            char sign = mathSigns[signInt];

            questions.Add(new Question(a, b, sign));
        }

        for (int i = 0; i < questions.Count; i++)
        {
            Console.Clear();
            Console.WriteLine("****************** In Round ******************");
            Console.WriteLine($"Question {i}/5 \t Score: {score}\n");
            Console.WriteLine(questions[i].GetQuestionString());
            Console.WriteLine("Enter Solution below:");
            int solution = 0;
            solution = int.Parse(Console.ReadLine());


            if (solution == questions[i].GetResult())
                score++;
        }

        scores.Add(score);
        ShowMainMenu();

    }

    static void ViewHistory()
    {
        Console.Clear();
        Console.WriteLine("****************** Game History ******************");
        for (int i = 0; i < scores.Count; i++)
        {
            Console.WriteLine($"Game {i + 1}: {scores[i]}");
        }
        Console.WriteLine("Press any key to return to main menu");
        Console.ReadKey();
        ShowMainMenu();
    }
}
