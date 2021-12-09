using System;
using System.Collections.Generic;
using System.Threading;

namespace Game
{
    class UserInterface
    {
        public static readonly int fieldWidth = 80;
        public static readonly int fieldHeight = 30;
        public void TitleScreen()
        {
            Console.SetWindowSize(fieldWidth, fieldHeight);
            Console.CursorVisible = false;
            Console.SetCursorPosition(23, 0); Console.WriteLine("SSSSS  N   N    AAA    K   K   EEEEE");
            Console.SetCursorPosition(23, 1); Console.WriteLine("S      NN  N   A   A   K  K    E  ");
            Console.SetCursorPosition(23, 2); Console.WriteLine("SSSSS  N N N   A   A   KKK     EEEEE");
            Console.SetCursorPosition(23, 3); Console.WriteLine("    S  N  NN   AAAAA   K  K    E  ");
            Console.SetCursorPosition(23, 4); Console.WriteLine("SSSSS  N   N   A   A   K   K   EEEEE");

            Console.SetCursorPosition(29, 15);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("PRESS ANY KEY TO START");
            Console.ResetColor();

            Console.SetCursorPosition(28, 29); Console.Write("Created by: Bondar B. 2021");
            Console.ReadKey();
            Console.Clear();

        }
        public void Interface()
        {
            Console.Write($"Score: 0");
            Console.SetCursorPosition(0, 1);
            Console.Write(new string('=', Console.WindowWidth));
        }
        public void EndScreen(int points)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(17, 7); Console.Write("W     W    AAA    SSSSS   TTTTT   EEEEE   DDDD");
            Console.SetCursorPosition(17, 8); Console.Write("W     W   A   A   S         T     E       D   D");
            Console.SetCursorPosition(17, 9); Console.Write("W  W  W   A   A   SSSSS     T     EEEEE   D   D");
            Console.SetCursorPosition(17, 10); Console.Write("W  W  W   AAAAA       S     T     E       D   D");
            Console.SetCursorPosition(17, 11); Console.Write("  W  W    A   A   SSSSS     T     EEEEE   DDDD");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(32, 13); Console.Write($"YOUR SCORE: {points}");
            Console.ResetColor();

            Console.SetCursorPosition(35, 15); Console.Write("Try Again?");
            Console.SetCursorPosition(28, 17); Console.Write("Y - Yes / ANY KEY - Exit");
        }
    }
    enum MoveDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
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
            Console.SetCursorPosition(7, 0);
            Console.WriteLine(score);
        }
        public void TryAgain()
        {
            ConsoleKey answer = Console.ReadKey().Key;

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
                default:
                    {
                        runGame = false;
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
                Thread.Sleep(60);
                if (Console.KeyAvailable)
                {
                    ChangeDirection(Console.ReadKey(true));
                }
            }
        }
    }

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
    class Snake
    {
        List<Segment> snake;
        char snakeIcon = '*';
        public List<Segment> SnakeBody { get { return snake; } }
        public char SnakeIcon { get { return snakeIcon; } }
        public Snake()
        {
            snake = new List<Segment>()
            { new Segment (40,15)};
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
    class Food
    {
        char foodIcon = 'O';
        Segment foodPosition;
        bool isEaten;
        public char FoodIcon { get { return foodIcon; } }
        public Segment FoodPosition { get { return foodPosition; } }
        public bool IsEaten { get { return isEaten; } }
        Random posGen = new Random();
        public Food()
        {
            foodPosition = new Segment(10, 15);
            isEaten = false;
        }
        public void UpdatePosition()
        {
            foodPosition.X = posGen.Next(0, UserInterface.fieldWidth);
            foodPosition.Y = posGen.Next(3, UserInterface.fieldHeight);
        }
        public void PlaceFood()
        {
            Console.SetCursorPosition(foodPosition.X, foodPosition.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(foodIcon);
            Console.ResetColor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logic play = new Logic();
            play.Launcher();
        }
    }
}
