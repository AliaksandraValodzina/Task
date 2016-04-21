using System;
using System.Collections.Generic;


namespace Equation
{
    public class Quadratic
    {
        // Find roots of quadratic eqution
        public void OuadraticDecision(List<int> constants)
        {
            int a = constants[0];
            int b = constants[1];
            int c = constants[2];

            double d = b * b - 4 * a * c;

            if (d >= 0)
            {
                double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);

                Console.WriteLine("The roots of your equation are: x1 = {0:0.##}; x2 = {1:0.##}.", x1, x2);
            } else {
                Console.WriteLine("Equation does not have roots.");
            }
            Console.ReadLine();
        }

        // Find roots of linear eqution
        public void LinearDecision(List<int> constants)
        {
            int a = constants[0];
            int b = constants[1];

            double x = b / a;

            Console.WriteLine("The root of your equation are: x = {0:0.##}.", x);

            Console.ReadLine();
        }

        // Read A, B, C values
        public List<int> InputValue()
        {
            string constRead = Console.ReadLine();
            string[] constArray = constRead.Split(' ');
            List<int> constants = new List<int>();
            int oneConst;
            foreach (string s in constArray)
            {
                if (Int32.TryParse(s, out oneConst))
                {
                    constants.Add(oneConst);
                }
            }
            return constants;
        }

        // Write to log file
        public void Logger()
        {
            
        }
    }
}
