using System;
using System.Threading;

namespace Game
{
    class Game
    {
        Snake snake;
        Food food;
        PointGenerator points;
        UserInterface ui;
        SnakeMovement movement;
        Func<Point> newPoint;
        bool runGame;
        public Game()
        {
            Console.Title = "Snake.exe";
            Console.CursorVisible = false;
            Console.SetWindowSize(80, 30);
            ui = new UserInterface(2);
            points = new PointGenerator(ui);
            newPoint = () => points.GeneratePoint();
            snake = new Snake(newPoint());
            food = new Food(newPoint());
            movement = new SnakeMovement();
        }
        private void DrawGame()
        {
            food.PlaceFood();
            snake.DrawSnake();
            MoveSnake();
        }
        private void MoveSnake()
        {
            for (int i = snake.Body.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    snake.Body[i] += movement.GetDirection();//[movement.Direction];
                    if (snake.BiteSelf())
                    {
                        ui.EndScreen();
                        TryAgain(); //gameover
                    }
                    else if (snake.Body[i] == food.FoodPosition)
                    {
                        snake.Body.Add(snake.Body[^1].Clone());
                        food.UpdatePosition(newPoint());
                        ui.UpdateScore();
                    }
                }
                else
                {
                    snake.Body[i] = snake.Body[i - 1].Clone();
                }
            }
        }
        private void Reset()
        {
            ui.Score = 0;
            snake.Body.RemoveRange(2, snake.Body.Count - 2);
        }
        private void TryAgain()
        {
            ConsoleKey answer = Console.ReadKey(true).Key;

            switch (answer)
            {
                case ConsoleKey.Y:
                    {
                        runGame = true;
                        Console.Clear();
                        Reset();
                        Run();
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
        public void Run()
        {
            ui.TitleScreen();
            ui.SetInterface();
            runGame = true;
            while (runGame)
            {
                DrawGame();
                //TODO: add snake speed scaling depending on score achieved
                Thread.Sleep(60);
                if (Console.KeyAvailable)
                {
                    movement.ChangeDirection(Console.ReadKey(true));
                }
            }
        }
    }
}
