using System;
namespace Advent2022.DayOne
{
	public static class Program
	{
        private static List<int> lines = FileReader.ReadFile();

        private static List<int> GetTotals() 
        {
            var allTotals = new List<int>();
            int calorieItem = 0;

            foreach (var line in lines)
            {
                if (line > 0)
                {
                    calorieItem += line;
                }
                else
                {
                    allTotals.Add(calorieItem);
                    calorieItem = 0;
                }
            }
            if (calorieItem > 0)
            {
                allTotals.Add(calorieItem);
            }

            return allTotals;
        }

        public static string GetAnswer1()
		{
            return GetTotals().OrderByDescending(x => x).First().ToString();
		}

		public static string GetAnswer2()
		{
            return GetTotals().OrderByDescending(x => x).Take(3).Sum().ToString();
		}
	}
}

