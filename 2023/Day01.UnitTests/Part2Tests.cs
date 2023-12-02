using Xunit;

namespace Day01.UnitTests;

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

        var part = new Part2();

        string? actual = part.Solve(testInput);

        Assert.Equal(expected, actual);
    }
}