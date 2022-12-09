using System;
namespace Advent2022.DayEight
{
    public static class FileReader
    {
        public static List<string> ReadFile()
        {
            string filePath = "../../../DayEight/input.txt";
            var allLines = new List<string>(System.IO.File.ReadAllLines(filePath));

            return allLines;
        }
    }
}

