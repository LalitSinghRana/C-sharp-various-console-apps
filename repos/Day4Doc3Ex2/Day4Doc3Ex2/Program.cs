using System;

namespace Day4Doc3Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
        start:
            Console.WriteLine("Enter any number from 1-5 :");
            var input = int.Parse(Console.ReadLine(), System.Globalization.NumberStyles.Any);
            try
            {
                if(count == 5) throw new CustomException("You've played this game 5 time");

                if(input == 1)
                {
                    Console.WriteLine("Enter even number :");
                    var input2 = int.Parse(Console.ReadLine(), System.Globalization.NumberStyles.Any);
                    if (input2 % 2 == 0) Console.WriteLine("Success!!!!");
                    else throw new CustomException("Not an even integer");
                }
                else if (input == 2)
                {
                    Console.WriteLine("Enter odd number :");
                    var input2 = int.Parse(Console.ReadLine(), System.Globalization.NumberStyles.Any);
                    if (input2 % 2 != 0) Console.WriteLine("Success!!!!");
                    else throw new CustomException("Not an odd integer");
                }
                else if (input == 3)
                {
                    Console.WriteLine("Enter a prime number :");
                    var input2 = int.Parse(Console.ReadLine(), System.Globalization.NumberStyles.Any);
                    if (isPrime(input2)) Console.WriteLine("Success!!!!");
                    else throw new CustomException("Not a prime integer");
                }
                else if (input == 4)
                {
                    Console.WriteLine("Enter a negative number :");
                    var input2 = int.Parse(Console.ReadLine(), System.Globalization.NumberStyles.Any);
                    if (input2 < 0) Console.WriteLine("Success!!!!");
                    else throw new CustomException("Not a negative integer");
                }
                else if (input == 5)
                {
                    Console.WriteLine("Enter zero :");
                    var input2 = int.Parse(Console.ReadLine(), System.Globalization.NumberStyles.Any);
                    if (input2 == 0) Console.WriteLine("Success!!!!");
                    else throw new CustomException("{input2} is not zero");
                }
                else
                {
                    throw new CustomException("Error : Invalid input");
                }
            }catch(CustomException e)
            {
                Console.WriteLine(e);
            }
            count++;

            goto start;
        }

        public static bool isPrime(int i)
        {
            if (i <= 1) return false;
            if (i == 2) return true;
            if (i % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(i));

            for (int j = 3; j <= boundary; j += 2) if (i % j == 0) return false;

            return true;
        }
    }

    public class CustomException : Exception
    {
        public CustomException(string msg) : base(msg) { }
    }
}
