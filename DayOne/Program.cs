using System;
namespace Advent2022.DayOne
{
	public static class Program
	{
		public static string GetAnswer1()
		{
			var lines = FileReader.ReadFile();
			return lines.Sum().ToString();
		}
	}
}

