using SnakeGame;
using System.Diagnostics;
using System.Xml.Linq;
class Program
{
    const int SizeX = 50;
    const int SizeY = 20;
    const int SnakeLength = 3;

    static async Task Main(string[] args)
    {
        //team2
        Init();
        Frame frame = new Frame(SizeX, SizeY);
        Snake snake = new Snake(SizeX, SizeY, SnakeLength);
        Dot dot = new Dot(SizeX, SizeY);
        dot.Generate(snake);

        Task conductSnakeTask = Task.Run(() => GuideSnake(snake));
        Task executeGameProcessTask = Task.Run(() => ExecuteGameProcess(frame, dot, snake));

        Task.WaitAll(conductSnakeTask, executeGameProcessTask);
    }

    private static void Init()
    {
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
                    snake.Direction = Direction.LEFT;
                    break;
                case ConsoleKey.RightArrow:
                    snake.Direction = Direction.RIGHT;
                    break;
                case ConsoleKey.UpArrow:
                    snake.Direction = Direction.UP;
                    break;
                case ConsoleKey.DownArrow:
                    snake.Direction = Direction.DOWN;
                    break;
                default:
                    break;
            }
            Thread.Sleep(1000);
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
                Console.WriteLine("Score: " + (snake.Length - 3));
                Thread.Sleep(500);
            }
            else
            {
                Console.WriteLine("GAME OVER");
                Console.WriteLine("Your score: " + (snake.Length - 3));
                break;
            }          
        }
        return Task.CompletedTask;
    }

    private static void DoAct(Frame frame, Dot dot, Snake snake)
    {
        snake.TryEatDot(dot);
        frame.SetDot(dot);
        frame.SetSnake(snake);
        snake.Move();
        frame.Display();
        frame.Clear();


     
    }


}
