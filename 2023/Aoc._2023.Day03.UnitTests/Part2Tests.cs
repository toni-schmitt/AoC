using AoC._2023.Day03;
using Xunit;

namespace Aoc._2023.Day03.UnitTests;

public class Part2Tests
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
    public string Expected { get; } = "467835";

    [Fact]
    public void Part2_GivenTestInput_MatchesExpectations()
    {
        Part2 part2 = new Part2();

        string? actual = part2.Solve(
            TestInput
        );

        Assert.Equal(
            Expected,
            actual
        );
    }
}
