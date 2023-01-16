using System;

namespace Game
{
    class UserInterface
    {
        public int InterfaceHeight { get; }
        public int Score { get; set; }
        readonly string scoreRow = "Score: ";
        public UserInterface(int height)
        {
            InterfaceHeight = height;
            Score = 0;
        }
        //TODO: add highscores chart that save scores
        public void SetInterface()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(scoreRow + Score);
            Console.SetCursorPosition(0, InterfaceHeight - 1);
            Console.Write(new string('=', Console.WindowWidth));
        }
        //TODO: maybe make async UpdateScore
        /*public async Task UpdateScoreAsync()
        {
            await UpdateScore();
        }*/
        public void UpdateScore()
        {
            Console.SetCursorPosition(scoreRow.Length, 0);
            Console.Write(++Score);
        }
        public void TitleScreen()
        {
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

            Console.SetCursorPosition(28, 28); Console.Write("Created by: Bondar B. (2021)");
            Console.SetCursorPosition(34, 29); Console.Write("ver. 2.0 (2023)");
            Console.ReadKey(true);
            Console.Clear();

        }
        public void EndScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(17, 7); Console.Write(@"W     W    AAA    SSSSS   TTTTT   EEEEE   DDDD");
            Console.SetCursorPosition(17, 8); Console.Write("W     W   A   A   S         T     E       D   D");
            Console.SetCursorPosition(17, 9); Console.Write("W  W  W   A   A   SSSSS     T     EEEEE   D   D");
            Console.SetCursorPosition(17, 10); Console.Write("W  W  W   AAAAA       S     T     E       D   D");
            Console.SetCursorPosition(17, 11); Console.Write("  W  W    A   A   SSSSS     T     EEEEE   DDDD");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(33, 13); Console.Write($"YOUR SCORE: {Score}");
            Console.ResetColor();

            Console.SetCursorPosition(35, 15); Console.Write("Try Again?");
            Console.SetCursorPosition(31, 17); Console.Write("Y - Yes / N - Exit");
        }
    }
}
