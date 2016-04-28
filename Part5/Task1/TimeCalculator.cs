using System;

namespace Task1
{
    public class TimeCalculator
    {

    public string PeriodOfTime(long elapsedTicks)
        {
            string time;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            time = $"{elapsedSpan.TotalMilliseconds}";

            // Pesults print to console while programm work
            Console.Write("\r\n");
            Console.Write(time);       
                 
            return time;
    }
    }
}
