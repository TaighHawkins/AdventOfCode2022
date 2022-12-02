// See https://aka.ms/new-console-template for more information
using AdventOfCode2022.Abstractions;

int[] valid = { 1, 2 };

Console.WriteLine("Hello, World!");
while (true)
{
    Console.WriteLine("Please select the day that you want to solve - use 0 to quit:");
    
    var day = int.Parse(Console.ReadLine().Trim());
    if (day == 0)
    {
        return;
    }
    if (!valid.Contains(day))
    {
        Console.WriteLine("We cannot currently handle this day");
        return;
    } 

    var x = Type.GetType($"Day{day}.Solution, Day{day}");

    Console.WriteLine($"Solving for day {day} ...");
    var solution = (Solution)Activator.CreateInstance(x);

    solution.SolveDay();
}