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
                AddEventHandler del = new AddEventHandler(p.HandleAdded);
                del(d, p, rdm.Next(10), ref tv);
            }
            Console.WriteLine("\ntv after adding = {0}", tv);


            foreach (var temp in d)
            {
                if (temp.Key.id % 2 == 0)
                {
                    AddEventHandler del = new AddEventHandler(temp.Key.HandleRemoved);
                    del(d, temp.Key, temp.Value, ref tv);
                }
            }
            Console.WriteLine("\ntv after removing = {0}", tv);

            foreach (var temp in d)
            {
                if (temp.Key.id % 2 != 0)
                {
                    AddEventHandler del = new AddEventHandler(temp.Key.HandleUpdated);
                    del(d, temp.Key, rdm.Next(20), ref tv);
                }
            }
            Console.WriteLine("\ntv after updating = {0}", tv);

            foreach (var temp in d)
            {
                if (temp.Key.id % 3 == 0)
                {
                    AddEventHandler del = new AddEventHandler(temp.Key.HandlePrice);
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

            public void HandleAdded(Dictionary<Product, int> d, Product p, int n, ref int tv)
            {
                d.Add(p, n);
                tv += n * p.price;
            }
            public void HandleRemoved(Dictionary<Product, int> d, Product p, int n, ref int tv)
            {
                d.Remove(p);
                tv -= n * p.price;
            }
            public void HandleUpdated(Dictionary<Product, int> d, Product p, int n, ref int tv)
            {
                int a = d[p];
                d[p] = n;
                tv += (n-a) * p.price;
            }

            public void HandlePrice(Dictionary<Product, int> d, Product p, int n, ref int tv)
            {
                Product x = new Product(p.id, n, p.isDefective);
                int a = d[p];
                tv -= a * p.price;
                d.Remove(p);

                AddEventHandler del = new AddEventHandler(p.HandleAdded);
                del(d, x, a, ref tv);
            }

            public void HandleDefect(Dictionary<Product, int> d, Product p, int n, ref int tv)
            {
                if(n==0)
                {
                    AddEventHandler del = new AddEventHandler(p.HandleRemoved);
                    del(d, p, d[p], ref tv);
                } 
            }
        }
    }

    
}
