namespace SnakeGame;

public class Pixel
{
    public Pixel(int x, int y, CharProps color)
    {
        X = x;
        Y = y;
        CharProps = color;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public CharProps CharProps { get; set; }
}

public class CharProps
{
    public Image Image { get; init; }
    public GameColors Color { get; set; }
}