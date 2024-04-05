using SnakeGame;
using System.Diagnostics;
using System.Xml.Linq;

class Program
{
    private const int SizeX = 50;
    private const int SizeY = 20;
    private const int SnakeLength = 3;
    private const int TimeUpdate = 500;

    static async Task Main(string[] args)
    {
        //team2
        Init(out Snake snake, out Frame frame, out Dot dot);
        Task conductSnakeTask = Task.Run(() => GuideSnake(snake));
        Task executeGameProcessTask = Task.Run(() => ExecuteGameProcess(frame, dot, snake));

        Task.WaitAll(conductSnakeTask, executeGameProcessTask);
    }

    private static void Init(out Snake snake, out Frame frame, out Dot dot)
    {
        Console.CursorVisible = false;
        frame = new Frame(SizeX, SizeY);
        snake = new Snake(SizeX, SizeY, SnakeLength);
        dot = new Dot(SizeX, SizeY);
        dot.Generate(snake);

        Console.WriteLine("Welcome to Snake game, Press Any key to start");
        var key = Console.ReadKey(true);
    }

    private static Task GuideSnake(Snake snake)
    {
        while (snake.IsAlive)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    snake.Direction = snake.Direction != Direction.RIGHT ? Direction.LEFT : snake.Direction;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    snake.Direction = snake.Direction != Direction.LEFT ? Direction.RIGHT : snake.Direction;
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    snake.Direction = snake.Direction != Direction.DOWN ? Direction.UP : snake.Direction;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    snake.Direction = snake.Direction != Direction.UP ? Direction.DOWN : snake.Direction;
                    break;
            }
        }

        return Task.CompletedTask;
    }

    private static Task ExecuteGameProcess(Frame frame, Dot dot, Snake snake)
    {
        while (true)
        {
            if (snake.IsAlive)
            {
                DoAct(frame, dot, snake);
                Console.WriteLine($"Score: {snake.Length - SnakeLength}");
                Thread.Sleep(TimeUpdate);
            }
            else
            {
                Console.WriteLine("GAME OVER");
                Console.WriteLine($"Your score: {snake.Length - SnakeLength}");
                return Task.CompletedTask;
            }
        }
    }

    private static void DoAct(Frame frame, Dot dot, Snake snake)
    {
        frame.SetDot(dot);
        frame.SetSnake(snake);
        snake.TryEatDot(dot);
        snake.Move();
        frame.Display();
        frame.Clear();
    }
}