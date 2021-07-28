using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4Doc1Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<int> myList = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //Odd numbers
            var temp1 = myList.Where(x => x % 2 != 0);
            foreach (var num in temp1) Console.Write(num + ", ");
            Console.WriteLine("\n");


            //Even numbers
            var temp2 = myList.Where(x => {
                return x % 2 == 0;
                });
            foreach (var num in temp2) Console.Write(num + ", ");
            Console.WriteLine("\n");


            //Prime numbers
            Func<int, bool> isPrime = delegate (int number)
                 {
                     if (number <= 1) return false;
                     if (number == 2) return true;

                     var limit = Math.Ceiling(Math.Sqrt(number));

                    for (int i = 2; i <= limit; ++i)
                         if (number % i == 0)
                             return false;
                     return true;

                 };
            foreach (var num in myList) if(isPrime(num)) Console.Write(num+", ");
            Console.WriteLine("\n");


            //Prime number lambda
            Func<int, bool> isPrime2 = number =>
                 {
                if (number <= 1) return false;
                if (number == 2) return true;

                var limit = Math.Ceiling(Math.Sqrt(number));

                for (int i = 2; i <= limit; ++i)
                    if (number % i == 0)
                        return false;
                return true;

            };
            foreach (var num in myList) if (isPrime2(num)) Console.Write(num + ", ");
            Console.WriteLine("\n");


            //Grater than 5
            bool GreaterThan5(int x) => x > 5;
            Func<int, bool> funcGreat = GreaterThan5;
            var greaterThan5List = myList.Where(funcGreat);
            foreach (var num in greaterThan5List) Console.Write(num + ", ");
            Console.WriteLine("\n");


            //Less than 5
            bool LessThan5(int x) => x < 5;
            Func<int, bool> funcLess = new Func<int, bool>(LessThan5);
            var lessThan5List = myList.Where(funcLess);
            foreach (var num in lessThan5List) Console.Write(num + ", ");
            Console.WriteLine("\n");


            //find 3k
            Func<int, bool> func3k = new Func<int, bool>(x => x%3==0);
            var find3kList = myList.Where(func3k);
            foreach (var num in find3kList) Console.Write(num + ", ");
            Console.WriteLine("\n");


            //find 3k+1
            Func<int, bool> func3k1 = delegate (int x) { return x % 3 == 1; };
            var find3k1List = myList.Where(func3k1);
            foreach (var num in find3k1List) Console.Write(num + ", ");
            Console.WriteLine("\n");


            //find 3k+2
            var find3k2List = myList.Where(x => x % 3 == 2);
            foreach (var num in find3k2List) Console.Write(num + ", ");
            Console.WriteLine("\n");


            //find Anything
            var findAnyList = myList.Where(delegate (int x) { return x != 0; });
            foreach (var num in findAnyList) Console.Write(num + ", ");
            Console.WriteLine("\n");


            //find Anything 2
            bool FindAny(int x) => x != 5;
            var findAnyList2 = myList.Where(FindAny);
            foreach (var num in findAnyList2) Console.Write(num + ", ");
            Console.WriteLine("\n");
        }
    }
}