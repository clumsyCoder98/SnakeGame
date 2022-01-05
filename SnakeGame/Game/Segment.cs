using System;

namespace Game
{
    class Segment : ICloneable
    {
        int x, y;

        public Segment(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        public object Clone()
        {
            return new Segment(this.X, this.Y);
        }

        public static Segment operator +(Segment a, Segment b)
        {
            int x = a.X + b.X < 0 ? UserInterface.fieldWidth - 1 : a.X + b.X > UserInterface.fieldWidth - 1 ? 0 : a.X + b.X;
            int y = a.Y + b.Y < 2 ? UserInterface.fieldHeight - 1 : a.Y + b.Y > UserInterface.fieldHeight - 1 ? 2 : a.Y + b.Y;
            return new Segment(x, y);
        }

        public static bool operator ==(Segment a, Segment b)
        {
            return (a.X == b.X && a.Y == b.Y);
        }

        public static bool operator !=(Segment a, Segment b)
        {
            return (a.X == b.X && a.Y == b.Y);
        }
    }
}
