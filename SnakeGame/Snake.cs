using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace SnakeGame
{
    public class Snake
    {
        private Pixel _head = new Pixel(SizeX / 2, SizeY / 2);

        private Direction? _currentDirection = null;

        public Queue<Pixel> Pixels { get; set; }

        public Direction Direction { get; set; }

        public int Length { get; }

        public bool IsAlive { get; } = true;

        public void Move(Direction direction)
        {
            _currentDirection = CheckOppositeDirection(_currentDirection, direction);

            switch (_currentDirection)
            {
                case Direction.UP:
                    _head.Y++;
                    break;
                case Direction.DOWN:
                    _head.Y--;
                    break;
                case Direction.RIGHT:
                    _head.X++;
                    break;
                case Direction.LEFT:
                    _head.X--;
                    break;
            }

            Pixels.Enqueue(_head);
            Pixels.Dequeue();

            HealthCheck(_head.X, _head.Y);
        }

        public void TryEatDot(Dot dot)
        {
            switch (Direction)
            {
                case Direction.DOWN:
                    if (_head.Y - 1 == dot.Pixel.Y && _head.X == dot.Pixel.X)
                    {
                        EatingDot(dot);
                    }
                    break;
                case Direction.UP:
                    if (_head.Y + 1 == dot.Pixel.Y && _head.X == dot.Pixel.X)
                    {
                        EatingDot(dot);
                    }
                    break;
                case Direction.LEFT:
                    if (_head.X - 1 == dot.Pixel.X && _head.Y == dot.Pixel.Y)
                    {
                        EatingDot(dot);
                    }
                    break;
                case Direction.RIGHT:
                    if (_head.X + 1 == dot.Pixel.X && _head.Y == dot.Pixel.Y)
                    {
                        EatingDot(dot);
                    }
                    break;
            }
        }

        private void EatingDot(Dot dot)
        {
            Pixels.Enqueue(dot.Pixel);
            dot.Generate();
        }

        private void HealthCheck(int X, int Y)
        {
            if (X == 0 || Y == 0 || X == SizeX || Y == SizeY)
            {
                Console.WriteLine(" Змейка ударилась в границу.");
                Environment.Exit(0);
            }
        }

        private Direction? CheckOppositeDirection(Direction? _currentDirection,Direction direction)
        {

            if (_currentDirection == null)
            {
                return direction;
            }    
            else
            {
                if ((_currentDirection == Direction.LEFT && direction == Direction.RIGHT) ||
                    (_currentDirection == Direction.UP && direction == Direction.DOWN))
                {
                    Console.WriteLine(" Змейка ударилась в саму себя.");
                    Environment.Exit(0);
                }
            }    

            return direction;
        }


    }
}
