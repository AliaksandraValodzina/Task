using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class CollectionWorker
    {
        // Add to Collection and calculate an addition time
        public long Add(ICollection<int> collection, int numberOfElements) 
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                collection.Add(i + 1);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            return elapsedTicks;
        }

        // Add to Dictionary and calculate an addition time
        public long Add(IDictionary<int, int> directory, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                directory.Add(i, i + 1);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            return elapsedTicks;
        }

        // Add to Queue and calculate an addition time
        public long Add(Queue<int> queue, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                queue.Enqueue(i + 1);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            return elapsedTicks;
        }

        // Add to Stack and calculate an addition time
        public long Add(Stack<int> stack, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                stack.Push(i + 1);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            return elapsedTicks;
        }

        // Read Collection and calculate an addition time
        public long Read(ICollection<int> collection, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                int element = collection.ElementAt(i);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            return elapsedTicks;
        }

        // Read Dictionary and calculate an addition time
        public long Read(IDictionary<int, int> collection, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                int element = collection[i];
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            return elapsedTicks;
        }

        // Read Queue and calculate an addition time
        public long Read(Queue<int> collection, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                int element = collection.Peek();
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            return elapsedTicks;
        }

        // Read Stack and calculate an addition time
        public long Read(Stack<int> collection, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                int element = collection.Peek();
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            return elapsedTicks;
        }

        // Remove List and calculate an addition time
        public long Delete(ICollection<int> collection, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= 500000; i++)
            {
                collection.Remove(collection.ElementAt(i));
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            return elapsedTicks;
        }

        // Remove Dictionary and calculate an addition time
        public long Delete(Dictionary<int, int> collection, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                collection.Remove(i);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            return elapsedTicks;
        }

        // Remove Queue and calculate an addition time
        public long Delete(Queue<int> collection, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                collection.Dequeue();
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            return elapsedTicks;
        }

        // Remove Stack and calculate an addition time
        public long Delete(Stack<int> collection, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                collection.Pop();
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = end.Ticks - start.Ticks;
            return elapsedTicks;
        }
    }
}
