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
            bool isInteger = true;

            foreach (string s in constArray)
            {
                if (!Int32.TryParse(s, out oneConst))
                {
                    isInteger = false;
                } 
            }

            if (isInteger == true)
            {
                foreach (string s in constArray)
                {
                    if (Int32.TryParse(s, out oneConst))
                    {
                        constants.Add(oneConst);
                    }
                }
            } else {
                Console.Write("Plese enter constants of a quadratic equation: \r\n");
                Logger(constRead);
                constants = InputValue();
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
                    w.Write("\r\n");
                }
            } catch (Exception)
            {
                throw;
            }
        }

        // Write to log file incorrect input
        public void Logger(String message)
        {
            string fileName = "C:/EquationLog.txt";

            try
            {
                if (!File.Exists(fileName))
                {
                    File.Create(fileName);
                }

                using (StreamWriter w = File.AppendText(fileName))
                {
                    w.Write("Incorrect input: ");
                    w.Write(message);
                    w.Write("\r\n");
                    w.Write("\r\n");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Task four
        public void Multiplication()
        {
            string file = @"C:\Users\Aliaksandra_Valodzina@epam.com\Task\Part3\Task3_Library\File.txt";
            string fileOne;
            string fileTwo;

            using (StreamReader sr = new StreamReader(file))
            {
                fileOne = sr.ReadLine();
                fileTwo = sr.ReadLine();
            }

            double[,] matrixA = CreateMatrix(fileOne);
            double[,] matrixB = CreateMatrix(fileTwo);

            int row_One = matrixA.GetLength(0);
            int col_One = matrixA.GetLength(1);

            int row_Two = matrixB.GetLength(0);
            int col_Two = matrixB.GetLength(1);

            double[,] matrixC = new double[row_One, col_Two];

            try
            {
                if (col_One.Equals(row_Two))
                {
                    for (int row = 0; row < row_One; row++)
                    {
                        for (int col = 0; col < col_Two; col++)
                        {
                            for (int inner = 0; inner < row_Two; inner++)
                            {
                                matrixC[row, col] += matrixA[row, inner] * matrixB[inner, col];
                            }
                            string outMassive = String.Format("{0:0.##} ", matrixC[row, col]);
                            Console.Write(outMassive);
                        }
                        Console.Write("\r\n");
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Can not find file.");
            }
        }

        // Matrix multidimensional array
        static double[,] CreateMatrix(string pathToFile)
        {
            string line = string.Empty;
            List<double[]> arrays = new List<double[]>();
            int minorLength = 0;

            try
            {
                using (StreamReader reader = new StreamReader(pathToFile))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] lineArray = line.Split(' ');
                        double[] myIntsArray = Array.ConvertAll(lineArray, double.Parse);
                        arrays.Add(myIntsArray);
                    }
                }

                minorLength = arrays[0].Length;
            }
            catch (Exception)
            {
                throw new Exception();
            }


            double[,] ret = new double[arrays.Count, minorLength];
            for (int i = 0; i < arrays.Count; i++)
            {
                var array = arrays[i];
                if (array.Length != minorLength)
                {
                    throw new ArgumentException
                        ("All arrays must be the same length");
                }
                for (int j = 0; j < minorLength; j++)
                {
                    ret[i, j] = array[j];
                }
            }

            return ret;

        }
    }
}

