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

            List<int> list = new List<int>();
            DateTime before = DateTime.Now;
            worker.AddToCollection(list);
            DateTime after = DateTime.Now;



        }
    }
}
