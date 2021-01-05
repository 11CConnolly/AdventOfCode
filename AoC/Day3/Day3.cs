using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AoC
{
    class Day3
    {
        public static void Main(string[] args)
        {
            runPart1();
        }

        public static void runPart1()
        {
            List<string> lines = new List<string>();

            string line;
            StreamReader reader = new StreamReader(@"C:\Users\cconnolly\source\repos\AoC\AoC\Day3\input.txt");

            int countRight = 0;
            int numberOfTrees = 0;

            reader.ReadLine();
            while ((line = reader.ReadLine()) != null)
            {
                if (countRight < 28)
                    countRight += 3;
                else
                    countRight -= 28;

                if (line[countRight].Equals('#'))
                    numberOfTrees++;

            }

            Console.WriteLine(numberOfTrees);
        }
    }
}
