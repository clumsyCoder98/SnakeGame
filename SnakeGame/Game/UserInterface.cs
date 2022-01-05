using System;

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
            Console.ReadKey(true);
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
            Console.SetCursorPosition(33, 13); Console.Write($"YOUR SCORE: {points}");
            Console.ResetColor();

            Console.SetCursorPosition(35, 15); Console.Write("Try Again?");
            Console.SetCursorPosition(31, 17); Console.Write("Y - Yes / N - Exit");
        }
    }
}
