using System;
namespace Advent2022.DayNine
{
	public static class Program
	{
		private static Position HeadPosition { get; set; }
		private static Position TailPosition { get; set; }
		private static List<Position> KnotPositions { get; set; } = new List<Position>();
		private static List<Position> PreviousTailPositions { get; set; } = new List<Position>();

		public static string GetAnswer1()
		{
			var lines = FileReader.ReadFile();

			HeadPosition = new Position(0, 0);
			TailPosition = new Position(0, 0);

			AddToTailPositions();

			foreach(var line in lines)
			{
				var dir = line.Split(' ')[0];
				var rep = int.Parse(line.Split(' ')[1]);

				for(int r = 0; r < rep; r++)
				{
					switch(dir)
					{
						case "U":
							MoveHeadUp();
							break;
						case "D":
							MoveHeadDown();
							break;
						case "L":
							MoveHeadLeft();
							break;
						case "R":
							MoveHeadRight();
							break;
					}
					MoveTail();
                    AddToTailPositions();
                }
			}

			return PreviousTailPositions.Count().ToString();
		}

		public static string GetAnswer2()
		{
			var lines = FileReader.ReadFile();
			PreviousTailPositions = new List<Position>();
			
			for(int knot = 0; knot < 10; knot++)
			{
				KnotPositions.Add(new Position(0, 0));
			}

            foreach (var line in lines)
            {
                var dir = line.Split(' ')[0];
                var rep = int.Parse(line.Split(' ')[1]);

                for (int r = 0; r < rep; r++)
                {
                    switch (dir)
                    {
                        case "U":
                            MoveKnotOneUp();
                            break;
                        case "D":
                            MoveKnotOneDown();
                            break;
                        case "L":
                            MoveKnotOneLeft();
                            break;
                        case "R":
                            MoveKnotOneRight();
                            break;
                    }
					for(int thisKnotIndex = 1; thisKnotIndex < 10; thisKnotIndex++)
					{
						MoveNextKnot(thisKnotIndex, thisKnotIndex - 1);
					}
					AddToLastKnotPositions();
                }
            }

			return PreviousTailPositions.Count().ToString();
        }

		private static void AddToLastKnotPositions()
		{
			if (!PreviousTailPositions.Any(p => p.xPos == KnotPositions[9].xPos && p.yPos == KnotPositions[9].yPos))
			{
				PreviousTailPositions.Add(new Position(KnotPositions[9].xPos, KnotPositions[9].yPos));
			}
		}

		private static void AddToTailPositions()
		{
			if (!PreviousTailPositions.Any(p => p.xPos == TailPosition.xPos && p.yPos == TailPosition.yPos))
			{
				PreviousTailPositions.Add(new Position(TailPosition.xPos, TailPosition.yPos));
			}
		}

		private static void MoveNextKnot(int thisKnotIndex, int prevKnotIndex)
		{
			var prevKnot = KnotPositions[prevKnotIndex];
			var thisKnot = KnotPositions[thisKnotIndex];

			var xPosDiff = prevKnot.xPos - thisKnot.xPos;
			var yPosDiff = prevKnot.yPos - thisKnot.yPos;

            if (yPosDiff > 1)
            {
				KnotPositions[thisKnotIndex].yPos++;
				if (xPosDiff > 1)
				{
					KnotPositions[thisKnotIndex].xPos++;
				}
				else if (xPosDiff < -1)
				{
					KnotPositions[thisKnotIndex].xPos--;
				}
				else
				{
                    KnotPositions[thisKnotIndex].xPos += xPosDiff;
                }
				return;
            }
            if (yPosDiff < -1)
            {
				KnotPositions[thisKnotIndex].yPos--;
				
                if (xPosDiff > 1)
                {
                    KnotPositions[thisKnotIndex].xPos++;
                }
                else if (xPosDiff < -1)
                {
                    KnotPositions[thisKnotIndex].xPos--;
                }
                else
                {
                    KnotPositions[thisKnotIndex].xPos += xPosDiff;
                }
				return;
            }
            if (xPosDiff > 1)
            {
				KnotPositions[thisKnotIndex].xPos++;

                if (yPosDiff > 1)
                {
                    KnotPositions[thisKnotIndex].yPos++;
                }
                else if (yPosDiff < -1)
                {
                    KnotPositions[thisKnotIndex].yPos--;
                }
                else
                {
                    KnotPositions[thisKnotIndex].yPos += yPosDiff;
                }
				return;
            }
            if (xPosDiff < -1)
            {
				KnotPositions[thisKnotIndex].xPos--;

                if (yPosDiff > 1)
                {
                    KnotPositions[thisKnotIndex].yPos++;
                }
                else if (yPosDiff < -1)
                {
                    KnotPositions[thisKnotIndex].yPos--;
                }
                else
                {
                    KnotPositions[thisKnotIndex].yPos += yPosDiff;
                }
				return;
            }
        }

		private static void MoveTail()
		{
			var xPosDiff = HeadPosition.xPos - TailPosition.xPos;
			var yPosDiff = HeadPosition.yPos - TailPosition.yPos;

			if (yPosDiff > 1)
			{
				TailPosition.yPos++;
				TailPosition.xPos += xPosDiff;
			}
			if (yPosDiff < -1)
			{
				TailPosition.yPos--;
				TailPosition.xPos += xPosDiff;
			}
			if (xPosDiff > 1)
			{
				TailPosition.xPos++;
				TailPosition.yPos += yPosDiff;
			}
			if (xPosDiff < -1)
			{
				TailPosition.xPos--;
				TailPosition.yPos += yPosDiff;
			}
		}

		private static void MoveHeadUp() => HeadPosition.yPos++;
		private static void MoveHeadDown() => HeadPosition.yPos--;
		private static void MoveHeadLeft() => HeadPosition.xPos--;
		private static void MoveHeadRight() => HeadPosition.xPos++;


		private static void MoveKnotOneUp() => KnotPositions[0].yPos++;
		private static void MoveKnotOneDown() => KnotPositions[0].yPos--;
		private static void MoveKnotOneLeft() => KnotPositions[0].xPos--;
		private static void MoveKnotOneRight() => KnotPositions[0].xPos++;

	}

	public class Position
	{
		public Position (int x, int y)
		{
			xPos = x;
			yPos = y;
		}
		public int xPos { get; set; }
		public int yPos { get; set; }
	}
}

