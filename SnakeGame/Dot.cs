namespace SnakeGame
{
    public class Dot
    {
        private readonly int _sizeX;
        private readonly int _sizeY;

        public Dot(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
        }

        public Pixel Pixel { get; private set; }

        public void Generate(Snake snake)
        {
            var random = new Random();

            while (true)
            {
                Pixel = new Pixel(random.Next(1, _sizeX - 1), random.Next(1, _sizeY - 1), Image.Dot);

                foreach (var pixel in snake.Pixels)
                {
                    if (pixel.X == Pixel.X && pixel.Y == Pixel.Y)
                        continue;
                }

                break;
            }
        }
    }
}