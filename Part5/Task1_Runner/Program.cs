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
            int numberOfElements = 10000000;
            DateTime before;
            DateTime after;
            string time;

            //Create collections
            List<int> list = new List<int>();
            LinkedList<int> linkedList = new LinkedList<int>();
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            Queue<int> queue = new Queue<int>();
            Stack<int> stack = new Stack<int>();
            SortedSet<int> sortedSet = new SortedSet<int>();
            SortedDictionary<int, int> sortedDict = new SortedDictionary<int, int>();

            // Add to List
            before = DateTime.Now;
            worker.AddToCollection(list, numberOfElements);
            after = DateTime.Now;
            time = timer.periodOfTime(before, after);
            message = $"List add {numberOfElements} million elements for {time}";
            writer.WriteToFile(message);

            // Add to LinkedList
            before = DateTime.Now;
            worker.AddToCollection(linkedList, numberOfElements);
            after = DateTime.Now;
            time = timer.periodOfTime(before, after);
            message = $"LinkedList add {numberOfElements} elements for {time}";
            writer.WriteToFile(message);

            // Add to Dictionary
            before = DateTime.Now;
            worker.AddToCollection(dictionary, numberOfElements);
            after = DateTime.Now;
            time = timer.periodOfTime(before, after);
            message = $"Dictionary add {numberOfElements} elements for {time}";
            writer.WriteToFile(message);

            // Add to Queue
            before = DateTime.Now;
            worker.AddToCollection(queue, numberOfElements);
            after = DateTime.Now;
            time = timer.periodOfTime(before, after);
            message = $"Dictionary add {numberOfElements} elements for {time}";
            writer.WriteToFile(message);

        }
    }
}
