using System;
using System.Collections.Generic;
using System.Threading;

namespace Game
{
    class Logic
    {
        Snake snake;
        Food food;
        UserInterface screen;
        bool runGame;
        MoveDirection direction;
        int score;
        public Logic()
        {
            snake = new Snake();
            food = new Food();
            screen = new UserInterface();
            runGame = true;
            score = 0;
        }

        Dictionary<MoveDirection, Segment> MoveTo = new Dictionary<MoveDirection, Segment>()
        {
        {MoveDirection.UP, new Segment(0, -1)},
        {MoveDirection.DOWN, new Segment(0, 1)},
        {MoveDirection.LEFT, new Segment(-1, 0)},
        {MoveDirection.RIGHT, new Segment(1,0) }
        };

        public void ChangeDirection(ConsoleKeyInfo keyPressed)
        {
            switch (keyPressed.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    {
                        direction = direction == MoveDirection.DOWN ? direction : MoveDirection.UP;
                        break;
                    }
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    {
                        direction = direction == MoveDirection.UP ? direction : MoveDirection.DOWN;
                        break;
                    }
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    {
                        direction = direction == MoveDirection.RIGHT ? direction : MoveDirection.LEFT;
                        break;
                    }
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    {
                        direction = direction == MoveDirection.LEFT ? direction : MoveDirection.RIGHT;
                        break;
                    }
            }
        }
        public void DrawGame()
        {
            for (int snakePart = 0; snakePart < snake.SnakeBody.Count; snakePart++)
            {
                Console.SetCursorPosition(snake.SnakeBody[snakePart].X, snake.SnakeBody[snakePart].Y);

                if (snakePart + 1 < snake.SnakeBody.Count)
                {
                    Console.Write(snake.SnakeIcon);
                }
                else
                {
                    Console.Write(' ');
                }
            }
            MoveSnake();
            food.PlaceFood();
        }

        public void MoveSnake()
        {
            for (int i = snake.SnakeBody.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    snake.SnakeBody[i] += MoveTo[direction];
                    bool snakeBite = snake.BiteSelf();
                    if (snakeBite)
                    {
                        screen.EndScreen(score);
                        TryAgain();
                    }
                    else if (snake.SnakeBody[i] == food.FoodPosition)
                    {
                        snake.SnakeBody.Add((Segment)snake.SnakeBody[snake.SnakeBody.Count - 1].Clone());
                        food.UpdatePosition();
                        UpdateScore();
                    }
                }
                else
                {
                    snake.SnakeBody[i] = (Segment)snake.SnakeBody[i - 1].Clone();
                }
            }

        }
        public void UpdateScore()
        {
            score++;
            Console.SetCursorPosition(8, 0); // место для очков
            Console.WriteLine(score);
        }
        public void TryAgain()
        {
            ConsoleKey answer = Console.ReadKey(true).Key;

            switch (answer)
            {
                case ConsoleKey.Y:
                    {
                        runGame = true;
                        Console.Clear();
                        Reset();
                        Launcher();
                        break;
                    }
                case ConsoleKey.N:
                    {
                        runGame = false;
                        break;
                    }
                default:
                    {
                        TryAgain();
                        break;
                    }
            }
        }
        public void Reset()
        {
            score = 0;
            snake.SnakeBody.RemoveRange(2, snake.SnakeBody.Count - 2);
        }
        public void Launcher()
        {
            screen.TitleScreen();
            screen.Interface();
            while (runGame)
            {
                DrawGame();
                Thread.Sleep(60); // скорость змейки
                if (Console.KeyAvailable)
                {
                    ChangeDirection(Console.ReadKey(true));
                }
            }
        }
    }
}
