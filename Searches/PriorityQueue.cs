using System;
using System.Collections.Generic;
using System.Linq;

namespace Searches
{
    class PriorityQueue<TElement,TKey>
    {
        private SortedDictionary<TKey, Queue<TElement>> dictionary;
        private Func<TElement, TKey> selector;

        public PriorityQueue(Func<TElement,TKey> selector)
        {
            dictionary = new SortedDictionary<TKey, Queue<TElement>>();
            this.selector = selector;
        }

        public bool Any()
        {
            return (dictionary.Count >0);
        }

        public void Enqueue(TElement item)
        {
            TKey key = selector(item);
            Queue<TElement> queue;
            if(!dictionary.TryGetValue(key,out queue))
            {
                queue = new Queue<TElement>();
                dictionary.Add(key, queue);
            }
            queue.Enqueue(item);
        }

        public TElement Dequeue()
        {
            if (dictionary.Count == 0)
                throw new Exception("No Items to Dequeue: ");
            var key = dictionary.Keys.First();

            var queue = dictionary[key];
            var output = queue.Dequeue();
            if (queue.Count == 0)
                dictionary.Remove(key);

            return output;
        }
    }
}
