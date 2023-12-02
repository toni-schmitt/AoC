using Aoc.Types;
using Day01;

namespace Aoc.Cli;

public static class Solutions
{

    public enum Day
    {
        _01,
        _02,
        _03,
        _04,
        _05,
        _06,
        _07,
        _08,
        _09,
        _10,
        _11,
        _12,
        _13,
        _14,
        _15,
        _16,
        _17,
        _18,
        _19,
        _20,
        _21,
        _22,
        _23,
        _24,
        _25
    }

    public enum Part
    {
        _1,
        _2
    }

    public enum Year
    {
        _2023
    }

    private static Dictionary<(Year, Day, Part), Type> SolutionTypes { get; } = new()
    {
        {
            (Year._2023, Day._01, Part._1), typeof(Part1)
        },
        {
            (Year._2023, Day._01, Part._2), typeof(Part2)
        },
        {
            (Year._2023, Day._02, Part._1), typeof(Day02.Part1)
        },
        {
            (Year._2023, Day._02, Part._2), typeof(Day02.Part2)
        }
    };

    public static IPart GetSolution(Year year, Day day, Part part)
    {
        Type solutionType = SolutionTypes[(year, day, part)];

        IPart solution = Activator.CreateInstance(solutionType) as IPart
                         ?? throw new InvalidOperationException($"No solution found for year: {year} day: {day}");

        return solution;
    }
}