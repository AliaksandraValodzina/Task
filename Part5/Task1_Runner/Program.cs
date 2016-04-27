using System;
using System.Collections.Generic;
using Task1;

namespace Task1_Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionWorker worker = new CollectionWorker();
            LogWriter writer = new LogWriter();
            TimeCalculator timer = new TimeCalculator();
            string message;
            int numberOfElements = 100000;
            string time;
            Console.Write("Programm is working...");

            //Create collections
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            Queue<int> queue = new Queue<int>();
            Stack<int> stack = new Stack<int>();
            SortedSet<int> sortedSet = new SortedSet<int>();
            SortedDictionary<int, int> sortedDict = new SortedDictionary<int, int>();

            // Add to List
            long elapsedTicks = worker.Add(list, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message = $"List add {numberOfElements} elements for {time}";
            writer.WriteToFile(message);

            // Read List
            elapsedTicks = worker.Read(list, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message += $", read for {time}";

            // Remove List
            elapsedTicks = worker.Read(list, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message += $", remove for {time}";
            writer.WriteToFile(message);

            // Add to LinkedList
            elapsedTicks = worker.Add(linkedList, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message = $"LinkedList add {numberOfElements} elements for {time}";

            // Read LinkedList
            elapsedTicks = worker.Read(linkedList, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message += $", read for {time}";

            // Remove LinkedList
            elapsedTicks = worker.Read(linkedList, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message += $", remove for {time}";
            writer.WriteToFile(message);

            // Add to Dictionary
            elapsedTicks = worker.Add(dictionary, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message = $"Dictionary add {numberOfElements} elements for {time}";

            // Read Dictionary
            elapsedTicks = worker.Read(dictionary, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message += $", read for {time}";

            // Remove Dictionary
            elapsedTicks = worker.Read(dictionary, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message += $", remove for {time}";
            writer.WriteToFile(message);

            // Add to Queue
            elapsedTicks = worker.Add(queue, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message = $"Queue add {numberOfElements} elements for {time}";

            // Read Queue
            elapsedTicks = worker.Read(queue, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message += $", read for {time}";

            // Remove Queue
            elapsedTicks = worker.Read(queue, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message += $", remove for {time}";
            writer.WriteToFile(message);

            // Add to Stack
            elapsedTicks = worker.Add(stack, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message = $"Stack add {numberOfElements} elements for {time}";

            // Read Stack
            elapsedTicks = worker.Read(stack, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message += $", read for {time}";

            // Remove Stack
            elapsedTicks = worker.Read(stack, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message += $", remove for {time}";
            writer.WriteToFile(message);

            // Add to SortedSet
            elapsedTicks = worker.Add(sortedSet, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message = $"SortedSet add {numberOfElements} elements for {time}";
            writer.WriteToFile(message);

            // Read SortedSet
            elapsedTicks = worker.Read(sortedSet, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message += $", read for {time}";

            // Remove SortedSet
            elapsedTicks = worker.Read(sortedSet, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message += $", remove for {time}";
            writer.WriteToFile(message);

            // Add to SortedDictionary
            elapsedTicks = worker.Add(sortedDict, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message = $"SortedDictionary add {numberOfElements} elements for {time}";

            // Read SortedDictionary
            elapsedTicks = worker.Read(sortedDict, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message += $", read for {time}";

            // Remove SortedDictionary
            elapsedTicks = worker.Read(sortedDict, numberOfElements);
            time = timer.periodOfTime(elapsedTicks);
            message += $", remove for {time}";
            writer.WriteToFile(message);
        }
    }
}
