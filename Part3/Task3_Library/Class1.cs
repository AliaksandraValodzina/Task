using System;
using System.Collections.Generic;
using System.IO;

namespace Equation
{
    public class Quadratic
    {
        // Find roots of quadratic eqution
        public string OuadraticDecision(List<int> constants)
        {
            string message;
            int a = constants[0];
            int b = constants[1];
            int c = constants[2];

            double d = b * b - 4 * a * c;

            if (d >= 0)
            {
                double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);

                message = String.Format("The roots of your equation are: x1 ={0:0.##}; x2={1:0.##}.", x1, x2);
                Console.WriteLine(message);
                
            } else {
                message = "Equation does not have roots.";
                Console.WriteLine("Equation does not have roots.");
            }
            Console.ReadLine();
            return message;
        }

        // Find roots of linear eqution
        public string LinearDecision(List<int> constants)
        {
            string message;
            double a = constants[0];
            double b = constants[1];

            double x = - b / a;

            message = String.Format("The root of your equation are: x ={0:0.##}.", x);
            Console.WriteLine(message);

            Console.ReadLine();
            return message;
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
        public void Logger(List<int> constants, String message)
        {
            string equation = String.Empty;
            if (constants.Count.Equals(3))
            {
                string a = constants[0].ToString();
                string b = constants[1].ToString();
                string c = constants[2].ToString();

                equation = $"{a}*x*x + {b}*x + {c} = 0";
            }

            if (constants.Count.Equals(2))
            {
                string a = constants[0].ToString();
                string b = constants[1].ToString();

                equation = $"{a}*x + {b} = 0";
            }

            string fileName = "C:/EquationLog.txt";

            try
            {
                if (!File.Exists(fileName)) {
                    File.Create(fileName);
                }

                using (StreamWriter w = File.AppendText(fileName))
                {
                    w.Write(equation);
                    w.Write("\r\n");
                    w.Write(message);
                    w.Write("\r\n");
                }
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
