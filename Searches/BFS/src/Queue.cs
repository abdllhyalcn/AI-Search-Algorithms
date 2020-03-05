using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QueueAndStack
{
    /* A queue class. There is a queue based working list and neccessary methods. */
    class Queue
    {
        public List<object> queue { get; }
        /* Constructor method puts the reference into the list */
        public Queue(IEnumerable<object> InıtıalQueue=null)
        {
            queue = InıtıalQueue?.ToList() ?? new List<object>();

        }
        /* Enqueue method adds the value at the end of the list */
        public void Enqueue(object value)
        {
            queue.Add(value);
        }
        /* Dequeue method returns the first value from the queue and remove it from the queue */
        public object Dequeue()
        {
            if (queue.Count==0)
            {
                MessageBox.Show("Queue is empty");
                return null;
            }
            object temp = queue[0];
            queue.RemoveAt(0);
            return temp;
        }
        /* GetSorted method orders the values in the queue by ascending. 
         * Original queue list doesnt change */
        public IOrderedEnumerable<object> GetSorted()
        {
            return queue.OrderBy(x=>x);
        }
        /* isEmpty checks if queue is empty*/
        public bool isEmpty()
        {
            return !queue.Any();
        }
        /* AmountOfElements returns the length of the queue */
        public int AmountOfElements()
        {
            return queue.Count;
        }

    }
}
