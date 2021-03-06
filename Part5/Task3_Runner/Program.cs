﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3;

namespace Task3_Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Customers
            Console.Write("Customers:");
            Customers customer = new Customers();

            // Customers. Task 1
            double x = 30000.0;
            List<string> taskCust1 = customer.Linq0001(x);
            Console.Write("\n\nCustomers. Задание 1\n");
            Console.Write("Выдайте список всех клиентов, чей суммарный оборот \n");
            Console.Write("(сумма всех заказов) превосходит некоторую величину X.\n\n");
            Console.Write($"x = {x}\n");
            foreach (var i in taskCust1)
            {
                Console.Write($"{i} ");
            }

            // Customers. Task 2
            IDictionary<string, List<string>> taskCust2 = customer.Linq0002();
            Console.Write("\n\nCustomers. Задание 2\n");
            Console.Write("Сгруппировать клиентов по странам.\n\n");
            foreach (var i in taskCust2)
            {
                Console.Write($"{i.Key} ");
                foreach (var j in i.Value)
                {
                    Console.Write($"{j} ");
                }
                Console.Write("\n");
            }

            // Customers. Task 3
            x = 7000.0;
            List<string> taskCust3 = customer.Linq0003(x);
            Console.Write("\n\nCustomers. Задание 3\n");
            Console.Write("Найдите всех клиентов, у которых были заказы, превосходящие по сумме величину X.\n");
            Console.Write($"x = {x}\n");
            foreach (var i in taskCust3)
            {
                Console.Write($"{i} ");
            }

            // Customers. Task 4
            var taskCust4 = customer.Linq0004();
            Console.Write("\n\nCustomers. Задание 4\n");
            Console.Write("Выдайте список клиентов с указанием, начиная с какого месяца какого года они \n");
            Console.Write("стали клиентами (принять за таковые месяц и год самого первого заказа).\n\n");
            foreach (var i in taskCust4)
            {
                Console.Write($"  {i.Key} {i.Value.ToString("d")}  ");
            }

            // Customers. Task 5
            var taskCust5 = customer.Linq0005();
            Console.Write("\n\nCustomers. Задание 5\n");
            Console.Write("Сделайте предыдущее задание, но выдайте список отсортированным по году,  \n");
            Console.Write("месяцу, оборотам клиента (от максимального к минимальному) и имени клиента.\n\n");
            foreach (var i in taskCust5)
            {
                Console.Write($"  {i.Key} {i.Value.ToString("d")}  ");
            }

            // Customers. Task 6
            var taskCust6 = customer.Linq0006();
            Console.Write("\n\nCustomers. Задание 6\n");
            Console.Write("Укажите всех клиентов, у которых указан нецифровой код или не заполнен регион  \n");
            Console.Write("или в телефоне не указан код оператора (для простоты считаем, что это \n");
            Console.Write("равнозначно «нет круглых скобочек в начале.\n\n");
            foreach (var i in taskCust6)
            {
                Console.Write($"  {i}  ");
            }

            // Customers. Task 7.1
            var taskCust7_1 = customer.Linq0007_1();
            Console.Write("\n\nCustomers. Задание 7.1\n");
            Console.Write("Рассчитайте среднюю прибыльность каждого города \n");
            Console.Write("(среднюю сумму заказа по всем клиентам из данного города)\n\n");
            foreach (var i in taskCust7_1)
            {
                Console.Write($"  {i.Key} {i.Value}  ");
            }

            // Customers. Task 7.2
            var taskCust7_2 = customer.Linq0007_2();
            Console.Write("\n\nCustomers. Задание 7.2\n");
            Console.Write("Рассчитайте среднюю среднюю интенсивность \n");
            Console.Write("(среднее количество заказов, приходящееся на клиента из каждого города)\n\n");
            foreach (var i in taskCust7_2)
            {
                Console.Write($"  {i.Key} {i.Value}  ");
            }

            // Customers. Task 8.1
            var taskCust8_1 = customer.Linq0008_Month();
            Console.Write("\n\nCustomers. Задание 8.1\n");
            Console.Write("Сделайте среднегодовую статистику активности клиентов");
            Console.Write("по месяцам (без учета года) \n\n");
            foreach (var i in taskCust8_1)
            {
                Console.Write($"  {i.Key} - {i.Value}  ");
            }

            // Customers. Task 8.2
            var taskCust8_2 = customer.Linq0008_Year();
            Console.Write("\n\nCustomers. Задание 8.2\n");
            Console.Write("Сделайте среднегодовую статистику активности клиентов");
            Console.Write("по годам \n\n");
            foreach (var i in taskCust8_2)
            {
                Console.Write($"  {i.Key} - {i.Value}  ");
            }

            // Customers. Task 8.3
            var taskCust8_3 = customer.Linq0008_YearMonth();
            Console.Write("\n\nCustomers. Задание 8.3\n");
            Console.Write("Сделайте среднегодовую статистику активности клиентов");
            Console.Write("по годам и месяцам\n\n");
            foreach (var i in taskCust8_3)
            {
                Console.Write($"  {i.Key} - {i.Value}  ");
            }

            Console.Read();
        }
    }
}
