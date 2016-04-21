using System;
using Equation;
using System.Collections.Generic;

namespace QuadraticDecision
{
    class Program
    {
        static void Main(string[] args)
        {
            // Choose a type of equation
            Console.Write("Plese enter Q if you want to solve a quadratic equation\r\n");
            Console.Write("or enter L if you want to solve a linear equation.\r\n");
            string typeEquation = Console.ReadLine();
            Quadratic quadratic = new Quadratic();

            // Input value A, B, C
            switch (typeEquation)
            {
                // Solve a quadratic equation.
                case "Q":
                    // Enter A, B, C
                    Console.Write("Plese enter constants of a quadratic equation: A B C.\r\n");
                    List<int> constants = quadratic.InputValue();

                    // Find roots
                    string messageOuadratic = quadratic.OuadraticDecision(constants);

                    // Write to log
                    quadratic.Logger(constants, messageOuadratic);
                    break;

                // Solve a linear equation.
                case "L":
                    // Enter A, B
                    Console.Write("Plese enter constants of a linear equation: A B.\r\n");
                    List<int> constantsLinear = quadratic.InputValue();

                    // Find root
                    string messageLinear = quadratic.LinearDecision(constantsLinear);

                    // Write to log
                    quadratic.Logger(constantsLinear, messageLinear);
                    break;

                default:
                    String message = $"Default input type: {typeEquation}";
                    Console.WriteLine(message);
                    break;
            }
        }
        }
    }
