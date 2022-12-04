using System;
namespace Advent2022.DayFour
{
    public class FileReader
    {
        public static List<string> ReadFile()
        {
            string filePath = "../../../DayFour/input.txt";
            var retList = new List<string>(System.IO.File.ReadAllLines(filePath));

            return retList;
        }
    }
}

