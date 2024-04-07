namespace SnakeGame;

public class Frame
{
    private readonly int _sizeX;
    private readonly int _sizeY;
    private readonly (Image image, GameColors color)[,] _values;

    public Frame(int sizeX, int sizeY)
    {
        _sizeX = sizeX;
        _sizeY = sizeY;
        _values = new (Image, GameColors)[_sizeX, _sizeY];
        SetValues();
    }

    public void SetSnake(Snake snake)
    {
        foreach (var item in snake.Pixels)
            _values[item.X, item.Y] = (item.CharProps.Image, item.CharProps.Color);
    }

    public void SetDot(Dot dot)
    {
        if (dot.Pixel is null) return;

        _values[dot.Pixel.X, dot.Pixel.Y] = (dot.Pixel.CharProps.Image, dot.Pixel.CharProps.Color);
    }

    public void Display()
    {
        for (var i = 0; i < _sizeX; i++)
        {
            for (var j = 0; j < _sizeY; j++)
            {
                var element = _values[i, j];

                switch (element.image)
                {
                    case Image.Empty:
                        Console.ResetColor();
                        break;
                    case Image.Snake:
                        Console.ForegroundColor = (ConsoleColor)element.color;
                        break;
                    case Image.Dot:
                        Console.ForegroundColor = (ConsoleColor)element.color;
                        break;
                    case Image.VerticalBorder:
                    case Image.HorizontalBorder:
                    case Image.UpperLeftCorner:
                    case Image.UpperRightCorner:
                    case Image.LowerRightCorner:
                    case Image.LowerLeftCorner:
                        Console.ForegroundColor = (ConsoleColor)element.color;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                Console.Write((char)_values[i, j].image);
            }

            Console.ResetColor();
            Console.WriteLine();
        }
    }

    public void Clear()
    {
        Console.Clear();
        Console.ResetColor();
        for (var i = 1; i < _sizeX - 1; i++)
        for (var j = 1; j < _sizeY - 1; j++)
            _values[i, j].image = Image.Empty;
    }

    public int CountDots()
    {
        return _values.Cast<(Image image, GameColors)>().Count(c => c.image == Image.Snake);
    }

    private void SetValues()
    {
        for (var i = 0; i < _sizeX; i++)
        for (var j = 0; j < _sizeY; j++)
        {
            var element = new CharProps();
            if (i == 0 && j == 0)
                element = new CharProps { Image = Image.UpperLeftCorner, Color = GameColors.Border }; //'╔';
            if (i == 0 && j == _sizeY - 1)
                element = new CharProps { Image = Image.UpperRightCorner, Color = GameColors.Border }; //'╗';
            if (i == _sizeX - 1 && j == _sizeY - 1)
                element = new CharProps { Image = Image.LowerRightCorner, Color = GameColors.Border }; //'╝';
            if (i == _sizeX - 1 && j == 0)
                element = new CharProps { Image = Image.LowerLeftCorner, Color = GameColors.Border }; //'╚';
            if (i == 0 && j > 0 && j < _sizeY - 1)
                element = new CharProps { Image = Image.HorizontalBorder, Color = GameColors.Border }; //'═';
            if (i == _sizeX - 1 && j > 0 && j < _sizeY - 1)
                element = new CharProps { Image = Image.HorizontalBorder, Color = GameColors.Border }; //'═';
            if (j == 0 && i > 0 && i < _sizeX - 1)
                element = new CharProps { Image = Image.VerticalBorder, Color = GameColors.Border }; //'║';
            if (j == _sizeY - 1 && i > 0 && i < _sizeX - 1)
                element = new CharProps { Image = Image.VerticalBorder, Color = GameColors.Border }; //'║';

            if (i > 0 && i < _sizeX - 1 && j > 0 && j < _sizeY - 1)
                element = new CharProps { Image = Image.Empty, Color = GameColors.Border };

            _values[i, j] = (element.Image, element.Color);
        }
    }
}