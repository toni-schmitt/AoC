using AoC._2023.Day03;
using Xunit;

namespace Aoc._2023.Day03.UnitTests;

public class Part1Tests
{
    public string[] TestInput { get; } =
    {
        "467..114..",
        "...*......",
        "..35..633.",
        "......#...",
        "617*......",
        ".....+.58.",
        "..592.....",
        "......755.",
        "...$.*....",
        ".664.598.."
    };
    public string Expected { get; } = "4361";

    [Fact]
    public void Part1_GivenTestInput_MatchesExpectations()
    {
        Part1 part1 = new Part1();

        string? actual = part1.Solve(
            TestInput
        );

        Assert.Equal(
            Expected,
            actual
        );
    }
}
