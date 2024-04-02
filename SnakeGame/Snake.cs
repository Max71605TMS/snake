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

        private void HealthCheck()
        {

        }
    }
}
