using System;
namespace Advent2022.DayOne
{
    public static class FileReader
    {
        public static List<int> ReadFile()
        {
            string filePath = "../../../DayOne/input.txt";
            var Lines = new List<string>(System.IO.File.ReadAllLines(filePath));

            var retList = new List<int>();

            foreach (var l in Lines)
            {
                if (l.Length >0)
                {
                    retList.Add(int.Parse(l));
                }
                else
                {
                    retList.Add(0);
                }
            }

            return retList;
        }
	}
}

