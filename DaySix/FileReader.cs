using System;
namespace Advent2022.DaySix
{
    public class FileReader
    {
        public static string ReadFile()
        {
            string filePath = "../../../DaySix/input.txt";
            var retList = new List<string>(System.IO.File.ReadAllLines(filePath));

            return retList.First();
        }
    }
}

