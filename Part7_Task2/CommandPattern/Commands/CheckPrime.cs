using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    // ConcreteCommand class
    class CheckPrime : Command
    {
        private Number number;

        public CheckPrime(Number number)
        {
            this.number = number;
        }

        public override void Execute()
        {
            if (IsPrime(number.Num))
            {
                Console.WriteLine("Number is a prime.");
            }
            else
            {
                Console.WriteLine("Number is not a prime.");
            }
        }

        // A number is prime or not
        public bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            for (int i = 3; i * i <= number; i += 2)
                if (number % i == 0) return false;
            return true;
        }

    }
}
