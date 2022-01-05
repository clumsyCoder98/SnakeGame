using System;

namespace Game
{
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
            foodPosition.Y = posGen.Next(3, UserInterface.fieldHeight); // 3 поскольку 2 строки заняты интерфейсом
        }
        public void PlaceFood()
        {
            Console.SetCursorPosition(foodPosition.X, foodPosition.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(foodIcon);
            Console.ResetColor();
        }
    }
}
