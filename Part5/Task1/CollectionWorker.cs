using System.Collections.Generic;

namespace Task1
{
    public class CollectionWorker
    {
        public ICollection<int> AddToCollection(ICollection<int> collection) {
            for (int i = 0; i <= 1000000; i++)
            {
                collection.Add(i);
            }
            return collection;
        }

        public ICollection<int> ChangeElement(ICollection<int> collection, int item)
        {
            //int n;
            for (int i = 0; i <= 500000; i++)
            {
                //var element = collection.Where(n => n = i);
            }

            return collection;
        }

        public ICollection<int> DeleteElement(ICollection<int> collection)
        {
            for (int i = 0; i <= 500000; i++)
            {
                collection.Remove(i);
            }
            
            return collection;
        }

        public bool ContainElement(ICollection<int> collection, int element)
        {
            bool elementInCollection = collection.Contains(element);

            return elementInCollection;
        }


    }
}
