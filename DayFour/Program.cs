using System;
namespace Advent2022.DayFour
{
	public class Program
	{
		private static int[] ConvertLineToSections(string line)
		{
			var sections = line.Split(',');
			return new int[]
			{
				int.Parse(sections[0].Split('-')[0]),
				int.Parse(sections[0].Split('-')[1]),
				int.Parse(sections[1].Split('-')[0]),
				int.Parse(sections[1].Split('-')[1])
			};
		}

		public static string GetAnswer1()
		{
			int overlapCnt = 0;
			var lines = FileReader.ReadFile();

			foreach (var line in lines)
			{
				var sections = ConvertLineToSections(line);

                var sectionALower = sections[0];
				var sectionAHigher = sections[1];
				var sectionBLower = sections[2];
				var sectionBHigher = sections[3];

                if ((sectionALower >= sectionBLower &&
					sectionAHigher <= sectionBHigher) ||
					(sectionBLower >= sectionALower &&
					sectionBHigher <= sectionAHigher))
				{
					overlapCnt++;
				}
			}
			return overlapCnt.ToString();
		}

		public static string GetAnswer2()
		{
			int overlapCnt = 0;
			var lines = FileReader.ReadFile();

			foreach (var line in lines)
			{
				var sections = ConvertLineToSections(line);

				var sectionALower = sections[0];
				var sectionAHigher = sections[1];
				var sectionBLower = sections[2];
				var sectionBHigher = sections[3];

                if ((sectionALower >= sectionBLower && sectionALower <= sectionBHigher) ||
					(sectionAHigher >= sectionBLower && sectionAHigher <= sectionBHigher) ||
					(sectionBLower >= sectionALower && sectionBLower <= sectionAHigher) ||
					(sectionBHigher >= sectionALower && sectionBHigher <= sectionAHigher))
                {
                    overlapCnt++;
                }
            }

			return overlapCnt.ToString();
		}
	}
}

