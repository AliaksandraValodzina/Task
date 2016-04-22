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
        
    }

    public class RectangularWorker
    {
        public static int InRectOne(int sideRectOne, int sideRectTwo) {
            int inRect;

            if (sideRectOne >= sideRectTwo) {
                inRect = sideRectOne / sideRectTwo;
            } else {
                inRect = sideRectTwo / sideRectOne;
            }

            return inRect;
        }

        public void RectInRect(Rectangular r1, Rectangular r2) {
            int rectOneX = r1.width;
            int rectOneY = r1.heigth;

            int rectTwoX = r2.width;
            int rectTwoY = r2.width;

        }
    }
}
