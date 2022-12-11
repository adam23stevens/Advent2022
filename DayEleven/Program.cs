using System;
using System.Numerics;

namespace Advent2022.DayEleven
{
	public static class Program
	{
		public static string GetAnswer1()
		{
			ulong answer = 1;

			var monkeys = FileReader.GetMonkeys();
			//var monkeys = FileReader.GetTestMonkeys();

			const int roundLimit = 20;
			
			for (int round = 0; round < roundLimit; round++)
			{
				DoRound(monkeys);
			}

			var inspCnt = monkeys.OrderByDescending(m => m.InspectCount)
                              .Take(2)
                              .Select(x => x.InspectCount);

			foreach(ulong cnt in inspCnt)
			{
				answer *= cnt;
			}

			return answer.ToString();
		}

		public static string GetAnswer2()
		{
			ulong answer = 1;

			var monkeys = FileReader.GetMonkeys();

			const int roundLimit = 10000;

			for(int round = 0; round < roundLimit; round++)
			{
				DoRound(monkeys, false);
			}
			var inspCnt = monkeys.OrderByDescending(m => m.InspectCount)
				.Take(2)
				.Select(x => x.InspectCount);
			foreach(ulong cnt in inspCnt)
			{
				answer *= cnt;
			}
			return answer.ToString();
		}

        private static void DoRound(List<Monkey> monkeys, bool decreaseLevel = true)
        {
			for (int m = 0; m < monkeys.Count(); m++) 
			{
				var monkey = monkeys[m];
				var currentItems = new List<BigInteger>(monkey.Items);

				for(int i = 0; i < currentItems.Count(); i++) 
				{
					var item = currentItems[i];

                    BigInteger worryLevelL = (BigInteger)monkey.Operation.Invoke(item);

					if (decreaseLevel)
					{
                        worryLevelL = (BigInteger)(worryLevelL / 3);
                    }
					else
					{
						var modulo = 1;
						foreach(var t in monkeys.Select(m => m.DividerTest))
						{
							modulo *= t;
						}
						worryLevelL %= modulo;
                    }
					
					if (monkey.Test.Invoke(worryLevelL))
					{
						monkeys.First(m => m.Id == monkey.MonkeyIdTrue).Items.Add(worryLevelL);
					} else
					{
						monkeys.First(m => m.Id == monkey.MonkeyIdFalse).Items.Add(worryLevelL);
					}
					monkeys.First(m => m.Id == monkey.Id).InspectCount++;
					monkeys.First(m => m.Id == monkey.Id).Items.Remove(item);
				}
			}
        }
    }
}

