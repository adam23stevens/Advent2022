using System;
using System.Drawing;
using System.Text;

namespace Advent2022.DayEight
{
    public static class Program
    {
        private static List<Tree> VisibleTrees { get; set; } = new List<Tree>();
        private static List<Tree> AllTrees { get; set; } = new List<Tree>();
        private static List<string> FileRead { get; set; } = new List<string>();

        public static string GetAnswer1()
        {
            FileRead = FileReader.ReadFile();

            GetVisibleTreesFromLeft();
            GetVisibleTreesFromRight();
            GetVisibleTreesFromTop();
            GetVisibleTreesFromBottom();

            return VisibleTrees.Count().ToString();
        }

        public static string GetAnswer2()
        {
            for (var x = 0; x < FileRead.Count(); x++)
            {
                for (var y = 0; y < FileRead[x].Length; y++)
                {
                    var height = int.Parse(FileRead[x][y].ToString());
                    AllTrees.Add(new Tree()
                    {
                        XPos = x,
                        YPos = y,
                        Height = height,
                        TotalOtherTreesVisible = 1
                    });
                }
            }

            //foreach (var tree in AllTrees)
            //{
            //    var startPointForLeft = tree.XPos;
            //    var startPointForRight = FileRead.First().Length - tree.XPos - 1;
            //    var startPointForNorth = tree.YPos;
            //    var startPointForSouth = FileRead.Count() - tree.YPos - 1;

            //    //GetVisibleTreesFromLeft(tree);
            //}
            for (int t = 0; t < AllTrees.Count(); t++)
            {
                if (AllTrees[t].XPos == 3 && AllTrees[t].YPos == 2)
                {
                    var thing = "hello";
                }
                var RightTrees = GetVisibleOtherTrees(AllTrees[t], direction: 1);
                AllTrees[t].TotalOtherTreesVisible *= RightTrees;

                var DownTrees = GetVisibleOtherTrees(AllTrees[t], direction: 2);
                AllTrees[t].TotalOtherTreesVisible *= DownTrees;

                var LeftTrees = GetVisibleOtherTrees(AllTrees[t], direction: 3);
                AllTrees[t].TotalOtherTreesVisible *= LeftTrees;

                var UpTrees = GetVisibleOtherTrees(AllTrees[t], direction: 4);
                AllTrees[t].TotalOtherTreesVisible *= UpTrees;
            }

            var BestTrees = AllTrees.OrderByDescending(d => d.TotalOtherTreesVisible);
            return AllTrees.Max(t => t.TotalOtherTreesVisible).ToString();
        }

        private static void GetVisibleTreesFromBottom()
        {
            int minHeight = 0;

            for (int yPos = 0; yPos < FileRead.First().Length; yPos++)
            {
                StringBuilder colStr = new StringBuilder();
                for (int rowNum = 0; rowNum < FileRead.Count(); rowNum++)
                {
                    var treeStr = FileRead[rowNum][yPos].ToString();
                    colStr.Append(treeStr);
                }
                var treeColStr = colStr.ToString();
                char[] charArray = treeColStr.ToCharArray();
                Array.Reverse(charArray);
                var treeCol = new string(charArray);
                bool isOutSide = true;

                for (int colNum = 0; colNum < treeCol.Count(); colNum++)
                {
                    var nextTree = treeCol[colNum];
                    var nextTreeHeight = int.Parse(nextTree.ToString());
                    if (nextTreeHeight > minHeight || isOutSide)
                    {
                        CheckAddTree(treeCol.Length - colNum - 1, yPos, nextTreeHeight);
                        minHeight = nextTreeHeight;
                    }
                    isOutSide = false;
                }
            }
        }

        private static void GetVisibleTreesFromTop()
        {
            int minHeight = 0;

            for (int yPos = 0; yPos < FileRead.First().Length; yPos++)
            {
                StringBuilder colStr = new StringBuilder();
                for (int rowNum = 0; rowNum < FileRead.Count(); rowNum++)
                {
                    var treeStr = FileRead[rowNum][yPos].ToString();
                    colStr.Append(treeStr);
                }
                var treeCol = colStr.ToString();
                bool isOutSide = true;

                for (int colNum = 0; colNum < treeCol.Count(); colNum++)
                {
                    var nextTree = treeCol[colNum];
                    var nextTreeHeight = int.Parse(nextTree.ToString());
                    if (nextTreeHeight > minHeight || isOutSide)
                    {
                        CheckAddTree(colNum, yPos, nextTreeHeight);
                        minHeight = nextTreeHeight;
                    }
                    isOutSide = false;
                }
            }
        }

        private static void GetVisibleTreesFromRight()
        {
            for (int xPos = 0; xPos < FileRead.Count(); xPos++)
            {
                int minHeight = 0;

                var treeRowStr = FileRead.Skip(xPos).Take(1).First();
                char[] charArray = treeRowStr.ToCharArray();
                Array.Reverse(charArray);
                var treeRow = new string(charArray);

                bool isOutside = true;

                for (int yPos = 0; yPos < treeRow.Count(); yPos++)
                {
                    var nextTree = treeRow[yPos];
                    var nextTreeHeight = int.Parse(nextTree.ToString());
                    if (nextTreeHeight > minHeight || isOutside)
                    {
                        CheckAddTree(xPos, treeRow.Length - yPos - 1, nextTreeHeight);
                        minHeight = nextTreeHeight;
                    }

                    isOutside = false;
                }
            }
        }

        private static void GetVisibleTreesFromLeft()
        {

            for (int xPos = 0; xPos < FileRead.Count(); xPos++)
            {
                int minHeight = 0;

                var treeRow = FileRead.Skip(xPos).Take(1).First().ToList();
                bool isOutside = true;


                for (int yPos = 0; yPos < treeRow.Count(); yPos++)
                {
                    var nextTree = treeRow[yPos];
                    var nextTreeHeight = int.Parse(nextTree.ToString());
                    if (nextTreeHeight > minHeight || isOutside)
                    {
                        CheckAddTree(xPos, yPos, nextTreeHeight);


                        minHeight = nextTreeHeight;
                    }
                    isOutside = false;
                }

            }

        }

        private static int GetVisibleOtherTrees(Tree tree, int direction)
        {
            int treeCnt = 0;

            if (direction == 1) //searching to the right
            {
                var treeString = FileRead[tree.XPos].Substring(tree.YPos + 1);
                for (int y = 0; y < treeString.Length; y++, treeCnt++)
                {
                    var thisTreeHeight = int.Parse(treeString[y].ToString());
                    if (thisTreeHeight >= tree.Height)
                    {
                        treeCnt++;
                        break;
                    }
                }
            }
            else if (direction == 2) //searching down
            {
                StringBuilder treeSb = new();
                for (int rowNum = tree.XPos + 1; rowNum < FileRead.Count(); rowNum++)
                {
                    var treeStr = FileRead[rowNum][tree.YPos].ToString();
                    treeSb.Append(treeStr);
                }
                var treeString = treeSb.ToString();

                for (int y = 0; y <= treeString.Length -1; y++, treeCnt++)
                {
                    var thisTreeHeight = int.Parse(treeString[y].ToString());
                    if (thisTreeHeight >= tree.Height)
                    {
                        treeCnt++;
                        break;
                    }
                }

            }
            else if (direction == 3) //searching left
            {
                if (tree.YPos == 0) return 0;

                var treeString = FileRead[tree.XPos].Substring(0, tree.YPos);
                for (int y = tree.YPos - 1; y >= 0; y--, treeCnt++)
                {
                    var thisTreeHeight = int.Parse(treeString[y].ToString());
                    if (thisTreeHeight >= tree.Height)
                    {
                        treeCnt++;
                        break;
                    }
                }
            }
            else if (direction == 4) //searching up
            {
                if (tree.XPos == 0) return 0;

                StringBuilder treeSb = new();
                for (int rowNum = tree.XPos - 1; rowNum >= 0; rowNum--)
                {
                    var treeStr = FileRead[rowNum][tree.YPos].ToString();
                    treeSb.Append(treeStr);
                }
                var treeString = treeSb.ToString();

                for (int y = 0; y <= treeString.Length - 1; y++, treeCnt++)
                {
                    var thisTreeHeight = int.Parse(treeString[y].ToString());
                    if (thisTreeHeight >= tree.Height)
                    {
                        treeCnt++;
                        break;
                    }
                }
            }
            return treeCnt;
        }

        private static void CheckAddTree(int xPos, int yPos, int treeHeight)
        {
            if (!VisibleTrees.Any(x => x.XPos == xPos && x.YPos == yPos))
            {
                //Console.WriteLine($"X{xPos} Y{yPos} H{treeHeight}");
                VisibleTrees.Add(new Tree
                {
                    XPos = xPos,
                    YPos = yPos,
                    Height = treeHeight
                });
            }
        }
    }

    public class Tree
    {
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int Height { get; set; }
        public int TotalOtherTreesVisible { get; set; }
    }
}

