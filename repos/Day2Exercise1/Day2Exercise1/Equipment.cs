using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Exercise1
{
    abstract class Equipment
    {   
        public void SetName(string name)
        {
            Name = name;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetDescription(string description)
        {
            Description = description;
        }
        public string GetDescription()
        {
            return Description;
        }
        public int GetTotalDistance()
        {
            return TotalDistance;
        }
        public int GetMaintenanceCost()
        {
            return MaintenanceCost;
        }
        public new string GetType()
        {
            return MyType.ToString();
        }
        protected enum Type
        {
            Mobile,
            Immobile,
        }

        public abstract void MoveBy(int distance);
        public abstract void SetMyType();

        protected string Name;
        protected string Description;
        protected int TotalDistance = 0;
        protected int MaintenanceCost = 0;
        protected Type MyType;
    }

    class MobileEquipment : Equipment
    {
        public override void MoveBy(int distance)
        {
            TotalDistance += distance;
            MaintenanceCost += NoOfWheels * distance;
        }
        public override void SetMyType()
        {
            MyType = Type.Mobile;
        }
        public void SetNoOfWheels(int noOfWheels)
        {
            NoOfWheels = noOfWheels;
        }
        protected int NoOfWheels;
    }

    class ImmobileEquipment : Equipment
    {
        public override void MoveBy(int distance)
        {
            TotalDistance += distance;
            MaintenanceCost += Weight * distance;
        }
        public override void SetMyType()
        {
            MyType = Type.Immobile;
        }
        public void SetWeight(int weight)
        {
            Weight = weight;
        }

        protected int Weight;
    }
}
