namespace SnakeGame;

public class Pixel
{
    public Pixel(int x, int y, Image image)
    {
        X = x;
        Y = y;
        Image = image;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public Image Image { get; set; }
}