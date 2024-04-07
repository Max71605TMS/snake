namespace SnakeGame;

public class Dot
{
    private readonly int _sizeX;
    private readonly int _sizeY;

    public Dot(int sizeX, int sizeY)
    {
        _sizeX = sizeX;
        _sizeY = sizeY;
    }

    public Pixel? Pixel { get; private set; }

    public void Generate(Snake snake)
    {
        if ((_sizeX - 2) * (_sizeY - 2) - 1 == snake.Length + 2)
        {
            Pixel = null;
            return;
        }

        var random = new Random();

        var isSnake = false;

        while (!isSnake)
        {
            Pixel = new Pixel(random.Next(1, _sizeX - 1), random.Next(1, _sizeY - 1),
                new CharProps { Image = Image.Dot, Color = GameColors.Dot });

            isSnake = !snake.Pixels.Any(a => a.X == Pixel.X && a.Y == Pixel.Y);
        }
    }
}