using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public class CollectionWorker
    {
        public ICollection<int> AddToCollection(ICollection<int> collection, int numberOfElements) {
            for (int i = 0; i <= numberOfElements; i++)
            {
                collection.Add(i);
            }
            return collection;
        }

        public IDictionary<int, int> AddToCollection(IDictionary<int, int> collection, int numberOfElements)
        {
            for (int i = 0; i <= numberOfElements; i++)
            {
                collection.Add(i, i);
            }
            return collection;
        }

        public ICollection<int> ChangeElement(ICollection<int> collection, int item)
        {
            //int n;
            for (int i = 0; i <= 500000; i++)
            {
                int element = collection.ElementAt(i);
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
