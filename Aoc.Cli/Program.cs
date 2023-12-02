using Aoc.Cli;
using Aoc.Types;

// todo: get from args
string[] input = await File.ReadAllLinesAsync(@"C:\Dev\AoC\2023\Day02\input.txt");

// todo: get from args
IPart solution = Solutions.GetSolution(Solutions.Year._2023, Solutions.Day._02, Solutions.Part._2);

string? result = solution.Solve(input);

Console.WriteLine(result);