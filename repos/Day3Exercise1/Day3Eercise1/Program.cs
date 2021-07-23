using Day3Eercise1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Equipment> Inventory = new List<Equipment>();

        start:
            Console.WriteLine("\nSelect :" +
                "\n\t1 - Create new equipment. " +
                "\n\t2 - Move an equipment. " +
                "\n\t3 - Show list and details. " +
                "\n\t4 - Delete options. " +
                "\n\t0 - To exit.");
            string str = Console.ReadLine();
            if (str.Equals("1"))
            {
                CreateNew(Inventory);
            }
            else if (str.Equals("2"))
            {
                MoveAnEquipment(Inventory);
            }
            else if (str.Equals("3"))
            {
                ShowList(Inventory);
            }
            else if (str.Equals("4"))
            {
                DeleteOptions(Inventory);
            }
            else if (str.Equals("0"))
            {
                goto end;
            }
            else
            {
                Console.WriteLine("Eroor : Invalid input");
            }
            goto start;

        end:;
        }

        private static void DeleteOptions(List<Equipment> Inventory)
        {
        start:
            Console.WriteLine("Press : " +
                "\n\t1 - Delete all. " +
                "\n\t2 - Delete all mobile. " +
                "\n\t3 - Delete all immobile. " +
                "\n\t4 - Delete one. " +
                "\n\t0 - To exit.");
            string str = Console.ReadLine();

            if(str.Equals("1"))
            {
                Inventory.Clear();
                Console.WriteLine("\nAll items deleted.");
            }
            else if (str.Equals("2"))
            {
                for(int i = Inventory.Count - 1; i>=0; i--)
                {
                    if(Inventory.ElementAt(i).GetType().ToString().Equals("Mobile"))
                    {
                        Inventory.RemoveAt(i);
                    }
                }
                Console.WriteLine("\nAll Mobile items deleted.");
            }
            else if (str.Equals("3"))
            {
                for (int i = Inventory.Count - 1; i >= 0; i--)
                {
                    if (Inventory.ElementAt(i).GetType().ToString().Equals("Immobile"))
                    {
                        Inventory.RemoveAt(i);
                    }
                }
                Console.WriteLine("\nAll Immobile items deleted.");
            }
            else if (str.Equals("4"))
            {
                DeleteEquipment(Inventory);
            }
            else if (str.Equals("0"))
            {
                goto end;
            }
            else
            {
                Console.WriteLine("Eroor : Invalid input");  
            }
            goto start;

        end:;
        }

        private static void ShowList(List<Equipment> Inventory)
        {
            start:
            Console.WriteLine("Press : " +
                "\n\t1 - To list all. " +
                "\n\t2 - to list all mobile. " +
                "\n\t3 - to list all immobile. " +
                "\n\t4 - List all equipment that have not been moved " +
                "\n\t5 - Show all details of an equipment. " +
                "\n\t0 - To exit.");
            string str = Console.ReadLine();

            if(str.Equals("1"))
            {
                if (Inventory.Count == 0) Console.WriteLine("\nInventory empty");
                else
                {
                    foreach (var item in Inventory)
                    {
                        Console.WriteLine("\tName : " + item.GetName() + ", Description: " + item.GetDescription());
                    }
                }
            }
            else if (str.Equals("2"))
            { 
                foreach (var item in Inventory.Where(x => x.GetType().ToString().Equals("Mobile")))
                {
                    Console.WriteLine("\tName : " + item.GetName() + ", Description: " + item.GetDescription());
                }
            }
            else if(str.Equals("3"))
            {
                foreach (var item in Inventory.Where(x => x.GetType().ToString().Equals("Immobile")))
                {
                    Console.WriteLine("\tName : " + item.GetName() + ", Description: " + item.GetDescription());
                }
            }
            else if (str.Equals("4"))
            {
                foreach (var item in Inventory.Where(x => x.GetTotalDistance() == 0))
                {
                    Console.WriteLine("\tName : " + item.GetName() + ", Total distance: " + item.GetTotalDistance());
                }
            }
            else if(str.Equals("5"))
            {
                ShowDetails(Inventory);
            }
            else if (str.Equals("0"))
            {
                goto end;
            }
            else
            {
                Console.WriteLine("Eroor : Invalid input");  
            }
            goto start;
        end:;
        }

        private static void DeleteEquipment(List<Equipment> Inventory)
        {
            Console.WriteLine("List of all Equipments : ");
            foreach (var item in Inventory)
            {
                Console.Write(item.GetName() + ", ");
            }
            Console.WriteLine("\nEnter a name to delete : ");
            string temp = Console.ReadLine();

            foreach (var item in Inventory)
            {
                if (temp.Equals(item.GetName()))
                {
                    Inventory.Remove(item);
                    Console.WriteLine("\nItem deleted.");
                    break;
                }
            }
        }

        static void CreateNew(List<Equipment> Inventory)
        {
        start:
            Console.Write("Select :" +
                "\n\t1 - Mobile Equipment. " +
                "\n\t2 - Immobile Equipment." +
                "\n\t0 - To exit.\n");
            string input = Console.ReadLine();

            if (input.Equals("1"))
            {
                MobileEquipment tempMobile = new MobileEquipment();


                Console.Write("Enter Name : ");
                string str = Console.ReadLine();
                tempMobile.SetName(str);

                Console.Write("\nEnter description : ");
                str = Console.ReadLine();
                tempMobile.SetDescription(str);

                Console.Write("\nEnter no of wheels : ");
                str = Console.ReadLine();
                tempMobile.SetNoOfWheels(int.Parse(str));

                tempMobile.SetMyType();

                Inventory.Add(tempMobile);
            }
            else if (input.Equals("2"))
            {
                ImmobileEquipment tempImmobile = new ImmobileEquipment();


                Console.Write("Enter Name : ");
                string str = Console.ReadLine();
                tempImmobile.SetName(str);

                Console.Write("\nEnter description : ");
                str = Console.ReadLine();
                tempImmobile.SetDescription(str);

                Console.Write("\nEnter weight : ");
                str = Console.ReadLine();
                tempImmobile.SetWeight(int.Parse(str));

                tempImmobile.SetMyType();

                Inventory.Add(tempImmobile);
            }
            else if (input.Equals("0"))
            {
                goto end;
            }
            else
            {
                Console.WriteLine("Eroor : Invalid input");
            }
            goto start;
        end:;
        }
        static void MoveAnEquipment(List<Equipment> Inventory)
        {
            Console.WriteLine("List of all Equipments : ");
            foreach (var item in Inventory)
            {
                Console.Write(item.GetName() + ", ");
            }
            Console.WriteLine("\nEnter a name to move it : ");
            string temp = Console.ReadLine();
            Console.WriteLine("\nEnter distance : ");
            string tempD = Console.ReadLine();

            foreach (var item in Inventory)
            {
                if (temp.Equals(item.GetName()))
                {
                    item.MoveBy(int.Parse(tempD));
                    Console.WriteLine("\n\t{0} moved by {1} distance.", temp, tempD);
                    break;
                }
            }

        }

        static void ShowDetails(List<Equipment> Inventory)
        {
            Console.WriteLine("List of all Equipments : ");
            foreach (var item in Inventory)
            {
                Console.Write(item.GetName() + ", ");
            }
            Console.WriteLine("\nEnter a name to show complete detaile : ");
            string temp = Console.ReadLine();

            foreach (var item in Inventory)
            {
                if (temp.Equals(item.GetName()))
                {
                    Console.WriteLine("\tName : " + item.GetName());
                    Console.WriteLine("\tDescription : " + item.GetDescription());
                    Console.WriteLine("\tTotal Distance : " + item.GetTotalDistance());
                    Console.WriteLine("\tMaintenace Cost : " + item.GetMaintenanceCost());
                    Console.WriteLine("\tType is : " + item.GetType());
                    break;
                }
            }
        }
    }
}

