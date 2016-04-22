using System;

namespace Task1
{
    public class Point : object
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y) {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(Object obj)
        {
            return obj is Point && this == (Point)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            string returnStr = $"X = {X}, Y = {Y}";
            return returnStr;
        }
    }
}
