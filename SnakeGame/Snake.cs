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

        public void TryEatDot()
        {

        }
        public Snake(int sizeX, int sizeY)
        {
            int xHead = sizeX / 2;
            int yHead = sizeY / 2;
            _head = new Pixel(xHead, yHead, Image.Snake);
            Pixels.Enqueue(_head);
            for (int i = 0; i < 2; i++)
            {
                Pixel pixel =  new  Pixel(xHead-1, yHead, Image.Snake); 
            }
            Direction = Direction.LEFT;

        }

        private void HealthCheck()
        {

        }
    }
}
