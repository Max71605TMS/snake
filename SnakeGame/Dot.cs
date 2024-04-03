using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Dot
    {
        private readonly int _sizeX;
        private readonly int _sizeY;
        public Pixel Pixel { get; set; }
        public Dot(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
        }
        public void Generate(Snake snake)
        {
            Random random = new Random();
            int y = random.Next(1, _sizeY - 1);
            int x = random.Next(1, _sizeX - 1);
            

            if (snake.Pixels.Count == 0)
            {
                return;
            }

            bool flag = true;

            while (flag)
            {
                if (snake.Pixels.Contains(new Pixel(x, y, Image.Snake)))
                {
                    y = random.Next(1, _sizeY - 1);
                    x = random.Next(1, _sizeX) - 1;
                    continue;
                }
                else
                {
                    flag = false;
                    Pixel = new Pixel(x, y, Image.Dot);

                }
            }
        }
    }
}
