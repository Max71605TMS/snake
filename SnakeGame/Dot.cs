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
        private Queue<Pixel> _Pixels;

        public Pixel Pixel { get; set; }        
       
        public Dot (Queue<Pixel> Pixels)
        {
            _Pixels = Pixels;
        }

        public Dot (int SizeX, int SizeY)
        {
            _sizeX = SizeX;
            _sizeY = SizeY; 
            
        }
        public void Generate()
        {
            bool a = true;
            do
            {


                Random Random = new Random();
                Pixel NewPixel = new Pixel();
                NewPixel.X = Random.Next(1, _sizeX - 1);
                NewPixel.Y = Random.Next(1, _sizeY - 1);                
                foreach (var pixel in _Pixels)
                {
                    if (pixel.X == Pixel.X || pixel.Y == Pixel.Y)
                    {
                        a = false;
                    }
                }
            } while (a != true);
        }
    }
}
