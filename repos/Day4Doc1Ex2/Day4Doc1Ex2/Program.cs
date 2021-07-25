using System;
using System.Collections.Generic;

namespace Day4Doc1Ex2
{
    public delegate int EHsample(int a, int b);
    class Program
    {
        public delegate void AddEventHandler(Dictionary<Product, int> d, Product p, int n, ref int tv);
        static void Main(string[] args)
        {
            
            var d = new Dictionary<Product, int>();
            int tv = 0;
            Random rdm = new Random();

            Console.WriteLine("\ntv at start = {0}", tv);

            for (int i=1; i<10; i++)
            {
                Product p = new Product(i, rdm.Next(100), false);
                AddEventHandler del = new AddEventHandler(p.HandleSomethingAdded);
                del(d, p, rdm.Next(10), ref tv);
            }
            Console.WriteLine("\ntv after adding = {0}", tv);


            foreach (var temp in d)
            {
                if (temp.Key.id % 2 == 0)
                {
                    AddEventHandler del = new AddEventHandler(temp.Key.HandleSomethingRemoved);
                    del(d, temp.Key, temp.Value, ref tv);
                }
            }
            Console.WriteLine("\ntv after removing = {0}", tv);

            foreach (var temp in d)
            {
                if (temp.Key.id % 2 != 0)
                {
                    AddEventHandler del = new AddEventHandler(temp.Key.HandleSomethingUpdated);
                    del(d, temp.Key, rdm.Next(20), ref tv);
                }
            }
            Console.WriteLine("\ntv after updating = {0}", tv);

            foreach (var temp in d)
            {
                if (temp.Key.id % 3 == 0)
                {
                    AddEventHandler del = new AddEventHandler(temp.Key.HandleSomethingPrice);
                    del(d, temp.Key, rdm.Next(50), ref tv);
                }
            }
            Console.WriteLine("\ntv after price change = {0}", tv);

        }

        public class Product
        {
            public int id;
            public int price;
            public bool isDefective;

            public Product(int a, int b, bool c)
            {
                id = a;
                price = b;
                isDefective = c;
            }

            public void HandleSomethingAdded(Dictionary<Product, int> d, Product p, int n, ref int tv)
            {
                d.Add(p, n);
                tv += n * p.price;
            }
            public void HandleSomethingRemoved(Dictionary<Product, int> d, Product p, int n, ref int tv)
            {
                d.Remove(p);
                tv -= n * p.price;
            }
            public void HandleSomethingUpdated(Dictionary<Product, int> d, Product p, int n, ref int tv)
            {
                int a = d[p];
                d[p] = n;
                tv += (n-a) * p.price;
            }

            public void HandleSomethingPrice(Dictionary<Product, int> d, Product p, int n, ref int tv)
            {
                Product x = new Product(p.id, n, p.isDefective);
                int a = d[p];
                tv -= a * p.price;
                d.Remove(p);

                AddEventHandler del = new AddEventHandler(p.HandleSomethingAdded);
                del(d, x, a, ref tv);
            }

            public void HandleSomethingDefect(Dictionary<Product, int> d, Product p, int n, ref int tv)
            {
                if(n==0)
                {
                    AddEventHandler del = new AddEventHandler(p.HandleSomethingRemoved);
                    del(d, p, d[p], ref tv);
                } 
            }
        }
    }

    
}
