using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Frame
    {
        private Image[,] _values;

        private int _sizeX;
        private int _sizeY;

        public Frame(int _sizeY, int _sizeX) 
        {
            _values = new Image[_sizeY, _sizeX];
            int Y = 0;
            for (int j = 0; j < _sizeX; j++)
            {
                _values[Y, j] = Image.HorizontalBorder;
            }
            Y = _sizeY - 1;
            for (int j = 0; j < _sizeX; j++)
            {
                _values[Y, j] = Image.HorizontalBorder;
            }
            int X = 0;
            for (int i = 1; i < _sizeY - 1; i++)
            {
                _values[i, X] = Image.VerticalBorder;
            } 
            X = _sizeX - 1;
            for (int i = 1; i < _sizeY - 1; i++)
            {
                _values[i, X] = Image.VerticalBorder;
            }

            for (int i = 1; i < _values.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < _values.GetLength(1) - 1; j++)
                {
                    _values[i, j] = Image.Empty;
                }
            }
        }

        public void SetSnake(Snake snake)
        {
            foreach (var item in snake.Pixels)
            {
                _values[item.Y, item.X] = Image.Snake;
            }
        }

        public void SetDot(Dot dot)
        {
            _values[dot.Pixel.Y, dot.Pixel.X] = Image.Dot;
        }

        public void Clear()
        {
            for (int i = 1; i < _values.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < _values.GetLength(1) - 1; j++)
                {
                    _values[i,j] = Image.Empty;
                }
            }
        }

        public void Display()
        {
            Console.Clear();
            for (int i = 0; i < _values.GetLength(0); i++)
            {
                for (int j = 0; j < _values.GetLength(1); j++)
                {
                    switch (_values[i, j])
                    {
                        case Image.Empty:
                            Console.Write(" ");
                            break;
                        case Image.Snake:
                        case Image.Dot:
                            Console.Write("*");
                            break;
                        case Image.VerticalBorder:
                            Console.Write("|");
                            break;
                        case Image.HorizontalBorder:
                            Console.Write("-");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
