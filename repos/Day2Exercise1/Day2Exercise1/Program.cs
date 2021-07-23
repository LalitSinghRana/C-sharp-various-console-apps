using System;
using System.Collections.Generic;

namespace Day2Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Equipment> Inventory = new List<Equipment>();

        start : 
                Console.WriteLine("Press \t1 - Create new equipment. \t2 - Move an equipment. \t3 - Show Details. \t 0 - To exit.");
                string str = Console.ReadLine();
                if(str.Equals("1"))
                {
                    CreateNew(Inventory);
                }
                else if(str.Equals("2"))
                {
                    MoveAnEquipment(Inventory);
                }
                else if (str.Equals("3"))
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
        static void CreateNew(List<Equipment> Inventory)
        {   
            start:
                Console.Write("Select :\t 1 - Mobile Equipment. \t 2 - Immobile Equipment.\n");
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
                } else if (input.Equals("2"))
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
                else goto start;
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
                Console.Write(item.GetName()+", ");
            }
            Console.WriteLine("\nEnter a name to show complete detaile : ");
            string temp = Console.ReadLine();

            foreach (var item in Inventory)
            {
                if(temp.Equals(item.GetName()))
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
