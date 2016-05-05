using System;

namespace CommandPattern
{
    // ConcreteCommand class
    public class DistanceCalculator : Command
    {
        private Point point1;
        private Point point2;

        public DistanceCalculator(Point point1, Point point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }

        public override void Execute()
        {
            double distance = Math.Sqrt(Math.Pow((point1.X - point2.X), 2) + Math.Pow((point1.Y - point2.Y), 2));
            Console.WriteLine($"Distance equals {distance}");
        }
    }
}
