using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AoC
{
    public class FileReaderHelper
    {
        private string filePath;

        public FileReaderHelper(string path)
        {
            filePath = path;
        }

        public List<string> readAllLinesFromFile()
        {
            List<string> lines = new List<string>();

            string line;
            StreamReader reader = new StreamReader(filePath);

            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines;
        }
    }
}
