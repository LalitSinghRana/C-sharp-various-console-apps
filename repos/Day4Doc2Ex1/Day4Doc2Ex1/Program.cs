using System;

namespace Day4Doc2Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 17;

            bool result = i.IsOdd();
            Console.WriteLine(result);

            result = i.IsEven();
            Console.WriteLine(result);

            result = i.IsPrime();
            Console.WriteLine(result);

            result = i.IsDivisibleBy(3);
            Console.WriteLine(result);
        }
    }

    public static class IntExtensions
    {
        public static bool IsOdd(this int i)
        {
            return i%2 !=0 ;
        }
        public static bool IsEven(this int i)
        {
            return i % 2 == 0;
        }

        public static bool IsPrime(this int i)
        {
            if (i <= 1) return false;
            if (i == 2) return true;
            if (i % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(i));

            for (int j = 3; j <= boundary; j += 2) if (i % j == 0) return false;

            return true;
        }

        public static bool IsDivisibleBy(this int i, int value)
        {
            return i%value == 0;
        }
    }
}
