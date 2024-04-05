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
        private readonly int _frameSizeX;
        private readonly int _frameSizeY;
        public Queue<Pixel> Pixels { get; set; }

        public Direction Direction { get; set; } = Direction.LEFT;

        public int Length => Pixels.Count;

        public bool IsAlive { get; private set; } = true;

        public Snake(int frameSizeX, int frameSizeY, int snakeLength)
        {
            _frameSizeX = frameSizeX;
            _frameSizeY = frameSizeY;

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
            HealthCheck();
            if (IsAlive)
            {
                MoveTheSnake();
            }
        }

        private void MoveTheSnake()
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

        public void TryEatDot(Dot dot)
        {
            Pixel nextPosition = Direction switch
            {
                Direction.UP => new Pixel(_head.X, _head.Y - 1, Image.Snake),
                Direction.DOWN => new Pixel(_head.X, _head.Y + 1, Image.Snake),
                Direction.LEFT => new Pixel(_head.X - 1, _head.Y, Image.Snake),
                Direction.RIGHT => new Pixel(_head.X + 1, _head.Y, Image.Snake)
            };

            if (nextPosition.X == dot.Pixel.X && nextPosition.Y == dot.Pixel.Y)
            {
                _head = new Pixel(dot.Pixel.X, dot.Pixel.Y, Image.Snake);
                Pixels.Enqueue(_head);
                // Затираем точку на поле и создаем новую 
                dot.Pixel.Image = Image.Empty;
                dot.Generate(this);
            }
        }

        private void HealthCheck()
        {
            IsAlive = Direction switch
            {
                Direction.UP => IsSnakeAliveCheck(_head.X, _head.Y - 1, _head.Y - 1, 0),
                Direction.DOWN => IsSnakeAliveCheck(_head.X, _head.Y + 1, _head.Y + 1, _frameSizeY - 1),
                Direction.LEFT => IsSnakeAliveCheck(_head.X - 1, _head.Y, _head.X - 1, 0),
                Direction.RIGHT => IsSnakeAliveCheck(_head.X + 1, _head.Y, _head.X + 1, _frameSizeX - 1),
            };
        }

        private bool IsSnakeAliveCheck(int dotFromSnakeHeadX, int dotFromSnakeHeadY, int dotNearBorder,
            int nearestBorderCorr)
        {
            return !Pixels.Any(p =>
                p.X == dotFromSnakeHeadX && p.Y == dotFromSnakeHeadY || dotNearBorder == nearestBorderCorr);
        }
    }
}