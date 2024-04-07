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
        private readonly int _sizeX;
        private readonly int _sizeY;
        
        private Pixel _head;

        private Direction _currentDirection = Direction.UP;

        public Queue<Pixel> Pixels { get;} = new();

        public Direction Direction { get; set; } = Direction.UP;

        public int Length => Pixels.Count - 3;

        public bool IsAlive { get; private set; } = true;

        public Snake(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            
            const int snakeInitLength = 3;

            for (var i = snakeInitLength - 1; i >= 0; i--)
            {
                var part = new Pixel(_sizeX / 2 + i, _sizeY / 2, Image.Snake);
            
                Pixels.Enqueue(part);
            }
        }

        public void Move()
        {
            var head = Pixels.Last();
            var newHead = new Pixel(head.X, head.Y, head.Image);
            
            switch (Direction)
            {
                case Direction.UP:
                    if (_currentDirection == Direction.DOWN)
                    {
                        goto case Direction.DOWN;
                    }
                    _currentDirection = Direction;
                    newHead.X--;
                    break;
                case Direction.DOWN:
                    if (_currentDirection == Direction.UP)
                    {
                        goto case Direction.UP;
                    }
                    _currentDirection = Direction;
                    newHead.X++;
                    break;
                case Direction.RIGHT:
                    if (_currentDirection == Direction.LEFT)
                    {
                        goto case Direction.LEFT;
                    }
                    _currentDirection = Direction;
                    newHead.Y++;
                    break;
                case Direction.LEFT:
                    if (_currentDirection == Direction.RIGHT)
                    {
                        goto case Direction.RIGHT;
                    }
                    _currentDirection = Direction;
                    newHead.Y--;
                    break;
            }

            Pixels.Enqueue(newHead);
            Pixels.Dequeue();

            HealthCheck(newHead);

            _head = newHead;
        }

        public void TryEatDot(Dot dot)
        {
            if(_head.X == dot.Pixel.X && _head.Y == dot.Pixel.Y)
                EatingDot(dot);
        }

        private void EatingDot(Dot dot)
        {
            Pixels.Enqueue(dot.Pixel);
            dot.Generate(this);
        }

        private void HealthCheck(Pixel head)
        {
            if (Pixels.Contains(head) || head.X == 0 || head.X == _sizeX - 1 || head.Y == 0 || head.Y == _sizeY - 1)
            {
                IsAlive = false;
            }
        }
    }
}
