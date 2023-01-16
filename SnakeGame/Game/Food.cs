using System;

namespace Game
{
    class Food
    {
        readonly char foodIcon = 'O';
        public Food(Point place)
        {
            FoodPosition = place;
        }
        public bool IsEaten
        { get; set; }
        public Point FoodPosition
        { get; set; }

        public void UpdatePosition(Point place)
        {
            FoodPosition = place;
            PlaceFood();
        }
        public void PlaceFood()
        {
            Console.SetCursorPosition(FoodPosition.X, FoodPosition.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(foodIcon);
            Console.ResetColor();
        }
        //TODO: mb create an event that invoke PlaceFood and Update metod when food eaten is Game class;
    }
}
