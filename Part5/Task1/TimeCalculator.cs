using System;

namespace Task1
{
    public class TimeCalculator
    {

    public string periodOfTime(long elapsedTicks) {
            string time;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            time = $"{elapsedSpan.Minutes} minutes, {elapsedSpan.Seconds} seconds";
            return time;
    }
    }
}
