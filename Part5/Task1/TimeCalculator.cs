using System;

namespace Task1
{
    public class TimeCalculator
    {

    public string periodOfTime(long elapsedTicks) {
            string time;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            time = $"{elapsedSpan.Milliseconds} milliseconds";

            // Pesults print to console while programm work
            Console.Write("\r\n");
            Console.Write(time);       
                 
            return time;
    }
    }
}
