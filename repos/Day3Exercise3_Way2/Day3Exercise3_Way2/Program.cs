using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3Exercise3_Way2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("There is no need for the application to be user interactive.");
        }
    }

    interface IPriority
    {
        int Priority
        {
            get;
        }
    }

    class PriorityQueue2<T> where T : IEquatable<T>, IPriority
    {
        private int _num = 0;
        private IDictionary<int, IList<T>> elements;

        public int Priority
        {
            get => _num;
        }

        public PriorityQueue2()
        {
            elements = new SortedDictionary<int, IList<T>>();
        }

        public PriorityQueue2(IEnumerable<T> _elements) : this()
        {
            this.elements = (IDictionary<int, IList<T>>)_elements;
        }
        public int count
        {
            get { return elements.Count; }
        }

        public bool Contains(T item)
        {
            return elements.Contains((KeyValuePair<int, IList<T>>)(object)item);
        }

        public T Dequeue()
        {
            var max = Peek();
            elements.Remove(elements.Keys.Last());
            return max;
        }
        public void Enqueue(T item)
        {
            try
            { 
                elements.Add(++_num, (IList<T>)(object)item);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"{0}\" already exists.", _num);
            }

        }
        public T Peek()
        {
            if (elements.Count == 0) throw new InvalidOperationException("Queue is empty.");
            return (T)elements.Last().Value;
        }

        private int GetHighestPriority()
        {
            if (elements.Count == 0) throw new InvalidOperationException("Queue is empty.");
            return elements.Last().Key;
        }
    }
}
