using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake
    {
        private Pixel _head;
        public Queue<Pixel> Pixels {  get; set; }

        public Direction Direction { get; set; }

        public int Length { get; }

        public bool IsAlive { get; } = true;

        public void Move()
        {

        }

        public void TryEatDot(Dot dot)
        {
            switch (Direction)
            {
                case Direction.DOWN:
                    if(_head.Y - 1 == dot.Pixel.Y && _head.X == dot.Pixel.X)
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

        private void HealthCheck()
        {

        }
    }
}
