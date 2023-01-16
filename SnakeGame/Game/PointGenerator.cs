using System;

namespace Game
{
    class PointGenerator
    {
        UserInterface ui;
        Random axisGenerator;
        public PointGenerator(UserInterface ui)
        {
            this.ui = ui;
            axisGenerator = new Random();
        }
        public Point GeneratePoint()
        {
            return new Point(axisGenerator.Next(Console.WindowLeft, Console.WindowWidth),
                             axisGenerator.Next(ui.InterfaceHeight, Console.WindowHeight));
        }
    }
}
