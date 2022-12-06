using System;
namespace Advent2022.DaySix
{
	public static class Program
	{
		public static string GetAnswer1()
        {
            var line = FileReader.ReadFile();
            return GeneratePacketNumber(line, 4);
        }

        public static string GetAnswer2()
		{
            var line = FileReader.ReadFile();
            return GeneratePacketNumber(line, 14);
		}

        private static string GeneratePacketNumber(string line, int packetCnt)
        {
            int answer = 0;

            for (; answer <= line.Length - packetCnt; answer++)
            {
                var lineToCheck = line.Skip(answer).Take(packetCnt);
                if (IsStringUnique(lineToCheck)) break;
            }

            return (answer + packetCnt).ToString();
        }

        private static bool IsStringUnique(IEnumerable<char> line)
		{
			var originalCount = line.Count();
			var distinctCount = line.Distinct().Count();

			return distinctCount == originalCount;
		}
	}
}

