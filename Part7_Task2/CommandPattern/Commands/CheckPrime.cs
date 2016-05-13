using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    // ConcreteCommand class
    public class CheckPrime : Command
    {
        private Number number;

        public CheckPrime(Number number)
        {
            this.number = number;
        }

        public void Execute()
        {
            if (IsPrimeSolver.IsPrime(number.Num))
            {
                Console.WriteLine("Number is a prime.");
            }
            else
            {
                Console.WriteLine("Number is not a prime.");
            }
        }
    }
}
