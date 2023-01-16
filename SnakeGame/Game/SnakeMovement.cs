using System;
using System.Collections.Generic;

namespace Game
{
    class SnakeMovement
    {
        public SnakeMovement() { }
        public SnakeMoveDirection Direction
        {
            get;
            private set;
        }
        public Point GetDirection()
        {
            return MoveTo[Direction];
        }

        Dictionary<SnakeMoveDirection, Point> MoveTo = new Dictionary<SnakeMoveDirection, Point>()
        {
            {SnakeMoveDirection.UP, new Point(0,-1)},
            {SnakeMoveDirection.DOWN, new Point(0,1)},
            {SnakeMoveDirection.LEFT, new Point(-1,0)},
            {SnakeMoveDirection.RIGHT, new Point(1,0)}
        };
        public void ChangeDirection(ConsoleKeyInfo directionKey)
        {
            switch (directionKey.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    {
                        Direction = Direction == SnakeMoveDirection.DOWN ? Direction : SnakeMoveDirection.UP;
                        break;
                    }
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    {
                        Direction = Direction == SnakeMoveDirection.UP ? Direction : SnakeMoveDirection.DOWN;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    {
                        Direction = Direction == SnakeMoveDirection.RIGHT ? Direction : SnakeMoveDirection.LEFT;
                        break;
                    }
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    {
                        Direction = Direction == SnakeMoveDirection.LEFT ? Direction : SnakeMoveDirection.RIGHT;
                        break;
                    }
            }
        }
    }
}
