using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class TimeCalculator
    {

    public string periodOfTime(DateTime start, DateTime end) {
            string time;
            long elapsedTicks = start.Ticks - end.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            time = $"{elapsedSpan.Minutes} minutes, {elapsedSpan.Seconds} seconds";
            return time;
    }
    }
}
