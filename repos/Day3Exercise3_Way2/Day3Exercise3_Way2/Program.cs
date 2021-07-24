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
            Random rdm = new Random();

            var myQ = new PriorityQueue2<int>();
            for (int i = 1; i < 11; i++)
            {
                myQ.Enqueue(rdm.Next());
            }

            while (myQ.count > 0)
            {
                Console.WriteLine("\nCurrent count = {0}", myQ.count);
                Console.WriteLine("Current highest priority : key = {0}, value = {1}", myQ.GetHighestPriority(), myQ.Peek());
                var temp = myQ.Dequeue();
                Console.WriteLine("Top priority element '{0}' removed.", temp);
            }
        }
    }

    interface IPriority
    {
        int Priority
        {
            get;
            set;
        }
    }

    class PriorityQueue2<T> where T : IEquatable<T> //, IPriority
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
                var temp = new List<T>();
                temp.Add(item);
                elements.Add(++_num, temp);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"{0}\" already exists.", _num);
            }

        }
        public T Peek()
        {
            if (elements.Count == 0) throw new InvalidOperationException("Queue is empty.");
            return (T)elements.Last().Value.ElementAt(0);
        }

        public int GetHighestPriority()
        {
            if (elements.Count == 0) throw new InvalidOperationException("Queue is empty.");
            return elements.Last().Key;
        }
    }
}
