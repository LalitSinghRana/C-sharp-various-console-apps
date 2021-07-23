using System;
using System.Collections.Generic;

namespace Day3Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Duck> MyList = new List<Duck>();
        start:
            Console.WriteLine("Select : " +
                "\n\t1 - Add a duck. " +
                "\n\t2 - Show details of a duck. " +
                "\n\t3 - Remove options" +
                "\n\t4 - Iteration options" +
                "\n\t0 - To Exit.\n");
            string Input1 = Console.ReadLine();

            if (Input1.Equals("1"))
            {
                CreateDuck(MyList);
            }
            else if (Input1.Equals("2"))
            {
                ShowDetails(MyList);
            }
            else if (Input1.Equals("3"))
            {
                RemoveOptions(MyList);
            }
            else if (Input1.Equals("4"))
            {
                IterationOptions(MyList);
            }
            else if (Input1.Equals("0"))
            {
                goto end;
            }
            goto start;

        end:;
        }

        private static void IterationOptions(List<Duck> MyList)
        {
        start:
            Console.WriteLine("Select : " +
                "\n\t1 - Descending weight order" +
                "\n\t2 - Incresing number of wings order" +
                "\n\t0 - To Exit.\n");

            string DuckType = Console.ReadLine();

            if (DuckType.Equals("1"))
            {
                if(MyList.Count == 0) Console.WriteLine("\n\tDatabase is empty.");
                else foreach (var duck in MyList) Console.WriteLine("\t"+duck.GetName()+" : "+duck.GetWeight()+"\n");
            }
            else if (DuckType.Equals("2"))
            {
                if (MyList.Count == 0) Console.WriteLine("\n\tDatabase is empty.");
                else { 
                    MyList.Sort((x, y) => x.GetNoOfWings().CompareTo(y.GetNoOfWings()));
                    foreach (var duck in MyList) Console.WriteLine("\t" + duck.GetName() + " : " + duck.GetNoOfWings() + "\n");
                }
            }
            else if (DuckType.Equals("0"))
            {
                goto end;
            }
            else
            {
                Console.WriteLine("\nError : Invalid input.");
            }
            goto start;
        end:;
        }

        private static void RemoveOptions(List<Duck> MyList)
        {
        start:
            Console.WriteLine("Select : " +
                "\n\t1 - Remove a duck" +
                "\n\t2 - Delete all" +
                "\n\t0 - To Exit.\n");

            string DuckType = Console.ReadLine();

            if (DuckType.Equals("1"))
            {
                Console.WriteLine("Enter a name : ");
                string str = Console.ReadLine();

                for(int i = MyList.Count - 1; i>=0; i--)
                {
                    if (MyList[i].GetName().Equals(str)) {
                        MyList.RemoveAt(i);
                        Console.WriteLine("Duck removed.");
                        break;
                    }
                    if (i == 0) Console.WriteLine("No suck with that name");
                }
            }
            else if (DuckType.Equals("2"))
            {
                MyList.Clear();
            }
            else if (DuckType.Equals("0"))
            {
                goto end;
            }
            else
            {
                Console.WriteLine("\nError : Invalid input.");
            }
            goto start;
        end:;
        }

        static void CreateDuck(List<Duck> MyList)
        {
        start:
            Console.WriteLine("Select duck type : " +
                "\n\t1 - Rubber duck." +
                "\n\t2 - Mallard duck. " +
                "\n\t3 - Redhead duck." +
                "\n\t0 - To Exit.\n");
            string DuckType = Console.ReadLine();


            if (DuckType.Equals("1"))
            {
                Console.WriteLine("Enter name : ");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter weignt : ");
                int Weight = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter number of wings : ");
                int Wings = int.Parse(Console.ReadLine());

                RubberDuck temp = new RubberDuck(Name, Weight, Wings);
                MyList.Add(temp);
                MyList.Sort((x, y) => y.GetWeight().CompareTo(x.GetWeight()));
            }
            else if (DuckType.Equals("2"))
            {
                Console.WriteLine("Enter name : ");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter weignt : ");
                int Weight = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter number of wings : ");
                int Wings = int.Parse(Console.ReadLine());

                MallardDuck temp = new MallardDuck(Name, Weight, Wings);
                MyList.Add(temp);
                MyList.Sort((x, y) => y.GetWeight().CompareTo(x.GetWeight()));
            }
            else if (DuckType.Equals("3"))
            {
                Console.WriteLine("Enter name : ");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter weignt : ");
                int Weight = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter number of wings : ");
                int Wings = int.Parse(Console.ReadLine());

                RedheadDuck temp = new RedheadDuck(Name, Weight, Wings);
                MyList.Add(temp);
                MyList.Sort((x, y) => y.GetWeight().CompareTo(x.GetWeight()));
            }
            else if (DuckType.Equals("0"))
            {
                goto end;
            }
            else
            {
                Console.WriteLine("\nError : Invalid input.");
            }
            goto start;
        end:;
        }

        static void ShowDetails(List<Duck> MyList)
        {
            if (MyList.Count == 0) Console.WriteLine("\n\tDatabase is empty.");
            else
            {
                foreach (var duck in MyList) Console.Write(duck.GetName() + ", ");
                Console.WriteLine("\nSelect a name : ");
                string name = Console.ReadLine();

                foreach (var duck in MyList)
                {
                    if(duck.GetName().Equals(name))
                    {
                        duck.GetDetails();
                        break;
                    }
                }
            }
        }
    }
}
