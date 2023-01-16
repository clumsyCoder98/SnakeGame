using System;
using System.Collections.Generic;

namespace Game
{
    class Snake
    {
        readonly char snakeFragment = '*';
        List<Point> body;
        public Snake(Point point)
        {
            body = new List<Point> { point };
            body.Add(body[0].Clone());
        }
        public List<Point> Body
        {
            get
            {
                return body;
            }
        }

        public bool BiteSelf()
        {
            bool isBitten = false;
            for (int i = 1; i < body.Count; i++)
            {
                if (body[0] == body[i])
                {
                    isBitten = true;
                }
            }
            return isBitten;
        }
        public void DrawSnake()
        {
            for (int snakePart = 0; snakePart < body.Count; snakePart++)
            {
                Console.SetCursorPosition(body[snakePart].X, body[snakePart].Y);
                if (snakePart + 1 < body.Count)
                {
                    Console.Write(snakeFragment);
                }
                else
                {
                    Console.Write(' ');
                }
            }
        }
    }
}
