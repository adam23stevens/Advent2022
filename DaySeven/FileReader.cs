using System;
namespace Advent2022.DaySeven
{
	public static class FileReader
	{
        public static List<string> ReadFile()
        {
            string filePath = "../../../DaySeven/input.txt";
            var retList = new List<string>(System.IO.File.ReadAllLines(filePath));

            return retList;
        }
    }
}