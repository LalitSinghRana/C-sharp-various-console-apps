using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3Exercise3_Way3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("There is no need for the application to be user interactive.");
            Random rdm = new Random();

            var myQ = new PriorityQueue3<int>();
            for(int i=1; i<11; i++)
            {
                myQ.Enqueue(rdm.Next(10), rdm.Next());
            }
            
            while(myQ.count>0)
            {
                Console.WriteLine("\nCurrent count = {0}", myQ.count);
                Console.WriteLine("Current highest priority : key = {0}, value = {1}", myQ.GetHighestPriority(), myQ.Peek());
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
            return elements.Contains((PriorityNode)(object)item);
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
                    Console.WriteLine("Key already exist.");
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
            if (elements.Count == 0) throw new InvalidOperationException("Queue is empty.");
            return elements.Last().data;
        }

        public int GetHighestPriority()
        {
            if (elements.Count == 0) throw new InvalidOperationException("Queue is empty.");
            return elements.Last().Priority;
        }
    }
}
