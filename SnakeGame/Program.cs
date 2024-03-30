class Program
{
    static async Task Main(string[] args)
    {

        //team2
        Init();
        Task conductSnakeTask = Task.Run(() => GuideSnake());
        Task executeGameProcessTask = Task.Run(() => ExecuteGameProcess());

        Task.WaitAll(conductSnakeTask, executeGameProcessTask);
    }

    private static void Init()
    {
        Console.WriteLine("Welcome to Snake game, Press Any key to start");
        var key = Console.ReadKey(true);
    }

    private static Task GuideSnake()
    {
        return Task.CompletedTask;
    }
    private static Task ExecuteGameProcess()
    {
        return Task.CompletedTask;
    }



}
