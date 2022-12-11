using System;
using System.Numerics;

namespace Advent2022.DayEleven
{
    public static class FileReader
    {
        public static List<Monkey> GetMonkeys()
        {
            return new List<Monkey>()
            {
                new Monkey()
                {
                    Id = 0,
                    Items = new List<BigInteger>() {91, 58, 52, 69, 95, 54},
                    Operation = x => x * 13,
                    Test = x => x % 7 == 0,
                    DividerTest = 7,
                    MonkeyIdTrue = 1,
                    MonkeyIdFalse = 5
                },
                new Monkey()
                {
                    Id = 1,
                    Items = new List<BigInteger>() { 80, 80, 97, 84 },
                    Operation = x => x * x,
                    Test = x => x % 3 == 0,
                    DividerTest = 3,
                    MonkeyIdTrue = 3,
                    MonkeyIdFalse = 5
                },
                new Monkey()
                {
                    Id = 2,
                    Items = new List<BigInteger>() { 86, 92, 71 },
                    Operation = x => x + 7,
                    Test = x => x % 2 == 0,
                    DividerTest = 2,
                    MonkeyIdTrue = 0,
                    MonkeyIdFalse = 4
                },
                new Monkey()
                {
                    Id = 3,
                    Items = new List<BigInteger>() { 96, 90, 99, 76, 79, 85, 98, 61 },
                    Operation = x => x + 4,
                    Test = x => x % 11 == 0,
                    DividerTest = 11,
                    MonkeyIdTrue = 7,
                    MonkeyIdFalse = 6
                },
                new Monkey()
                {
                    Id = 4,
                    Items = new List<BigInteger>() { 60, 83, 68, 64, 73 },
                    Operation = x => x * 19,
                    Test = x => x % 17 == 0,
                    DividerTest = 17,
                    MonkeyIdTrue = 1,
                    MonkeyIdFalse = 0
                },
                new Monkey()
                {
                    Id = 5,
                    Items = new List<BigInteger>() { 96, 52, 52, 94, 76, 51, 57 },
                    Operation = x => x + 3,
                    Test = x => x % 5 == 0,
                    DividerTest = 5,
                    MonkeyIdTrue = 7,
                    MonkeyIdFalse = 3
                },
                new Monkey()
                {
                    Id = 6,
                    Items = new List<BigInteger>() { 75 },
                    Operation = x => x + 5,
                    Test = x => x % 13 == 0,
                    DividerTest = 13,
                    MonkeyIdTrue = 4,
                    MonkeyIdFalse = 2
                },
                new Monkey()
                {
                    Id = 7,
                    Items = new List<BigInteger>() { 83, 75 },
                    Operation = x => x + 1,
                    Test = x => x % 19 == 0,
                    DividerTest = 19,
                    MonkeyIdTrue = 2,
                    MonkeyIdFalse = 6
                }
            };
        }

        public static List<Monkey> GetTestMonkeys()
        {
            return new List<Monkey>()
            {
                new Monkey()
                {
                    Id = 0,
                    Items = new List<BigInteger>() {79, 98},
                    Operation = x => x * 19,
                    Test = x => x % 23 == 0,
                    DividerTest = 23,
                    MonkeyIdTrue = 2,
                    MonkeyIdFalse = 3
                },
                new Monkey()
                {
                    Id = 1,
                    Items = new List<BigInteger>() { 54, 65, 75, 74 },
                    Operation = x => x + 6,
                    Test = x => x % 19 == 0,
                    DividerTest = 19,
                    MonkeyIdTrue = 2,
                    MonkeyIdFalse = 0
                },
                new Monkey()
                {
                    Id = 2,
                    Items = new List<BigInteger>() { 79, 60, 97 },
                    Operation = x => x* x,
                    Test = x => x % 13 == 0,
                    DividerTest = 13,
                    MonkeyIdTrue = 1,
                    MonkeyIdFalse = 3
                },
                new Monkey()
                {
                    Id = 3,
                    Items = new List<BigInteger>() {74},
                    Operation = x => x + 3,
                    Test = x => x % 17 == 0,
                    DividerTest = 17,
                    MonkeyIdTrue = 0,
                    MonkeyIdFalse = 1
                }
            };

        }
    }

    public class Monkey
    {
        public Monkey()
        {
            InspectCount = 0;
        }

        public int Id { get; set; }
        public List<BigInteger> Items { get; set; }
        public Func<BigInteger, BigInteger> Operation { get; set; }
        public Predicate<BigInteger> Test { get; set; }
        public int DividerTest { get; set; }
        public int MonkeyIdTrue { get; set; }
        public int MonkeyIdFalse { get; set; }
        public ulong InspectCount { get; set; }
    }
}

