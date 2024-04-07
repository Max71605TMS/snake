using SnakeGame;

class Program
{
    const int SizeX = 20;
    const int SizeY = 50;
    private static Direction nextDirection;

    static async Task Main(string[] args)
    {
        //Team1 starts
        var essence = Init();
        Task conductSnakeTask = Task.Run(() => GuideSnake(essence.Snake));
        Task executeGameProcessTask = Task.Run(() => ExecuteGameProcess(essence));

        Task.WaitAll(conductSnakeTask, executeGameProcessTask);
    }

    private static GameEssence Init()
    {
        Console.WriteLine("Welcome to Snake game, Press Any key to start");
        Console.ReadKey(true);
        var snake = new Snake(SizeX, SizeY);
        var frame = new Frame(SizeX, SizeY);
        var dot = new Dot(SizeX, SizeY);

        return new GameEssence { Frame = frame, Snake = snake, Dot = dot };
    }

    private static Task GuideSnake(Snake snake)
    {
        while (snake.IsAlive)
        {
            
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
        }
        
        return Task.CompletedTask;
    }

    private static Task ExecuteGameProcess(GameEssence essence)
    {
        while (essence.Snake.IsAlive)
        {
            DoAct(essence);
            Thread.Sleep(1000);
        }
        var score = essence.Snake.Length;
        if (score < SizeX * SizeY) {
            DisplayLoos();
        }
        else {
            DisplayWin();
        }
        
        DisplayScore(score);
        return Task.CompletedTask;
    }

    private static void DisplayScore(int score) {
        Console.WriteLine($"Общий счет { score }");
    }

    private static void DisplayWin() {
        Console.WriteLine("Вы выиграли!");
    }

    private static void DisplayLoos() {
        Console.WriteLine("Вы прогирали ваша змея умерла!");
    }

    private static void DoAct(GameEssence essence) {
        essence.Frame.SetSnake(essence.Snake);
        essence.Frame.SetDot(essence.Dot);
        essence.Snake.Move(nextDirection);
        essence.Snake.TryEatDot(essence.Dot);
        essence.Frame.Clear();
        essence.Frame.Display();
    }
}