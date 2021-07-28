using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4Doc2Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<int> list = new List<int> { -4, -2, 2, 4, 6, };

            var temp = list.CustomAll(x => x%2==0);
            Console.Write("Custom All result : {0}\n", temp);

            temp = list.CustomAny(x => x == 0);
            Console.Write("Custom All result : {0}\n", temp);

            var temp2 = list.CustomMax();
            Console.Write("Custom max result : {0}\n", temp2);

            temp2 = list.CustomMin();
            Console.Write("Custom min result : {0}\n", temp2);

            var temp3 = list.CustomWhere(x => x < 0);
            Console.Write("Custom All result :");
            foreach (var x in temp3) Console.Write(x+", ");

            temp3 = list.CustomSelect(x => x*x*x);
            Console.Write("\nCustom All result :");
            foreach (var x in temp3) Console.Write(x + ", ");
        }
        
    }

    public static class CustomExtension
    {
        public static IEnumerable<T> CustomSelect<T>(this IEnumerable<T> data, Func<T, T> func)
        {
            foreach (T value in data)
            {
                yield return func(value);
            }
        }
        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> data, Func<T, bool> func)
        {
            foreach (T value in data)
            {
                if (func(value)) yield return value;
            }
        }
        public static T CustomMin<T>(this IEnumerable<T> data)
        {
            //can write cases for all types like linq.Min does. So using it.
            return data.Min();
        }
        public static T CustomMax<T>(this IEnumerable<T> data)
        {
            //can write cases for all types like linq.Max does. So using it.
            return data.Max();
        }
        public static bool CustomAny<T>(this IEnumerable<T> data, Func<T, bool> func)
        {
            foreach (T value in data)
            {
                if (func(value)) return true;
            }
            return false;
        }
        public static bool CustomAll<T>(this IEnumerable<T> data, Func<T, bool> func)
        {
            foreach (T value in data)
            {
                if (!func(value)) return false;
            }
            return true;
        }
    }


}
