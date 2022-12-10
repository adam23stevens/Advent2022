using System;
namespace Advent2022.DayTen
{
	public class FileReader
	{
        public static List<string> ReadFile()
        {
            string filePath = "../../../DayTen/input.txt";
            var retList = new List<string>(System.IO.File.ReadAllLines(filePath));

            return retList;
        }
    }
}

