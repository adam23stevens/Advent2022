using System;
namespace Advent2022.DayNine
{
	public class FileReader
	{
        public static List<string> ReadFile()
        {
            string filePath = "../../../DayNine/input.txt";
            var retList = new List<string>(System.IO.File.ReadAllLines(filePath));

            return retList;
        }
    }
}

