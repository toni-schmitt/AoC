using AoC._2023.Day01;
using AoC.Types;

namespace AoC.Cli;

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

    private static Dictionary<(Year, Day, Part), Type>
        SolutionTypesByYearDayAndPart { get; } = new()
    {
        {
            (Year._2023, Day._01, Part._1), typeof(Part1)
        },
        {
            (Year._2023, Day._01, Part._2), typeof(Part2)
        },
        {
            (Year._2023, Day._02, Part._1), typeof(_2023.Day02.Part1)
        },
        {
            (Year._2023, Day._02, Part._2), typeof(_2023.Day02.Part2)
        },
        {
            (Year._2023, Day._03, Part._1), typeof(_2023.Day03.Part1)
        },
        {
            (Year._2023, Day._03, Part._2), typeof(_2023.Day03.Part2)
        },
        {
            (Year._2023, Day._04, Part._1), typeof(_2023.Day04.Part1)
        },
        {
            (Year._2023, Day._04, Part._2), typeof(_2023.Day04.Part2)
        }
        // {
        //     (Year._2023, Day._05, Part._1), typeof(_2023.Day05.Part1)
        // },
        // {
        //     (Year._2023, Day._05, Part._2), typeof(_2023.Day05.Part2)
        // },
        // {
        //     (Year._2023, Day._06, Part._1), typeof(_2023.Day06.Part1)
        // },

        // {
        //     (Year._2023, Day._06, Part._2), typeof(_2023.Day06.Part2)
        // },
        // {
        //     (Year._2023, Day._07, Part._1), typeof(_2023.Day07.Part1)
        // },
        // {
        //     (Year._2023, Day._07, Part._2), typeof(_2023.Day07.Part2)
        // },
        // {
        //     (Year._2023, Day._08, Part._1), typeof(_2023.Day08.Part1)
        // },
        // {
        //     (Year._2023, Day._08, Part._2), typeof(_2023.Day08.Part2)
        // },
        // {
        //     (Year._2023, Day._09, Part._1), typeof(_2023.Day09.Part1)
        // },
        // {
        //     (Year._2023, Day._09, Part._2), typeof(_2023.Day09.Part2)
        // },
        // {
        //     (Year._2023, Day._10, Part._1), typeof(_2023.Day10.Part1)
        // },
        // {
        //     (Year._2023, Day._10, Part._2), typeof(_2023.Day10.Part2)
        // }
    };

    public static ISolution GetSolution(Year year, Day day, Part part)
    {
        Type solutionType = SolutionTypesByYearDayAndPart[(year, day, part)];

        ISolution solution = Activator.CreateInstance(
                                 solutionType
                             ) as ISolution
                             ?? throw new InvalidOperationException(
                                 $"No solution found for year: {year} day: {day}"
                             );

        return solution;
    }

    public static IEnumerable<ISolution> GetSolutions(
        Year year,
        Day day,
        params Part[] parts
    ) => parts.Select(
        part => GetSolution(
            year,
            day,
            part
        )
    );
}
