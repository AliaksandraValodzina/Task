using System;
using System.Collections.Generic;
using System.Linq;
using Task3;
using Task2;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fibonacci
            Fibonacci fib = new Fibonacci();
            Console.Write("Сколько чисел Фибоначчи из последовательности вы хотете рассмотреть?\n");
            var nStr = Console.ReadLine();
            int n = 0;

            try
            {
                n = int.Parse(nStr);
            }
            catch (FormatException)
            {
                Console.Write($"Вы ввели недопустимый символ - {nStr}. Введите число. \n");
                nStr = Console.ReadLine();
                n = int.Parse(nStr);
            }

            List<decimal> fibList = fib.Fib(n);
            Console.Write("Числа Фибоначчи:\n\n");
            for (int i = 0; i < fibList.Count(); i++)
            {
                Console.Write(fibList.ElementAt(i) + " ");
            }

            // Fibonacci. Task 1
            int count = fib.Task1(fibList);
            Console.Write("\n\nFibonacci. Задание 1\n");
            Console.Write("Сколько чисел являются простыми.\n\n");
            Console.Write(count);

            // Fibonacci. Task 2
            int task2 = fib.Task2(fibList);
            Console.Write("\n\nFibonacci. Задание 2\n");
            Console.Write("Сколько чисел делятся на сумму своих цифр.\n\n");
            Console.Write(task2);

            // Fibonacci. Task 3
            string task3 = fib.Task3(fibList);
            Console.Write("\n\nFibonacci. Задание 3\n");
            Console.Write("Есть ли числа, которые делятся на 5.\n");
            Console.Write(task3);

            // Fibonacci. Task 4
            IEnumerable<double> task4 = fib.Task4(fibList);
            Console.Write("\n\nFibonacci. Задание 4\n");
            Console.Write("Квадратные корни всех чисел, которые имеют в составе цифру 2\n");
            Console.Write("(округление до целого вниз).\n\n");
            for (int i = 0; i < task4.Count(); i++)
            {
                Console.Write(task4.ElementAt(i) + " ");
            }

            // Fibonacci. Task 5
            IEnumerable<decimal> task5 = fib.Task5(fibList);
            Console.Write("\n\nFibonacci. Задание 5\n");
            Console.Write("Отсортируйте числа по убыванию их второй цифры.\n\n");
            for (int i = 0; i < task5.Count(); i++)
            {
                Console.Write(task5.ElementAt(i) + " ");
            }

            // Fibonacci. Task 6
            IEnumerable<decimal> task6 = fib.Task6(fibList);
            Console.Write("\n\nFibonacci. Задание 6\n");
            Console.Write("Выберите последние 2 цифры для всех чисел, которые делятся на 3 и среди \n");
            Console.Write("ближайших соседей которых (5 в каждую сторону) есть хотя бы одно, \n");
            Console.Write("которое делится на 5.\n\n");
            for (int i = 0; i < task6.Count(); i++)
            {
                Console.Write(task6.ElementAt(i) + " ");
            }

            // Fibonacci. Task 7
            int task7 = fib.Task7(fibList);
            Console.Write("\n\nFibonacci. Задание 7\n");
            Console.Write("Посчитайте число которое имеет наибольшую сумму квадратов цифр.\n\n");
            Console.Write(task7);

            // Fibonacci. Task 8
            double task8 = fib.Task8(fibList);
            Console.Write("\n\nFibonacci. Задание 8\n");
            Console.Write("Посчитайте среднее количество нулей в числах.\n\n");
            Console.Write(task8);

            Console.Read();
        }
    }
}
