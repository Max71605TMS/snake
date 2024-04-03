﻿using System;
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
            var y = random.Next(1, _sizeY - 1);
            var x = random.Next(1, _sizeX - 1);

<<<<<<< HEAD
            newPix.Y = random.Next(1, _sizeY -1);
            newPix.X = random.Next(1, _sizeX -1);
=======
            Pixel newPix = new Pixel(x, y, Image.Dot);
>>>>>>> 39812b50f16dd7faf1fcaa753aeb8c5736c49109

            if (snake.Pixels.Count == 0)
            {
                return;
            }
            foreach (var snakePixel in snake.Pixels)
            {
                if (snakePixel.Y == newPix.Y)
                {
                    newPix.Y = random.Next(1, _sizeY);
                }

                if (snakePixel.X == newPix.X)
                {
                    newPix.X = random.Next(1, _sizeX);
                }
            }
        }
    }
}
