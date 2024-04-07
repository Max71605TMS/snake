using SnakeGame;

internal class Program
{
    private const int SizeX = 20;
    private const int SizeY = 50;

    private static Frame _frame;
    private static Snake _snake;
    private static Dot _dot;

    private static async Task Main(string[] args)
    {
        //Team1 starts
        Init();
        var conductSnakeTask = Task.Run(() => GuideSnake());
        var executeGameProcessTask = Task.Run(() => ExecuteGameProcess());

        Task.WaitAll(conductSnakeTask, executeGameProcessTask);
    }

    private static void Init()
    {
        _snake = new Snake(SizeX, SizeY);

        _dot = new Dot(SizeX, SizeY);
        _dot.Generate(_snake);

        _frame = new Frame(SizeX, SizeY);
        _frame.SetDot(_dot);
        _frame.SetSnake(_snake);

        _frame.Display();

        Console.WriteLine("Welcome to Snake game, Press Any key to start");
        Console.ReadKey(true);
    }

    private static Task GuideSnake()
    {
        while (_snake.IsAlive)
        {
            Direction nextDirection;

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    nextDirection = Direction.UP;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    nextDirection = Direction.DOWN;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    nextDirection = Direction.LEFT;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    nextDirection = Direction.RIGHT;
                    break;
                default:
                    continue;
            }

            _snake.Direction = nextDirection;
        }

        return Task.CompletedTask;
    }

    private static Task ExecuteGameProcess()
    {
        var score = 0;
        const int winScore = (SizeX - 2) * (SizeY - 2) - 1 - 2;

        while (_snake.IsAlive)
        {
            DoAct();
            score = _snake.Length;

            DisplayScore(score);

            if (_frame.CountDots() == _snake.Length + 2 && score == winScore) break;
            Thread.Sleep(1000);
        }

        if (_snake.IsAlive && score == winScore)
        {
            DisplayWin();
            return Task.CompletedTask;
        }

        DisplayLoos();
        return Task.CompletedTask;
    }

    private static void DisplayScore(int score)
    {
        Console.WriteLine($"Общий счет: {score}");
    }

    private static void DisplayWin()
    {
        Console.WriteLine("Вы выиграли!");
    }

    private static void DisplayLoos()
    {
        Console.WriteLine("Вы проиграли! Ваша змея умерла!");
    }

    private static void DoAct()
    {
        _snake.Move();
        _snake.TryEatDot(_dot);
        _frame.Clear();
        _frame.SetSnake(_snake);
        _frame.SetDot(_dot);
        _frame.Display();
    }
}