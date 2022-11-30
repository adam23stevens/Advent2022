using System;
namespace Advent2022.DayOne
{
    public static class FileReader
    {
        public static List<int> ReadFile()
        {
            string filePath = "../../../DayOne/test.txt";
            var Lines = new List<string>(System.IO.File.ReadAllLines(filePath));

            var retList = new List<int>();

            foreach (var l in Lines)
            {
                retList.Add(int.Parse(l));
            }

            return retList;
        }
	}
}

