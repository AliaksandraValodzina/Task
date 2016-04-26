using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            if (obj == null)
            {
                return false;
            }

            Point p = obj as Point;
            if ((System.Object)p == null)
            {
                return false;
            }

            return (this.X == p.X) && (this.Y == p.Y);
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

    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void MyTestMethod()
        {
            Point p1 = new Point(1, 2);
            Point p2 = new Point(1, 2);

            Assert.AreEqual(p1.Equals(p2), true);

        }

    }
}
