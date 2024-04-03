﻿using SnakeGame;

class Program
{
    const int SizeX= 20;
    const int SizeY = 50;
    const int SnakeLength = 3; 

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
        Snake snake = new Snake();
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

    private static void DoAct()
    {
       

        Console.ReadKey();
    }


}
