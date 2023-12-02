using Aoc.Types;
using Xunit;

namespace Day01.UnitTests;

public class Part1Tests
{
    [Fact]
    public static void Part1_GivenTestInput_MatchesExpectations()
    {
        const string expected = "142";
        string[] testInput =
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        };

        IPart part = new Part1();

        string? actual = part.Solve(testInput);

        Assert.Equal(expected, actual);
    }
}