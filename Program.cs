Console.WriteLine("Advent 2022");

PrintAnswer(1, 1, Advent2022.DayOne.Program.GetAnswer1());
PrintAnswer(1, 2, Advent2022.DayOne.Program.GetAnswer2());

PrintAnswer(2, 1, Advent2022.DayTwo.Program.GetAnswer1());
PrintAnswer(2, 2, Advent2022.DayTwo.Program.GetAnswer2());

PrintAnswer(3, 1, Advent2022.DayThree.Program.GetAnswer1());
PrintAnswer(3, 2, Advent2022.DayThree.Program.GetAnswer2());

static void PrintAnswer(int day, int part, string answer) =>
    Console.WriteLine($"Day {day} | Part {part} | Answer {answer}");