using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2022.DayTwo
{
    public static class Program
    {
        private static List<string> gameRounds = FileReader.ReadFile();

        public static string GetAnswer1()
        {
            int totalScore = 0;
            foreach (var round in gameRounds)
            {
                totalScore += GetWinLoseOrDraw(round[0], round[2]);
                totalScore += GetRoundScore(round);
            }
            return totalScore.ToString();
        }

        public static string GetAnswer2()
        {
            int totalScore = 0;
            foreach (var round in gameRounds)
            {
                int winLoseOrDraw = 0;
                switch(round[2])
                {
                    case 'Y': winLoseOrDraw = 3;
                        break;
                    case 'Z': winLoseOrDraw = 6;
                        break;
                }
                totalScore += TranslateScore(round[0], winLoseOrDraw);
            }
            return totalScore.ToString();
        }

        private static int TranslateScore(char opponent, int winLoseOrDraw)
        {
            int score = winLoseOrDraw;
            switch (opponent)
            {
                case 'A':
                    switch (winLoseOrDraw)
                    {
                        case 0:
                            score += 3;
                            break;
                        case 3:
                            score += 1;
                            break;
                        case 6:
                            score += 2;
                            break;                            
                    }
                    break;
                case 'B':
                    switch (winLoseOrDraw)
                    {
                        case 0:
                            score += 1;
                            break;
                        case 3:
                            score += 2;
                            break;
                        case 6:
                            score += 3;
                            break;
                    }
                    break;
                case 'C':
                    switch(winLoseOrDraw)
                    {
                        case 0:
                            score += 2;
                            break;
                        case 3:
                            score += 3;
                            break;                            
                        case 6:
                            score += 1;
                            break;
                    }
                    break;
            }
            return score;
        }

        private static int GetRoundScore(string round)
        {
            switch (round[2])
            {
                case 'X':
                    return 1;
                case 'Y':
                    return 2;
                case 'Z':
                    return 3;
            }
            return 0;
        }

        private static int GetWinLoseOrDraw(char opponent, char me)
        {
            switch (opponent)
            {
                case 'A':
                    switch (me)
                    {
                        case 'X': return 3;
                        case 'Y': return 6;
                        case 'Z': return 0;
                    }
                    break;
                case 'B':
                    switch (me)
                    {
                        case 'X': return 0;
                        case 'Y': return 3;
                        case 'Z': return 6;
                    }
                    break;
                case 'C':
                    switch (me)
                    {
                        case 'X': return 6;
                        case 'Y': return 0;
                        case 'Z': return 3;
                    }
                    break;
            }
            return 0;
        }
    }
}
