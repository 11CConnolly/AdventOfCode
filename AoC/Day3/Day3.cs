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
            Console.WriteLine("part two");
            RunPart1();
            Console.WriteLine("part two");
            RunPart2();
        }

        public static void RunPart1()
        {
            string line;
            StreamReader reader = new StreamReader(@"C:\Users\cconnolly\source\repos\AoC\AoC\Day3\input.txt");

            int countRight = 0;
            int numberOfTrees = 0;

            reader.ReadLine();
            while ((line = reader.ReadLine()) != null)
            {
                if (countRight < 30)
                    countRight += 1;
                else
                    countRight -= 30;

                if (line[countRight].Equals('#'))
                    numberOfTrees++;
            }

            Console.WriteLine(numberOfTrees);
        }
        public static void RunPart2()
        {
            int LINE_LENGTH = 31;
            int[] rightMovesArray = {1, 3, 5, 7};
            long sumOfNumberOfTrees = 1;

            for (int i = 0; i < rightMovesArray.Length; i++)
            {
                string line;
                StreamReader reader = new StreamReader(@"C:\Users\cconnolly\source\repos\AoC\AoC\Day3\input.txt");

                int countRight = 0;
                int numberOfTrees = 0;

                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    if (countRight < LINE_LENGTH - rightMovesArray[i])
                        countRight += rightMovesArray[i];
                    else
                        countRight -= (LINE_LENGTH - rightMovesArray[i]);

                    if (line[countRight].Equals('#'))
                        numberOfTrees++;
                }
                sumOfNumberOfTrees *= numberOfTrees;
            }

            rightMovesArray = new int[] { 1 };
            for (int i = 0; i < rightMovesArray.Length; i++)
            {
                string line;
                StreamReader reader = new StreamReader(@"C:\Users\cconnolly\source\repos\AoC\AoC\Day3\input.txt");

                int countRight = 0;
                int numberOfTrees = 0;

                reader.ReadLine(); // 0
                while ((line = reader.ReadLine()) != null) // 1
                {
                    if ((line = reader.ReadLine()) == null)
                        break;
                    if (countRight < LINE_LENGTH - rightMovesArray[i])
                        countRight += rightMovesArray[i];
                    else
                        countRight -= (LINE_LENGTH - rightMovesArray[i]);

                    if (line[countRight].Equals('#'))
                        numberOfTrees++;
                }
                sumOfNumberOfTrees *= numberOfTrees;
            }

            Console.WriteLine(sumOfNumberOfTrees);
        }
    }
}
