using Xunit;

namespace AoC._2023.Day01.UnitTests;

public class Part2Tests
{
    [Fact]
    public static void Part2_GivenTestInput_MatchesExpectations()
    {
        const string expected = "281";

        string[] testInput =
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        };

        Part2 part = new();

        string? actual = part.Solve(
            testInput
        );

        Assert.Equal(
            expected,
            actual
        );
    }
}
