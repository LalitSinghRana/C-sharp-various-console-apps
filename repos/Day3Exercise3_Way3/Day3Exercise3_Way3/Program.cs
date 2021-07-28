using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3Exercise3_Way3
{
    class Program
    {
        static void Main(string[] args)
        {
            var myQ = new PriorityQueue3<int>();
            for(int i=2; i<11; i++)
            {
                myQ.Enqueue(i/2, i*100);
            }

            myQ.Enqueue(14, 14);
            Console.WriteLine("\nContains 14 : {0}", myQ.Contains(14));
            Console.WriteLine("Contains 15 : {0}", myQ.Contains(15));

            while (myQ.count>0)
            {
                Console.WriteLine("\nCurrent count = {0}", myQ.count);
                Console.WriteLine("Current highest priority : {0}, value = {1}", myQ.GetHighestPriority(), myQ.Peek());
                var temp = myQ.Dequeue();
                Console.WriteLine("Top priority element '{0}' removed.", temp);
            }
        }
    }

    class PriorityQueue3<T> where T : IEquatable<T>
    {
        private class PriorityNode { 
            public int Priority { get; private set; }
            public T data { get; private set; }

            public PriorityNode(int priority, T data)
            {
                this.Priority = priority;
                this.data = data;
            }
        }

        private IList<PriorityNode> elements;

        public PriorityQueue3()
        {
            elements = new List<PriorityNode>();
        }

        public PriorityQueue3(IDictionary<int, IList<T>> _elements) : this()
        {
            this.elements = (IList<PriorityNode>)_elements;
        }
        public int count
        {
            get { return elements.Count; }
        }

        public bool Contains(T item)
        {
            foreach (var i in elements) if (i.data.Equals(item)) return true;
            return false;
        }

        public T Dequeue()
        {
            var max = Peek();
            elements.RemoveAt(elements.Count - 1);
            return max;
        }
        public void Enqueue(int priority, T item)
        {   
            foreach(var e in elements)
            {
                if (e.Priority == priority)
                {
                    Console.WriteLine("Error : Key \"{0}\" already exist.", priority);
                    goto end;
                }
            }
            var temp = new PriorityNode(priority, item);
            elements.Add(temp);
            var Etemp = elements.OrderBy(x => x.Priority);
            elements = Etemp.ToList();
        end:;
        }
        public T Peek()
        {
            if (elements.Count == 0) throw new InvalidOperationException("Error : Queue is empty.");
            return elements.Last().data;
        }

        public int GetHighestPriority()
        {
            if (elements.Count == 0) throw new InvalidOperationException(" Error : Queue is empty.");
            return elements.Last().Priority;
        }
    }
}
