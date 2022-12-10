using System;
using System.Text;

namespace Advent2022.DayTen
{
	public class Program
	{
		private static List<string> lines { get; set; } = new List<string>();
		private static Dictionary<int, int> CycleXRegisters { get; set; } = new Dictionary<int, int>();

		public static string GetAnswer1()
		{
			lines = FileReader.ReadFile();

			return RunCycles().ToString();
		}

		public static void GetAnswer2()
		{
			var crtRows = RenderCRT();
			foreach(var row in crtRows)
			{
				Console.WriteLine(row);
			}
		}

		private static List<string> RenderCRT()
		{
			StringBuilder sb1 = new StringBuilder();
			StringBuilder sb2 = new StringBuilder();
			StringBuilder sb3 = new StringBuilder();
			StringBuilder sb4 = new StringBuilder();
			StringBuilder sb5 = new StringBuilder();
			StringBuilder sb6 = new StringBuilder();

			foreach(var cycleRegister in CycleXRegisters)
			{
				var listNums = new List<int>() { cycleRegister.Value - 1, cycleRegister.Value, cycleRegister.Value + 1 };

                if (cycleRegister.Key <= 40)
				{
                    char output = listNums.Contains(cycleRegister.Key -1) ? '#' : '.';
                    sb1.Append(output);
				}
				else if (cycleRegister.Key <= 80)
				{
                    char output = listNums.Contains(cycleRegister.Key - 41) ? '#' : '.';
                    sb2.Append(output);
				}
				else if (cycleRegister.Key <= 120)
				{
                    char output = listNums.Contains(cycleRegister.Key - 81) ? '#' : '.';
                    sb3.Append(output);
				}
				else if (cycleRegister.Key <= 160)
				{
                    char output = listNums.Contains(cycleRegister.Key - 121) ? '#' : '.';
                    sb4.Append(output);
				}
				else if (cycleRegister.Key <= 200)
				{
                    char output = listNums.Contains(cycleRegister.Key - 161) ? '#' : '.';
                    sb5.Append(output);
				}
				else if (cycleRegister.Key <= 240)
				{
                    char output = listNums.Contains(cycleRegister.Key - 201) ? '#' : '.';
                    sb6.Append(output);
				}
			}
			return new List<string>() { sb1.ToString(), sb2.ToString(), sb3.ToString(), sb4.ToString(), sb5.ToString(), sb6.ToString() };
        }

		private static int RunCycles()
		{
			int xRegisterVal = 1;
			List<int> xRegisterVals = new List<int>();
			List<int> pauseCycles = new List<int>() { 20, 60, 100, 140, 180, 220 };
			bool isXValChange = false;

			int cycles = 0;
			int lineIndex = 0;
			do
			{
				cycles++;

				CycleXRegisters.Add(cycles, xRegisterVal);

				var line = lines[lineIndex];
				var ins = line.Split(' ');
				if (ins.Length > 1) 
				{
					if (pauseCycles.Contains(cycles))
					{
						xRegisterVals.Add(cycles * xRegisterVal);
					}

					var xAmt = int.Parse(ins[1]);
                    xRegisterVal += isXValChange ? xAmt : 0;
                    lineIndex += isXValChange ? 1 : 0;
					isXValChange = !isXValChange;
                }
				else
				{
                    if (pauseCycles.Contains(cycles))
                    {
                        xRegisterVals.Add(cycles * xRegisterVal);
                    }

                    lineIndex++;
				}
			}
			while (lineIndex < lines.Count());

			return xRegisterVals.Sum();
		}
	}
}

