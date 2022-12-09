Console.WriteLine("Advent 2022");

PrintAnswer(1, 1, Advent2022.DayOne.Program.GetAnswer1());
PrintAnswer(1, 2, Advent2022.DayOne.Program.GetAnswer2());

PrintAnswer(2, 1, Advent2022.DayTwo.Program.GetAnswer1());
PrintAnswer(2, 2, Advent2022.DayTwo.Program.GetAnswer2());

PrintAnswer(3, 1, Advent2022.DayThree.Program.GetAnswer1());
PrintAnswer(3, 2, Advent2022.DayThree.Program.GetAnswer2());

PrintAnswer(4, 1, Advent2022.DayFour.Program.GetAnswer1());
PrintAnswer(4, 2, Advent2022.DayFour.Program.GetAnswer2());

PrintAnswer(5, 1, Advent2022.DayFive.Program.GetAnswer1());
PrintAnswer(5, 2, Advent2022.DayFive.Program.GetAnswer2());

PrintAnswer(6, 1, Advent2022.DaySix.Program.GetAnswer1());
PrintAnswer(6, 2, Advent2022.DaySix.Program.GetAnswer2());

PrintAnswer(7, 1, Advent2022.DaySeven.Program.GetAnswer1());
PrintAnswer(7, 2, Advent2022.DaySeven.Program.GetAnswer2());

PrintAnswer(8, 1, Advent2022.DayEight.Program.GetAnswer1());
PrintAnswer(8, 2, Advent2022.DayEight.Program.GetAnswer2());

PrintAnswer(9, 1, Advent2022.DayNine.Program.GetAnswer1());
PrintAnswer(9, 2, Advent2022.DayNine.Program.GetAnswer2());

static void PrintAnswer(int day, int part, string answer) =>
    Console.WriteLine($"Day {day} | Part {part} | Answer {answer}");