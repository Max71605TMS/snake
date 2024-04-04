using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Pixel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Image Image { get; set; }

        public Pixel(int x, int y, Image image)
        {
            X = x;
            Y = y;
            Image = image;
        }
    }
}