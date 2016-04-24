using System;

namespace Task5
{
    public interface IRectangular {
        int width { get; set; }
        int heigth { get; set; }
    }

    public class Rectangular : IRectangular
    {
        public int width { get; set; }
        public int heigth { get; set; }
        }
    

    public interface IRectangularWorker {
         void RectInRect(Rectangular r1, Rectangular r2);
    }

    public class RectangularWorker
    {
        public static int InRectOne(int oneWidth, int oneHeigth, int twoWidth, int twoHeigth) {
            int inRect;

            int onePut = oneWidth / twoWidth;
            int twoPut = oneHeigth / twoHeigth;

            int restWidth = oneWidth - twoWidth * onePut;
            int restHeigth = oneHeigth - twoHeigth * twoPut;

            if (restWidth >= twoHeigth)
            {
                if (restHeigth >= twoWidth)
                {
                    int restPutWidthRight = restWidth / twoHeigth;
                    int restPutHeigthRight = oneHeigth / twoWidth;

                    int restPutWidthBottom = restHeigth / twoWidth;
                    int restPutHeigthBottom = oneWidth / twoHeigth;

                    inRect = onePut * twoPut + restPutWidthRight * restPutHeigthRight + restPutWidthBottom * restPutHeigthBottom;
                } else
                {
                    int restPutWidthRight = restWidth / twoHeigth;
                    int restPutHeigthRight = oneHeigth / twoWidth;

                    inRect = onePut * twoPut + restPutWidthRight * restPutHeigthRight;
                }

            } else
            {
                inRect = onePut * twoPut;
            }

            return inRect;
        }

        public void RectInRect(Rectangular r1, Rectangular r2) {
            int rectOneX = r1.width;
            int rectOneY = r1.heigth;

            int rectTwoX = r2.width;
            int rectTwoY = r2.heigth;

            if (rectOneX >= rectTwoX && rectOneY >= rectTwoY)
            {
                int countOne = InRectOne(rectOneX, rectOneY, rectTwoX, rectTwoY);
                int countTwo = InRectOne(rectOneX, rectOneY, rectTwoY, rectTwoX);
                int count = (countOne > countTwo) ? countOne : countTwo;
                string message = $"We can insert {count} rectangulars {rectTwoX}x{rectTwoY} in rectangular {rectOneX}x{rectOneY}.";
                Console.Write(message);
            }
            else if (rectOneX >= rectTwoX && rectOneY >= rectTwoY)
            {
                int countOne = InRectOne(rectTwoX, rectTwoY, rectOneX, rectOneY);
                int countTwo = InRectOne(rectTwoX, rectTwoY, rectOneY, rectOneX);
                int count = (countOne > countTwo) ? countOne : countTwo;
                string message = $"We can insert {count} rectangulars {rectOneX}x{rectOneY} in rectangular {rectTwoX}x{rectTwoY}.";
                Console.Write(message);
            } else
            {
                Console.Write("You can not insert triangle.");
            }

        }
    }
}
