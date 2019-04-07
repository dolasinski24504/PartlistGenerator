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

            OldPartlistReader Reader = new OldPartlistReader();

            List<string> readedPartlist = Reader.Read();

            Reader.PrintReadedPartlist(readedPartlist);

            NewPartlistWritter Writter = new NewPartlistWritter();

            Writter.Write(readedPartlist);




            ////////////// 
            ///TEST

            Dictionary<string, string> prearedPartlist = new Dictionary<string, string>();

            string[] splittedList = new string[4];

            Console.WriteLine("\n");
            foreach (var item in readedPartlist)
            {
                splittedList = item.Split('\t');
                Console.WriteLine($"{splittedList[0]} - {splittedList[2]} - {splittedList[3]} ");

                prearedPartlist.Add(Convert.ToString(item[0]), Convert.ToString(item[2]));

            }


            ////TEST END
            //////////////

        }


        class OldPartlistReader
        {
            public List<string> Read()
            {
                var partlistReadPathTXT = @"C:\Users\DolaX\Desktop\Sharp\Moje\PartlistGerator\PartlistGeneratorCore\TESTPartlist.txt";
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

        class NewPartlistWritter
        {
            public void Write(List<string> finalPartlist)
            {
                var partlistWritePath = @"C:\Users\DolaX\Desktop\Sharp\Moje\PartlistGerator\PartlistGeneratorCore\NewPartlist.txt";
                File.WriteAllLines(partlistWritePath, finalPartlist);
            }
        }

        class TextConverter
        {
            public void Convert()
            {

            }
        }
    }
}
