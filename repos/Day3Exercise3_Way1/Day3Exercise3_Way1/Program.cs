using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3Exercise3_Way1
{
    class Program
    {
        static void Main(string[] args)
        {
            var myQ = new PriorityQueue<int>();
            for (int i = 0; i < 10; i++) myQ.Enqueue(i/2, i*100);

            myQ.Enqueue(15, 15);
            Console.WriteLine("\nContains 14 : {0}",myQ.Contains(14));
            Console.WriteLine("Contains 15 : {0}", myQ.Contains(15));

            while (myQ.count > 0)
            {
                Console.WriteLine("\nCurrent count = {0}", myQ.count);
                Console.WriteLine("Current highest priority = {0}; value = {1}", myQ.GetHighestPriority(), myQ.Peek().ToString());
                var temp2 = myQ.Dequeue();
                Console.WriteLine("Top priority element '{0}' removed.", temp2);
            }
        }
    }

    class PriorityQueue<T> where T : IEquatable<T>
    {
        private IDictionary<int, IList<T>> elements;

        public PriorityQueue()
        {
            elements = new SortedDictionary<int, IList<T>>();
        }

        public PriorityQueue(IDictionary<int, IList<T>> _elements):this()
        {
            this.elements = _elements;
        }
        public int count
        {
            get { return elements.Count; }
        }

        public bool Contains (T item)
        {
            foreach(var i in elements) if(i.Value.Contains(item)) return true;
            return false;
        }

        public T Dequeue()
        {
            var max = Peek();
            elements.Remove(elements.Keys.Last());
            return max;
        }
        public void Enqueue(int priority, T item)
        {
            try
            {
                var temp = new List<T>();
                temp.Add(item);
                elements.Add(priority, temp);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"{0}\" already exists.", priority);
            }
            
        }
        public T Peek()
        {
            if (elements.Count == 0) throw new InvalidOperationException("Queue is empty.");
            return (T)elements.Last().Value.ElementAt(0);
        }

        public int GetHighestPriority()
        {
            if(elements.Count == 0) throw new InvalidOperationException("Queue is empty.");
            return elements.Last().Key;
        }
    }
}
