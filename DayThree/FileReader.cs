using System;
namespace Advent2022.DayThree
{
	public class FileReader
	{
        public static List<string> ReadFile()
        {
            string filePath = "../../../DayThree/input.txt";
            var retList = new List<string>(System.IO.File.ReadAllLines(filePath));

            return retList;
        }
    }
}

