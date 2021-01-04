using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace AoC
{
    class Day1
    {
        /*
         * Learned from this Challenge
         * Use System.Diagnostics.Stopwatch to measure program exeuction time
         * sw.Start(), sw.Stop(), sw.Elapsed()
         */
        public static void Main(string[] args)
        {
            // Will need to change this path depending on where the program is running
            string path = @"C:\Users\cconnolly\source\repos\AoC\AoC\Day1\input.txt";

            List<int> values = ParseHelper(path);

            int result1, result2;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            result1 = SumTwoTo2020(values);
            result2 = SumThreeTo2020(values);

            sw.Stop();

            Console.WriteLine("result for part 1 is {0}, for part 2 is {1} completed in {2}ms", result1, result2, sw.ElapsedTicks);
        }

        // Answer is 969024
        private static int SumTwoTo2020
            (List<int> values)
        {
            int a, b;

            for (int i = 0; i < values.Count; i++)
            {
                a = values[i];
                for (int j = 0; j < values.Count; j++)
                {
                    b = values[j];
                    if (a + b == 2020)
                        return a * b;
                }
            }

            return -1;
        }

        // Answer is 230057040
        private static int SumThreeTo2020
            (List<int> values)
        {
            int a, b, c;

            for (int i = 0; i < values.Count - 2; i++)
            {
                a = values[i];
                for (int j = i + 1; j < values.Count - 1; j++)
                {
                    b = values[j];
                    for (int k = j + 1; k < values.Count; k++)
                    {
                        c = values[k];
                        if (a + b + c == 2020)
                            return a * b * c;
                    }

                }
                values.RemoveAt(i);
            }

            return -1;
        }

        private static List<int> ParseHelper (string path)
        {
            string line;
            List<int> values = new List<int>();

            System.IO.StreamReader reader = new System.IO.StreamReader(path);
            while ((line = reader.ReadLine()) != null)
            {
                values.Add(int.Parse(line));
            }

            return values;
        }

    }
}
