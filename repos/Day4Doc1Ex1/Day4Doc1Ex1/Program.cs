using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4Doc1Ex1
{
    class Program
    {
        public delegate void Print(int value);
        public delegate bool greaterThanFiveDelegate(int value);
        public delegate bool find3kDelegate(int value);
        public delegate bool find3k1Delegate(int value);
        public delegate bool find3k2Delegate(int value);

        public static bool greaterThanFive(int value)
        {
            return value > 5;
        }
        public static bool find3k(int value)
        {
            if (value%3 == 0) return true;
            else return false;
        }
        public static bool find3k2(int value)
        {
            if (value % 3 == 2) return true;
            else return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<int> myList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var temp = myList.Where(x => x==x);

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
            Print prnt = delegate (int val) {
                Console.Write(val + ", ");
            };
            foreach (var num in myList) if(num==2 || num==3 || num==5 || num==7)prnt(num);
            Console.WriteLine("\n");

            //Prime number lambda
            Print prnt2 = val => Console.Write(val + ", ");
            foreach (var num in myList) if (num == 2 || num == 3 || num == 5 || num == 7) prnt2(num);
            Console.WriteLine("\n");

            //Grater than 5
            greaterThanFiveDelegate del = greaterThanFive;
            //del = new greaterThanFiveDelegate(greaterThanFive);
            foreach (var num in myList)
            {
                bool myBool = del(num);
                if(myBool) Console.Write(num + ", ");
            }
            Console.WriteLine("\n");

            //Grater than 5 another
            var temp3 = myList.Where(x => {
                greaterThanFiveDelegate delTemp = greaterThanFive;
                return delTemp(x);
            });
            foreach (var num in temp3) Console.Write(num + ", ");
            Console.WriteLine("\n");

            //find 3k
            find3kDelegate del2 = find3k;
            var temp4 = myList.Where(x => del2(x));
            foreach (var num in temp4) Console.Write(num + ", ");
            Console.WriteLine("\n");

            //find 3k+1
            find3k1Delegate del3 = delegate (int val) {
                if (val % 3 == 1) return true;
                else return false;
            };
            var temp5 = myList.Where(x => del3(x));
            foreach (var num in temp5) Console.Write(num + ", ");
            Console.WriteLine("\n");

            //find 3k+2
            var temp6 = myList.Where(x => x%3==2);
            foreach (var num in temp6) Console.Write(num + ", ");
            Console.WriteLine("\n");
        }
    }
}

//bool LesserThan5(int num) => num < 5;
//Func<int, bool> func2 = new Func<int, bool>(LesserThan5);
//var temp4 = myList.Where(func2);
//foreach (var num in temp4) Console.Write(num + ", ");
//Console.WriteLine("\n");