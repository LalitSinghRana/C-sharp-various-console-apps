using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3Exercise3_Way1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("There is no need for the application to be user interactive.");
            Random rdm = new Random();

            var myQ = new PriorityQueue<int>();
            for (int i = 1; i < 11; i++)
            {
                
                myQ.Enqueue(rdm.Next(10), rdm.Next());
            }

            while (myQ.count > 0)
            {
                Console.WriteLine("\nCurrent count = {0}", myQ.count);
                Console.WriteLine("Current highest priority : key = {0}, value = {1}", myQ.GetHighestPriority(), myQ.Peek().ToString());
                var temp = myQ.Dequeue();
                Console.WriteLine("Top priority element '{0}' removed.", temp);
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
            return elements.Contains((KeyValuePair<int, IList<T>>)(object)item);
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
