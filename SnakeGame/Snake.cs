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
        public Queue<Pixel> Pixels { get; set; }

        public Direction Direction { get; set; }

        public int Length { get; }

        public bool IsAlive { get; } = true;

        public void Move(Direction directionToGo)
        {
            Pixels.Dequeue();

            switch (directionToGo)
            {
                case Direction.UP:
                    if (Direction != Direction.DOWN)
                    {
                        _head = new Pixel(_head.X, _head.Y - 1, Image.Snake);
                        Pixels.Enqueue(_head);
                    }
                    break;
                case Direction.DOWN:
                    if (Direction != Direction.UP)
                    {
                        _head = new Pixel(_head.X, _head.Y + 1, Image.Snake);
                        Pixels.Enqueue(_head);
                    }
                    break;
                case Direction.LEFT:
                    if (Direction != Direction.RIGHT)
                    {
                        _head = new Pixel(_head.X - 1, _head.Y, Image.Snake);
                        Pixels.Enqueue(_head);
                    }
                    break;
                case Direction.RIGHT:
                    if (Direction != Direction.LEFT)
                    {
                        _head = new Pixel(_head.X + 1, _head.Y, Image.Snake);
                        Pixels.Enqueue(_head);
                    }
                    break;
            }
        }

        public void TryEatDot()
        {

        }
        public Snake(int sizeX, int sizeY)
        {
            Pixels = new Queue<Pixel>();

            int xHead = sizeX / 2;
            int yHead = sizeY / 2;
            _head = new Pixel(xHead, yHead, Image.Snake);

            for (int i = 2; i > 0; i--)
            {
                var pixel = new Pixel(xHead + i, yHead, Image.Snake);
                Pixels.Enqueue(pixel);
            }

            Pixels.Enqueue(_head);
            Direction = Direction.LEFT;
        }


        private void HealthCheck()
        {

        }
    }
}
