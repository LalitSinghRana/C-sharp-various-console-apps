using System;

namespace Day2Exercise2
{
    abstract class Duck
    {
        protected enum Type
        {
            Rubber,
            Mallard,
            Redhead,
        }

        public void GetDetails()
        {
            Console.Write("\n\tName = {5}, " +
                "\n\tFly = {0}, " +
                "\n\tQuack = {1}, " +
                "\n\tType = {2}, " +
                "\n\tWeight = {3}, " +
                "\n\tNumberOfWings = {4}\n", Fly, Quack, DuckType, Weight, NoOfWings, Name);
        }
        public new string GetType()
        {
            return DuckType;
        }
        public string GetName()
        {
            return Name;
        }
        public int GetWeight()
        {
            return Weight;
        }
        public int GetNoOfWings()
        {
            return NoOfWings;
        }

        protected int Weight;
        protected int NoOfWings;
        protected string Fly;
        protected string Quack;
        protected string DuckType;
        protected string Name;
    }

    class RubberDuck : Duck
    {
        public RubberDuck(string name, int weight, int wings)
        {
            Fly = "Don't fly";
            Quack = "Squeak";
            DuckType = Type.Rubber.ToString();
            Name = name;
            Weight = weight;
            NoOfWings = wings;
        }
    }
    class MallardDuck : Duck
    {
        public MallardDuck(string name, int weight, int wings)
        {
            Fly = "Fly fast";
            Quack = "Quack loud";
            DuckType = Type.Mallard.ToString();
            Name = name;
            Weight = weight;
            NoOfWings = wings;
        }
    }
    class RedheadDuck : Duck
    {
        public RedheadDuck(string name, int weight, int wings)
        {
            Fly = "Fly slow";
            Quack = "Quack mild";
            DuckType = Type.Redhead.ToString();
            Name = name;
            Weight = weight;
            NoOfWings = wings;
        }
    }
}
