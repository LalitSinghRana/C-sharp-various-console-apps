using System;
using System.Globalization;

namespace Day1Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Int type
            Console.WriteLine("Enter an integer number :");
            var input = Console.ReadLine();

            int num = int.Parse(input, NumberStyles.Any);
            Console.WriteLine("Using int.Parse : " + num);

            int num2 = Convert.ToInt32(input);
            Console.WriteLine("Using Convert.ToInt : " + num2);

            int num3;
            int.TryParse(input, out num3);
            Console.WriteLine("Using int.TryParse : " + num3);

            // Float type
            Console.WriteLine("\n\nEnter an float number :");
            var FloatInput = Console.ReadLine();

            double Dnum1 = double.Parse(FloatInput, NumberStyles.Any);
            Console.WriteLine("Using double.Parse : " + Dnum1);

            double Dnum2 = Convert.ToDouble(FloatInput);
            Console.WriteLine("Using Convert.ToDouble : " + Dnum2);

            double Dnum3;
            double.TryParse(FloatInput, out Dnum3);
            Console.WriteLine("Using int.TryParse : " + Dnum3);

            // Boolean type
            Console.WriteLine("\n\nEnter an bolean value :");
            var BoolInput = Console.ReadLine();

            bool Bool1 = bool.Parse(BoolInput);
            Console.WriteLine("Using Bool.Parse : " + Bool1);

            bool Bool2 = Convert.ToBoolean(BoolInput);
            Console.WriteLine("Using Convert.ToDouble : " + Bool2);

            bool Bool3;
            bool.TryParse(BoolInput, out Bool3);
            Console.WriteLine("Using int.TryParse : " + Bool3);
        }
    }
}
