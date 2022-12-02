using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2022.DayTwo
{
    internal class FileReader
    {
        public static List<string> ReadFile()
        {
            string filePath = "../../../DayTwo/input.txt";
            var retList = new List<string>(System.IO.File.ReadAllLines(filePath));
          
            return retList;
        }
    }
}
