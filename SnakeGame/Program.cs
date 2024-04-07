using SnakeGame;

class Program
{
    private const int SizeX = 20;
    private const int SizeY = 50;

    private static Frame _frame;
    private static Snake _snake;
    private static Dot _dot;

    static async Task Main(string[] args)
    {
        //Team1 starts
        Init();
        Task conductSnakeTask = Task.Run(() => GuideSnake());
        Task executeGameProcessTask = Task.Run(() => ExecuteGameProcess());

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
        var key = Console.ReadKey(true);
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
        while (true)
        {
            DoAct();
            Thread.Sleep(1000);
        }

        return Task.CompletedTask;
    }

    private static void DoAct()
    {
        _snake.Move();
        _snake.TryEatDot(_dot);
        _frame.SetSnake(_snake);
        _frame.SetDot(_dot);
        _frame.Clear();
        _frame.Display();
    }
}