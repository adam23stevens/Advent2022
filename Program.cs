Console.WriteLine("Advent 2022");

PrintAnswer(1, 1, Advent2022.DayOne.Program.GetAnswer1());




static void PrintAnswer(int day, int part, string answer) =>
    Console.WriteLine($"Day {day} | Part {part} | Answer {answer}");