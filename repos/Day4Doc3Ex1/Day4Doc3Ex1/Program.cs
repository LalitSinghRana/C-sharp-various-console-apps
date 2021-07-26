using System;
using System.IO;
using System.Linq;

namespace Day4Doc3Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter diretory path :");
            var DirPath = Console.ReadLine();


            //number of text files 
            Console.WriteLine("\nNumber of text files : {0}", Directory.GetFiles(DirPath, "*.txt").Length);


            //Count number of files for all extensions
            Console.WriteLine("\nFile counts by extensions : ");
            CountExtensions(DirPath);


            //top 5 largest files
            Console.WriteLine("\n5 largest files : ");
            Top5(DirPath);


            //file with maximum length
            Console.WriteLine("\nMaximum length : ");
            MaxLen(DirPath);
        }

        public static void MaxLen(string dp)
        {
            var di = new DirectoryInfo(@dp);
            var sizeSort = di.EnumerateFiles("*", SearchOption.AllDirectories).OrderByDescending(x => x.Length).ToList();
            Console.WriteLine("\t{0} : {1}", sizeSort[0].Name, sizeSort[0].Length);
        }

        public static void Top5(string dp)
        {
            var di = new DirectoryInfo(@dp);
            var sizeSort = di.EnumerateFiles("*", SearchOption.AllDirectories).OrderByDescending(x => x.Length).ToList();
            int count = 0;
            foreach (var item in sizeSort)
            {
                Console.WriteLine("\t{0} : {1}", item.Name, item.Length);
                count++;
                if (count == 5) break;
            }
        }

        public static void CountExtensions(string dp)
        {
            var di = new DirectoryInfo(@dp);
            var extensionCounts = di.EnumerateFiles("*.*", SearchOption.AllDirectories)
                        .GroupBy(x => x.Extension)
                        .Select(g => new { Extension = g.Key, Count = g.Count() })
                        .ToList();
            foreach (var group in extensionCounts)
            {
                Console.WriteLine("\t{1} : {0}", group.Count, group.Extension);
            }
        }
    }
}
