using System;

namespace Day1Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input two positive non-equal integers (between 2 and 1000). First number entered should be smaller than second number.");

            TakingInputs: 
                Console.WriteLine("\nEnter the smaller integer : ");
                string FirstInput = Console.ReadLine();
                Console.WriteLine("Enter the smaller integer : ");
                string SecondInput = Console.ReadLine();


            int SmallNum = int.Parse(FirstInput);
            int LargeNum = int.Parse(SecondInput);
            if(SmallNum > LargeNum)
            {
                Console.WriteLine("\nError : First input is larger than second input. Please try again :");
                goto TakingInputs;
            }else if( SmallNum == LargeNum)
            {
                Console.WriteLine("\nError : The two input are equal. Please try again : ");
                goto TakingInputs;
            }else
            {
                for (int i = SmallNum; i <= LargeNum; i++)
                {
                    int counter = 0;
                    for (int j = 2; j <= i / 2; j++)
                    {
                        if (i % j == 0)
                        {
                            counter++;
                            break;
                        }
                    }

                    if (counter == 0 && i != 1)
                    {
                        Console.Write("{0} ", i);
                    }
                }
            }
        }
    }
}
