using System;
using System.Text;

namespace Advent2022.DayFive
{
	public static class FileReader
	{
		public static DayFiveFile GetFiles()
		{
            string filePath = "../../../DayFive/input.txt";
            var allLines = new List<string>(System.IO.File.ReadAllLines(filePath));
			var moveLinesIndex = allLines.IndexOf(allLines.First(x => x.Length == 0)) + 1;

			var CrateFile = new DayFiveFile();

			var crateNumbers = allLines.First(x => x[1] != null && x[1] == '1');
			var totalCrates = GetNumberOfCrates(crateNumbers);

			for(var crate = 0; crate < totalCrates; crate ++)
			{
				StringBuilder sb = new StringBuilder();
				var crateIndx = crate * 4 + 1;

				foreach(var crateString in allLines)
				{
					var crateValue = crateString[crateIndx];
					if (crateValue == ' ')
					{
						continue;
					}
					if (int.TryParse(crateValue.ToString(), out int x))
					{
						break;
					}
					sb.Append(crateValue);
				}

				CrateFile.Crates.Add(sb.ToString());
            }

			foreach(var moveLine in allLines.Skip(moveLinesIndex))
			{
				CrateFile.Actions.Add(moveLine);
			}

			return CrateFile;
        }

		private static int GetNumberOfCrates(string crateNumString)
		{
			return int.Parse(crateNumString[crateNumString.Length - 2].ToString());
		}
	}

	public class DayFiveFile
	{
		public DayFiveFile()
		{
			Crates = new List<string>();
			Actions = new List<string>();
		}
		public List<string> Crates { get; set; }
		public List<string> Actions { get; set; }
	}
}

