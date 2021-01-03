using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AoC
{
    class Day2
    {
        public static void Main(string[] args)
        {
            // Program Setup
            // TODO Write parse helper to separate class for all programs to use
            string path = @"C:\Users\cconnolly\source\repos\AoC\AoC\Day2\input.txt";
            List<string> lines = InputParseHelper(path);

            int countValid = 0;
            Regex reg = new Regex(@"(\d+)-(\d+)");

            foreach (string line in lines)
            {
                string[] splitLine = line.Split(":");
                string policy = splitLine[0];
                string password = splitLine[1];

                // Regex to match digits in first half of line
                Match match = reg.Match(policy);
                int min = int.Parse(match.Groups[1].Value);
                int max = int.Parse(match.Groups[2].Value);
                char letter = policy[policy.Length - 1];

                if (isPasswordValid(password, min, max, letter))
                    countValid++;
            }

            Console.WriteLine(countValid);
        }

        private static Boolean isPasswordValid(string password, int minValue, int maxValue, char character)
        {
            int characterCount = 0;

            foreach (char c in password)
            {
                if (c.Equals(character))
                    characterCount++;
            }

            return (minValue <= characterCount && characterCount <= maxValue);
        }

        private static List<string> InputParseHelper(string path)
        {
            List<string> lines = new List<string>();

            string line;
            StreamReader reader = new StreamReader(path);

            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines;
        }
    }
}
