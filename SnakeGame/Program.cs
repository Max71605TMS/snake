using SnakeGame;
using System.Xml.Linq;
class Program
{
    const int SizeX= 20;
    const int SizeY = 50;
    const int SnakeLength = 3; 

    static async Task Main(string[] args)
    {
        Snake snake = new Snake(SizeX, SizeY, SnakeLength);
        //team2
        Init();
        Task conductSnakeTask = Task.Run(() => GuideSnake( snake));
        Task executeGameProcessTask = Task.Run(() => ExecuteGameProcess());

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
            switch(keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    snake.Direction = Direction.LEFT;
                    break;
                case ConsoleKey.RightArrow:
                    snake.Direction = Direction.RIGHT;
                    break ;
                case ConsoleKey.UpArrow:
                    snake.Direction = Direction.UP;
                    break ;
                case ConsoleKey.DownArrow:
                    snake.Direction= Direction.DOWN;
                    break ;
                default:
                    break;
            }
            DoAct();
            Thread.Sleep(1000);
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
       

        Console.ReadKey();
    }


}
