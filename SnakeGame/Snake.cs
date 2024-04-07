namespace SnakeGame;

public class Snake
{
    private const int SnakeInitLength = 2;
    private readonly int _sizeX;
    private readonly int _sizeY;

    private Direction _currentDirection = Direction.UP;

    private Pixel _head = null!;

    public Snake(int sizeX, int sizeY)
    {
        _sizeX = sizeX;
        _sizeY = sizeY;

        for (var i = SnakeInitLength - 1; i >= 0; i--)
        {
            var part = new Pixel(_sizeX / 2 + i, _sizeY / 2, Image.Snake);

            Pixels.Enqueue(part);
        }
    }

    public Queue<Pixel> Pixels { get; } = new();

    public Direction Direction { get; set; } = Direction.UP;

    public int Length => Pixels.Count - SnakeInitLength;

    public bool IsAlive { get; private set; } = true;

    public void Move()
    {
        var head = Pixels.Last();
        var newHead = new Pixel(head.X, head.Y, head.Image);

        switch (Direction)
        {
            case Direction.UP:
                if (_currentDirection == Direction.DOWN)
                {
                    Direction = _currentDirection;
                    goto case Direction.DOWN;
                }

                _currentDirection = Direction;
                newHead.X--;
                break;
            case Direction.DOWN:
                if (_currentDirection == Direction.UP)
                {
                    Direction = _currentDirection;
                    goto case Direction.UP;
                }

                _currentDirection = Direction;
                newHead.X++;
                break;
            case Direction.RIGHT:
                if (_currentDirection == Direction.LEFT)
                {
                    Direction = _currentDirection;
                    goto case Direction.LEFT;
                }

                _currentDirection = Direction;
                newHead.Y++;
                break;
            case Direction.LEFT:
                if (_currentDirection == Direction.RIGHT)
                {
                    Direction = _currentDirection;
                    goto case Direction.RIGHT;
                }

                _currentDirection = Direction;
                newHead.Y--;
                break;
        }

        HealthCheck(newHead);

        Pixels.Enqueue(newHead);
        Pixels.Dequeue();

        _head = newHead;
    }

    public void TryEatDot(Dot dot)
    {
        if (dot.Pixel is null) return;

        if (_head.X == dot.Pixel.X && _head.Y == dot.Pixel.Y)
            EatingDot(dot);
    }

    private void EatingDot(Dot dot)
    {
        if (dot.Pixel is null) return;

        Pixels.Enqueue(dot.Pixel);
        dot.Generate(this);
    }

    private void HealthCheck(Pixel head)
    {
        if (Pixels.Any(a => a.X == head.X && a.Y == head.Y) || head.X == 0 || head.X == _sizeX - 1 || head.Y == 0 ||
            head.Y == _sizeY - 1) IsAlive = false;
    }
}