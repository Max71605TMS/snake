using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SnakeGame
{
    public class Frame
    {
        private Image[,] _values;

        private int _sizeX;
        private int _sizeY;

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
            {
                foreach (var item in snake.Pixels)
                {
                    _values[item.X, item.Y] = Image.Snake;
                }
            }

        }
        public void SetDot(Dot dot)
        {
            _values[dot.Pixel.X, dot.Pixel.Y] = Image.Dot;
        }

        public void Clear()
        {
            Console.ResetColor();
            for (int i = 1; i < _sizeX - 1; i++)
            {
                for (int j = 1; j < _sizeY - 1; j++)
                {
                    _values[i, j] = Image.Empty;
                }
            }
        }

        public void Display()
        {
            for (int i = 0; i < _sizeX; i++)
            {
                for (int j = 0; j < _sizeY; j++)
                {
                    if (_values[i, j] == Image.Dot)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                    }
                    else
                    {
                        Console.ResetColor();
                    }

                    Console.Write((char)_values[i, j]);
                }

                Console.WriteLine();
            }
        }

        private void SetValues()
        {
            for (int i = 0; i < _sizeX; i++)
            {
                for (int j = 0; j < _sizeY; j++)
                {
                    if (i == 0 && j == 0) _values[i, j] = Image.UpperLeftCorner;//'╔';
                    if (i == 0 && j == _sizeY - 1) _values[i, j] = Image.UpperRightCorner; //'╗';
                    if (i == _sizeX - 1 && j == _sizeY - 1) _values[i, j] = Image.LowerRightCorner;//'╝';
                    if (i == _sizeX - 1 && j == 0) _values[i, j] = Image.LowerLeftCorner;//'╚';
                    if ((i == 0 && (j > 0 && j < _sizeY - 1))) _values[i, j] = Image.HorizontalBorder;//'═';
                    if ((i == _sizeX - 1 && (j > 0 && j < _sizeY - 1))) _values[i, j] = Image.HorizontalBorder;//'═';
                    if ((j == 0 && (i > 0 && i < _sizeX - 1))) _values[i, j] = Image.VerticalBorder;//'║';
                    if ((j == _sizeY - 1 && (i > 0 && i < _sizeX - 1))) _values[i, j] = Image.VerticalBorder; //'║';

                    if ((i > 0 && i < _sizeX - 1) && (j > 0 && j < _sizeY - 1))
                    {
                        _values[i, j] = Image.Empty;
                    }
                }
            }

        }
    }
}