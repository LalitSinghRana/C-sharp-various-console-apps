using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Day4Doc1Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<string> names = new ObservableCollection<string>();
            names.CollectionChanged += names_CollectionChanged;
            names.Add("Lalit");
            names.Add("Rana");
            names.Remove("Lalit");
            names.Add("Tarun");
            names.Add("Rahul");
            names.Remove("Rahul");
        }

        static void names_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine("Addition: “Element ‘{0}’ is added in collection”", item);
                }
            }

            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    Console.WriteLine("Removal: “Element ‘{0}’ is removed from collection”", item);
                }
            }
        }
    }
}
