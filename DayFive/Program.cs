using System;
using System.Text;

namespace Advent2022.DayFive
{
	public class Program
	{
		public static string GetAnswer1()
		{
            return MoveCrate(true);
		}

		public static string GetAnswer2()
		{
            return MoveCrate(false);
		}

		private static string MoveCrate(bool moveOneCrateAtATime)
		{
            var answer = "answer";
            var crateFile = FileReader.GetFiles();

            foreach (var action in crateFile.Actions)
            {
                var movements = action.Split(' ');
                var crateAmt = int.Parse(movements[1]);
                var crateFrom = int.Parse(movements[3]);
                var crateTo = int.Parse(movements[5]);

                var oldCrateFromStr = crateFile.Crates.Skip(crateFrom - 1).First();
                if (oldCrateFromStr.Length < crateAmt)
                {
                    var error = "ERROR";
                }

                var newCrateFrom = oldCrateFromStr.Remove(0, crateAmt);
                var oldCrateToStr = crateFile.Crates.Skip(crateTo - 1).First();
                var newCrateTo = new String(oldCrateFromStr.Take(crateAmt).ToArray());

                if (moveOneCrateAtATime)
                {
                    char[] charArray = newCrateTo.ToCharArray();
                    Array.Reverse(charArray);
                    newCrateTo = new string(charArray);
                }

                newCrateTo += oldCrateToStr;

                crateFile.Crates.RemoveAt(crateFrom - 1);
                crateFile.Crates.Insert(crateFrom - 1, newCrateFrom);
                crateFile.Crates.RemoveAt(crateTo - 1);
                crateFile.Crates.Insert(crateTo - 1, newCrateTo);
            }

            StringBuilder sb = new StringBuilder();
            foreach (var crate in crateFile.Crates)
            {
                sb.Append(crate.FirstOrDefault());
            }
            return sb.ToString();
        }
	}
}

