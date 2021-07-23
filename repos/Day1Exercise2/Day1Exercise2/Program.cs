using System;

namespace Day1Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Object.ReferenceEquals : \n\tThis only determines if the two objects passed are of same instance or not, i.e. the reference should be equal.");

            Console.WriteLine("\n\nObject.Equals : \n\tThis determine wheather the content/value of two objects passed are equal or not. The two objects can be pointing to two different locations but as long as the content/value inside both are same, it'll return true.");

            Console.WriteLine("\n\nObject.ReferenceEquals : \n\tThis determines if both the 'reference and the content/value' of both objects are equal or not.");

            Console.ReadKey();
        }
    }
}
