using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3Exercise3_Way2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rdm = new Random(500);

            var myQ = new PriorityQueue2<PQ2>();
            for (int i = 1; i < 9; i++)
            {
                var temp = new PQ2(i/3, i*100);
                myQ.Enqueue(temp);
            }

            var temp2 = new PQ2(14, 14);
            myQ.Enqueue(temp2);
            Console.WriteLine("Contains 14 : {0}", myQ.Contains(temp2));
            Console.WriteLine("Contains 15 : {0}", myQ.Contains(new PQ2(15, 15)));

            while (myQ.count > 0)
            {
                Console.WriteLine("\nCurrent count = {0}", myQ.count);
                Console.WriteLine("Current highest priority = {0}, value = {1}", myQ.GetHighestPriority(), myQ.Peek().value);
                var temp = myQ.Dequeue().value;
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

    class PQ2 : IPriority, IEquatable<PQ2>
    {
        public int Priority { get; set; }

        public int value { get; set; }

        public PQ2(int p, int val)
        {
            Priority = p;
            value = val;
        }

        public bool Equals(PQ2 other)
        {
            return this.Priority == other.Priority;
        }
    }

    class PriorityQueue2<T> where T : IEquatable<T> , IPriority
    {
        private IDictionary<int, IList<T>> elements;

        public PriorityQueue2()
        {
            elements = new SortedDictionary<int, IList<T>>();
        }

        public PriorityQueue2(IEnumerable<T> _elements) : this()
        {
            elements = (IDictionary<int, IList<T>>)_elements;
        }
        public int count
        {
            get { return elements.Count; }
        }

        public bool Contains(T item)
        {
            foreach(var i in elements)
            {
                if (i.Value.Contains(item)) return true;
            }
            return false;
        }

        public T Dequeue()
        {
            var max = Peek();
            elements.Last().Value.RemoveAt(elements.Last().Value.Count - 1);
            if (elements.Last().Value.Count == 0) elements.Remove(elements.Last().Key);
            return max;
        }
        public void Enqueue(T item)
        {
            IList<T> tempList;
            if (!elements.ContainsKey(item.Priority)) elements.Add(item.Priority, new List<T>());
            tempList = elements[item.Priority];
            tempList.Add(item);
        }
        public T Peek()
        {
            if (elements.Count == 0) throw new InvalidOperationException("Queue is empty.");
            return elements.Last().Value.Last();
        }

        public int GetHighestPriority()
        {
            if (elements.Count == 0) throw new InvalidOperationException("Queue is empty.");
            return elements.Last().Key;
        }
    }
}
