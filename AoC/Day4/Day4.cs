using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AoC
{
    class Day4
    {
        public static void Main(string[] args)
        {
            string[] validFields = {
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid"
            };

            Console.WriteLine("part two");
            RunPart1(validFields);
            Console.WriteLine("part two");
            RunPart2();
        }

        public static void RunPart1(string[] validFields)
        {
            string line;
            StreamReader reader = new StreamReader(@"C:\Users\cconnolly\source\repos\AoC\AoC\Day4\input.txt");

            int countValidPassports = 0;

            Regex regex = new Regex(@"([a-zA-Z]{3}):");

            // For each document in the input
            while ((line = reader.ReadLine()) != null)
            {
                List<string> fields = new List<string>();
                // Bulid up a list of all the matches in the passport
                while (line != String.Empty)
                {
                    foreach (Match match in regex.Matches(line))
                    {
                        if (match.Value != "cid:")
                            fields.Add(match.Value);
                    }

                    if ((line = reader.ReadLine()) == null)
                        break;
                }
                if (fields.Count >= validFields.Length)
                    countValidPassports++;
            }

            Console.WriteLine("Valid Passports count is: {0}", countValidPassports);

        }

        public static void RunPart2()
        {

        }
    }
}
