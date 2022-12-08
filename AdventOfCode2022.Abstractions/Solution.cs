using System.Diagnostics;

namespace AdventOfCode2022.Abstractions;

public abstract class Solution
{
    protected string DefaultFileInputName
        => $"{GetType().Namespace}Input.txt";

    public string EventName { get; set; }

    public void PrintEntry()
    {
        Console.WriteLine($"{GetType().Namespace}: {EventName}", ConsoleColor.Green);
    }

    protected string GetCleanedFileAsString(string inputName)
    {
        if (string.IsNullOrEmpty(inputName))
        {
            inputName = DefaultFileInputName;
        }

        return File.ReadAllText(inputName)
            .TrimEnd()
            .Replace("\r\n", "\n");
    }

    protected string[] GetCleanedFileLines(string inputName = "")
    {
        return GetCleanedFileAsString(inputName).Split('\n');
    }

    public abstract void ReadInput(string inputName = "");

    public void SolveDay()
    {
        var sw = Stopwatch.StartNew();
        ReadInput();
        long readTaken = sw.ElapsedMilliseconds;
        SolvePartOne();
        long afterPartOneTaken = sw.ElapsedMilliseconds;
        SolverPartTwo();
        sw.Stop();
        long totalTimeTaken = sw.ElapsedMilliseconds;
        Console.WriteLine("Performance:");
        Console.WriteLine($"\tInput conversion took: {readTaken}ms");
        Console.WriteLine($"\tPart one of solution took: {afterPartOneTaken - readTaken}ms");
        Console.WriteLine($"\tPart two of solution took: {totalTimeTaken - readTaken}ms");
        Console.WriteLine($"\tTotal running time was {totalTimeTaken}ms");
    }

    protected abstract void SolvePartOne();
    protected abstract void SolverPartTwo();
}