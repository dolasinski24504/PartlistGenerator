using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PartlistGeneratorCore
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Partlist Generator\n");

            OldPartlistLoader Reader = new OldPartlistLoader();
            List<string> readedPartlist = Reader.Read();
            Reader.PrintReadedPartlist(readedPartlist);

            PartListPreparer Preparer = new PartListPreparer();
            Preparer.PreparePartlist(readedPartlist);

            List<string> finalPartlist = Preparer.PreparePartlist(readedPartlist);
            NewPartlistExporter Exporter = new NewPartlistExporter();
            Exporter.ExportToTXT(finalPartlist);
        }
    }

    class OldPartlistLoader
    {
        public List<string> Read()
        {
            var partlistReadPathTXT = @"C:\Users\DolaX\Desktop\Sharp\Moje\PartlistGerator\PartlistGeneratorCore\Partlist.txt";
            var partlistReadPathEXCEL = @"C:\Users\DolaX\Desktop\Sharp\Moje\PartlistGerator\PartlistGeneratorCore\Partlist.xlsx";

            List<string> loadedPartlistTXT = File.ReadAllLines(partlistReadPathTXT).ToList();
            List<string> loadedPartlistEXCEL = File.ReadAllLines(partlistReadPathEXCEL).ToList();

            return loadedPartlistTXT;
        }

        public void PrintReadedPartlist(List<string> Partlist)
        {
            foreach (var line in Partlist)
            {
                Console.WriteLine(line);
            }
        }
    }

    class NewPartlistExporter
    {
        public void ExportToTXT(List<string> finalPartlist)
        {
            var partlistWritePath = @"C:\Users\DolaX\Desktop\Sharp\Moje\PartlistGerator\PartlistGeneratorCore\NewPartlist.txt";
            File.WriteAllLines(partlistWritePath, finalPartlist);
        }
    }

    class PartListPreparer
    {
        public List<string> PreparePartlist(List<string> readedPartlist)
        {
            List<string> choosenParts = new List<string>();
            choosenParts.Add("Pos\tBOM Component\tQuantity");

            List<string> allPartNumbers = new List<string>();

            List<string> choosenPartNumber = new List<string>();

            choosenPartNumber.Add("031");
            choosenPartNumber.Add("001");
            choosenPartNumber.Add("020");
            choosenPartNumber.Add("061");
            choosenPartNumber.Add("101");
            choosenPartNumber.Add("160");
            choosenPartNumber.Add("320");
            choosenPartNumber.Add("305");
            choosenPartNumber.Add("301");
            choosenPartNumber.Add("1200");
            choosenPartNumber.Add("666");

            string[] splittedList = new string[4];

            foreach (var item in readedPartlist)
            {
                splittedList = item.Split('\t');

                if (choosenPartNumber.Contains(splittedList[0]))
                {
                    choosenParts.Add($"{splittedList[0]}\t{splittedList[2]}\t{splittedList[3]}");
                    allPartNumbers.Add($"{splittedList[0]}");
                }
            }

            foreach (var item in choosenPartNumber)
            {
                if (!allPartNumbers.Contains(item))
                {
                    choosenParts.Add($"{item} is not on primal partlist!!!");
                }
            }

            return choosenParts;
        }
    }
}

