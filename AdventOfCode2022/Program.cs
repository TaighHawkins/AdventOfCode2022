// See https://aka.ms/new-console-template for more information
using AdventOfCode2022.Abstractions;

int[] valid = { 1, 2 };

Console.WriteLine("Hello, World!");
while (true)
{
    Console.WriteLine("Please select the day that you want to solve - use 0 to quit:");
    if (!int.TryParse(Console.ReadLine()?.Trim(), out int day))
    {
        continue;
    }
    
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
    if (x is null)
    {
        Console.WriteLine($"Unable to load solution for day {day}");
        continue;
    }

    Console.WriteLine($"Solving for day {day} ...");
    var instance = Activator.CreateInstance(x);
    if (instance is null)
    {
        Console.WriteLine($"Unable to create solution instance for day {day}");
        continue;
    }
    var solution = (Solution)instance;

    solution.SolveDay();
}