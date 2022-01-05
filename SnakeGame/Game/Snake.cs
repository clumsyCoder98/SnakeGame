using System;
using System.Collections.Generic;

namespace Game
{
    class Snake
    {
        List<Segment> snake;
        char snakeIcon = '*';
        public List<Segment> SnakeBody { get { return snake; } }
        public char SnakeIcon { get { return snakeIcon; } }
        public Snake()
        {
            snake = new List<Segment>()
            { new Segment (40,15)}; // положение головы при старте
            snake.Add((Segment)snake[0].Clone());
        }
        public bool BiteSelf()
        {
            bool gameOver = false;
            for (int i = 1; i < snake.Count; i++)
            {
                if (snake[0] == snake[i])
                {
                    gameOver = true;
                }
            }
            return gameOver;
        }
    }
}
