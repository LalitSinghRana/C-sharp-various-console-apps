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
                elements.Add(priority, (IList<T>)(object)item);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"{0}\" already exists.", priority);
            }
            
        }
        public T Peek()
        {
            if (elements.Count == 0) throw new InvalidOperationException("Queue is empty.");
            return (T)elements.Last().Value;
        }

        private int GetHighestPriority()
        {
            if(elements.Count == 0) throw new InvalidOperationException("Queue is empty.");
            return elements.Last().Key;
        }
    }
}
