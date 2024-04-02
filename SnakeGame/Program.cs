using SnakeGame;

class Program
{
    const int SizeX= 20;
    const int SizeY = 50;

    static async Task Main(string[] args)
    {
        //Team1 starts
        Init();
        Task conductSnakeTask = Task.Run(() => GuideSnake(new Snake()));
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

            snake.Direction = nextDirection;
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

    }


}
