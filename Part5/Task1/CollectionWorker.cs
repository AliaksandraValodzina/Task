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
                collection.Add(i);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = start.Ticks - end.Ticks;
            return elapsedTicks;
        }

        // Add to Dictionary and calculate an addition time
        public long Add(IDictionary<int, int> directory, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                directory.Add(i, i);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = start.Ticks - end.Ticks;
            return elapsedTicks;
        }

        // Add to Queue and calculate an addition time
        public long Add(Queue<int> queue, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                queue.Enqueue(i);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = start.Ticks - end.Ticks;
            return elapsedTicks;
        }

        // Add to Stack and calculate an addition time
        public long Add(Stack<int> stack, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                stack.Push(i);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = start.Ticks - end.Ticks;
            return elapsedTicks;
        }

        // Add to SortedSet and calculate an addition time
        public long Add(ISet<int> set, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                set.Add(i);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = start.Ticks - end.Ticks;
            return elapsedTicks;
        }

        // Read List and calculate an addition time
        public long Read(List<int> collection, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                int element = collection[i] + 1;
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = start.Ticks - end.Ticks;
            return elapsedTicks;
        }

        // Read LinkedList and calculate an addition time
        public long Read(LinkedList<int> collection, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                int element = collection.Find(i).Value;
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = start.Ticks - end.Ticks;
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
            long elapsedTicks = start.Ticks - end.Ticks;
            return elapsedTicks;
        }

        // Read Queue and calculate an addition time
        public long Read(Queue<int> collection, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                int element = collection.ElementAt(i);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = start.Ticks - end.Ticks;
            return elapsedTicks;
        }

        // Read Stack and calculate an addition time
        public long Read(Stack<int> collection, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                int element = collection.ElementAt(i);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = start.Ticks - end.Ticks;
            return elapsedTicks;
        }

        // Read Set and calculate an addition time
        public long Read(ISet<int> set, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                int element = set.ElementAt(i);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = start.Ticks - end.Ticks;
            return elapsedTicks;
        }

        // Remove List and calculate an addition time
        public long Delete(List<int> collection, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= 500000; i++)
            {
                collection.RemoveAt(i);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = start.Ticks - end.Ticks;
            return elapsedTicks;
        }

        // Remove LinkedList and calculate an addition time
        public long Delete(LinkedList<int> collection, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                collection.Remove(i);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = start.Ticks - end.Ticks;
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
            long elapsedTicks = start.Ticks - end.Ticks;
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
            long elapsedTicks = start.Ticks - end.Ticks;
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
            long elapsedTicks = start.Ticks - end.Ticks;
            return elapsedTicks;
        }

        // Remove SortedSet and calculate an addition time
        public long Delete(SortedSet<int> collection, int numberOfElements)
        {
            DateTime start = DateTime.Now;
            for (int i = 0; i <= numberOfElements; i++)
            {
                collection.Remove(i);
            }
            DateTime end = DateTime.Now;
            long elapsedTicks = start.Ticks - end.Ticks;
            return elapsedTicks;
        }
    }
}
