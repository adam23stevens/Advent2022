using System;
namespace Advent2022.DayThree
{
	public static class Program
	{
		private static List<string> rucksacks => FileReader.ReadFile();
		private static string orderedItems = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

		public static string GetAnswer1()
		{
			int runningTotal = 0;
			foreach(var rucksack in rucksacks)
			{
				var middleIndex = rucksack.Length / 2;
				var firstHalf = rucksack.Take(middleIndex);
				var secondHalf = rucksack.Skip(middleIndex).Take(middleIndex);
					
				foreach(var item in firstHalf)
				{
					if (secondHalf.Any(x => x == item))
					{
						var scoreItem = orderedItems.IndexOf(item);
						runningTotal += scoreItem;
						break;
					}
				}
			}
			return runningTotal.ToString();
		}

		public static string GetAnswer2()
		{
			int runningTotal = 0;
			for(int x = 0; x < rucksacks.Count; x += 3)
			{
				var thisRucksack = rucksacks[x];
				var nextRuckSack = rucksacks[x + 1];
				var sackAfter = rucksacks[x + 2];
				foreach(var thing in thisRucksack)
				{
					if (nextRuckSack.Contains(thing) && sackAfter.Contains(thing))
					{
						var score = orderedItems.IndexOf(thing);
						runningTotal += score;
						break;
					}
				}
			}
			return runningTotal.ToString();
		}
	}
}

