namespace SnakeGame;

public class Frame
{
    private readonly int _sizeX;
    private readonly int _sizeY;
    private readonly Image[,] _values;

    public Frame(int _sizeX, int _sizeY)
    {
        this._sizeX = _sizeX;
        this._sizeY = _sizeY;
        _values = new Image[_sizeX, _sizeY];
        SetValues();
    }

    public void SetSnake(Snake snake)
    {
        if (snake != null)
            foreach (var item in snake.Pixels)
                _values[item.X, item.Y] = Image.Snake;
    }

    public void SetDot(Dot dot)
    {
        if (dot.Pixel is null) return;

        _values[dot.Pixel.X, dot.Pixel.Y] = Image.Dot;
    }

    public void Display()
    {
        for (var i = 0; i < _sizeX; i++)
        {
            for (var j = 0; j < _sizeY; j++)
            {
                if (_values[i, j] == Image.Dot)
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                else
                    Console.ResetColor();

                Console.Write((char)_values[i, j]);
            }

            Console.WriteLine();
        }
    }

    public void Clear()
    {
        Console.Clear();
        Console.ResetColor();
        for (var i = 1; i < _sizeX - 1; i++)
        for (var j = 1; j < _sizeY - 1; j++)
            _values[i, j] = Image.Empty;
    }

    public int CountDots()
    {
        return _values.Cast<Image>().Count(c => c == Image.Snake);
    }

    private void SetValues()
    {
        for (var i = 0; i < _sizeX; i++)
        for (var j = 0; j < _sizeY; j++)
        {
            if (i == 0 && j == 0) _values[i, j] = Image.UpperLeftCorner; //'╔';
            if (i == 0 && j == _sizeY - 1) _values[i, j] = Image.UpperRightCorner; //'╗';
            if (i == _sizeX - 1 && j == _sizeY - 1) _values[i, j] = Image.LowerRightCorner; //'╝';
            if (i == _sizeX - 1 && j == 0) _values[i, j] = Image.LowerLeftCorner; //'╚';
            if (i == 0 && j > 0 && j < _sizeY - 1) _values[i, j] = Image.HorizontalBorder; //'═';
            if (i == _sizeX - 1 && j > 0 && j < _sizeY - 1) _values[i, j] = Image.HorizontalBorder; //'═';
            if (j == 0 && i > 0 && i < _sizeX - 1) _values[i, j] = Image.VerticalBorder; //'║';
            if (j == _sizeY - 1 && i > 0 && i < _sizeX - 1) _values[i, j] = Image.VerticalBorder; //'║';

            if (i > 0 && i < _sizeX - 1 && j > 0 && j < _sizeY - 1) _values[i, j] = Image.Empty;
        }
    }
}