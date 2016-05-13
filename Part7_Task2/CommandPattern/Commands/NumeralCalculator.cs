using System;
using System.Linq;

namespace CommandPattern
{
    public class NumeralCalculator : Command
    {
        private Number number;

        public NumeralCalculator(Number number)
        {
            this.number = number;
        }

        public void Execute()
        {
            var sumNumerals = number.Num
                            .ToString()
                            .Select(x => x - '0')
                            .Sum();

            Console.WriteLine($"Sum of numerals equal {sumNumerals}");
        }
    }
}
