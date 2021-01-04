using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AoC
{
    class Day2
    {
        /*
         * Learned from this Challenge
         * Regex uses the Match keyword and requies an absolute string for the pattern
         * From a match, you can use match.Groups[0] for all groups captures, or subsequent match.Groups[1] for indivdual captured groups
         * A capture group is anything surrounded by ()
         * 
         * Streamreaders are used as IO for basic C# applications
         * whlie ((line = reader.ReadLine()) != null) is the basic structure for reading line by line
         * 
         * Can use [^1] to reference item of index Length - 1
         * 
         * Watch for off by one errors :( rubber duck debug them
         * 
         * C# Naming Convention is to start methods as Upper Case
         * Use Ctrl + R, Ctrl + R to rename quickly
         */
        public static void Main(string[] args)
        {
            // Program Setup
            // TODO Write parse helper to separate class for all programs to use
            string path = @"C:\Users\cconnolly\source\repos\AoC\AoC\Day2\input.txt";
            List<string> lines = InputParseHelper(path);

            RunPart1(lines);
            RunPart2(lines);
        }

        private static void RunPart1(List<string> lines)
        {
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

                if (IsPasswordValidPart1(password, min, max, letter))
                    countValid++;
            }

            Console.WriteLine("Number of valid passwords for part 1: " + countValid);
        }

        private static Boolean IsPasswordValidPart1(string password, int minValue, int maxValue, char character)
        {
            int characterCount = 0;

            foreach (char c in password)
            {
                if (c.Equals(character))
                    characterCount++;
            }

            return (minValue <= characterCount && characterCount <= maxValue);
        }

        private static void RunPart2(List<string> lines) 
        {
            int countValid = 0;
            Regex reg = new Regex(@"(\d+)-(\d+)");

            foreach (string line in lines)
            {
                string[] splitLine = line.Split(":");
                string policy = splitLine[0];
                string password = splitLine[1];

                // Regex to match digits in first half of line
                Match match = reg.Match(policy);
                int pos1 = int.Parse(match.Groups[1].Value);
                int pos2 = int.Parse(match.Groups[2].Value);
                char letter = policy[^1];

                if (password[pos1].Equals(letter) ^ password[pos2].Equals(letter))
                    countValid++;
            }

            Console.WriteLine("Number of valid passwords for part 2: " + countValid);
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
