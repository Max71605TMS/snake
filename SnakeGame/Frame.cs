using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Frame
    {
        private char[,] _values;

        private int _sizeX;
        private int _sizeY;

        public Frame(int _sizeX, int _sizeY) 
        {
            _values = new char[_sizeX, _sizeY];
            int X = 0;
            for (int j = 0; j < _sizeY; j++)
            {
                _values[X, j] = '-';
            }
            X = _sizeX - 1;
            for (int j = 0; j < _sizeY; j++)
            {
                _values[X, j] = '-';
            }
            int Y = 0;
            for (int i = 1; i < _sizeX - 1; i++)
            {
                _values[i, Y] = '|';
            } 
            Y = _sizeY - 1;
            for (int i = 1; i < _sizeX - 1; i++)
            {
                _values[i, Y] = '|';
            }

            for (int i = 1; i < _values.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < _values.GetLength(1) - 1; j++)
                {
                    _values[i, j] = ' ';
                }
            }
        }

        public void SetSnake(Snake snake)
        {
            foreach (var item in snake.Pixels)
            {
                _values[item.X, item.Y] = '*';
            }
        }

        public void SetDot(Dot dot)
        {
            _values[dot.Pixel.X, dot.Pixel.Y] = '*';
        }

        public void Clear()
        {
            for (int i = 1; i < _values.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < _values.GetLength(1) - 1; j++)
                {
                    _values[i,j] = ' ';
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
                    Console.Write(_values[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
