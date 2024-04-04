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

        public Direction Direction { get; set; } = Direction.LEFT;

        public int Length { get; }

        public bool IsAlive { get; set; } = true;

        public Snake(int frameSizeX, int frameSizeY, int snakeLength)
        {
            Pixels = new Queue<Pixel>();

            int xHead = frameSizeX / 2;
            int yHead = frameSizeY / 2;
            _head = new Pixel(xHead, yHead, Image.Snake);

            for (int i = snakeLength - 1; i > 0; i--)
            {
                var pixel = new Pixel(xHead + i, yHead, Image.Snake);
                Pixels.Enqueue(pixel);
            }

            Pixels.Enqueue(_head);
        }

        public void Move()
        {
            this.HealthCheck();
            if (IsAlive)
            {
                //Отрезаем хвост змеи при каждом движении
                Pixels.Dequeue();

                //В зависимости от текущего значения Direction, создаем новый _head и добавляем в конец очереди
                switch (Direction)
                {
                    case Direction.UP:
                        _head = new Pixel(_head.X, _head.Y - 1, Image.Snake);
                        Pixels.Enqueue(_head);
                        break;
                    case Direction.DOWN:
                        _head = new Pixel(_head.X, _head.Y + 1, Image.Snake);
                        Pixels.Enqueue(_head);
                        break;
                    case Direction.LEFT:
                        _head = new Pixel(_head.X - 1, _head.Y, Image.Snake);
                        Pixels.Enqueue(_head);
                        break;
                    case Direction.RIGHT:
                        _head = new Pixel(_head.X + 1, _head.Y, Image.Snake);
                        Pixels.Enqueue(_head);
                        break;
                }
            }
        }

        public void TryEatDot()
        {
        }

        private void HealthCheck()
        {
            switch (Direction)
            {
                case Direction.UP:
                    IsAlive = !Pixels.Any(p => p.X == _head.X && p.Y == _head.Y - 1);
                    break;
                case Direction.DOWN:
                    IsAlive = !Pixels.Any(p => p.X == _head.X && p.Y == _head.Y + 1);
                    break;
                case Direction.LEFT:
                    IsAlive = !Pixels.Any(p => p.X == _head.X - 1 && p.Y == _head.Y);
                    break;
                case Direction.RIGHT:
                    IsAlive = !Pixels.Any(p => p.X == _head.X + 1 && p.Y == _head.Y);
                    break;
            }
        }
    }
}