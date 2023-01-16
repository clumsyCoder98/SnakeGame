using System;

namespace Game
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Point operator +(Point a, Point b)
        {
            int x;
            if (a.X + b.X < 0)
            {
                x = Console.WindowWidth - 1; // move from right border to left
            }
            else
            {
                if (a.X + b.X > Console.WindowWidth - 1) // move from left border to right
                {
                    x = 0;
                }
                else
                {
                    x = a.X + b.X; // normal side movement
                }
            }
            int y;
            if (a.Y + b.Y < 2)
            {
                y = Console.WindowHeight - 1; // move from upside to downside
            }
            else
            {
                if (a.Y + b.Y > Console.WindowHeight - 1) // move from downside to upside
                {
                    y = 2;
                }
                else
                {
                    y = a.Y + b.Y; // normal height movement
                }
            }
            return new Point(x, y);
            //TODO: solve the issue of 2 literal; its based on interface height;
        }
        public static Point operator -(Point a, Point b) => new Point(a.X - b.X, a.Y - b.Y);
        public static bool operator ==(Point a, Point b) => a.X == b.X && a.Y == b.Y ? true : false;
        public static bool operator !=(Point a, Point b) => a.X != b.X || a.Y != b.Y ? true : false;

        public override bool Equals(object obj)
        {
            if (!(obj is Point point))
            {
                return false;
            }
            else
            {
                return X == point.X &&
                       Y == point.Y;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
        public Point Clone()
        {
            return (Point)this.MemberwiseClone();
        }
    }
}
