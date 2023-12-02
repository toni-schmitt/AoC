using System.Buffers;
using Aoc.Types;

namespace Day01;

public class Part2 : IPart
{
    private readonly static SearchValues<char> NumbersSearchValues = SearchValues.Create("123456789");

    private readonly static string[] SpelledOutNumbers =
    {
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine"
    };

    public string? Solve(IEnumerable<string> input)
    {
        IEnumerable<int> nums = GetNumbersFromInput(input);

        return nums.Sum()
            .ToString();
    }

    private static IEnumerable<int> GetNumbersFromInput(IEnumerable<string> input)
        => input.Select(GetNumberFromLine);

    private static int GetNumberFromLine(string line)
    {
        int firstNumIndex = line.AsSpan()
            .IndexOfAny(NumbersSearchValues);

        int lastNumIndex = line.AsSpan()
            .LastIndexOfAny(NumbersSearchValues);

        (int firstSpelledOutNumIndex, int firstLength) = line.IndexAndLengthOfAny(SpelledOutNumbers);
        (int lastSpelledOutNumIndex, int lastLength) = line.LastIndexAndLengthOfAny(SpelledOutNumbers);

        string firstNumber = firstNumIndex == -1 || firstSpelledOutNumIndex < firstNumIndex
            ? GetString(line, firstSpelledOutNumIndex, firstLength)
            : $"{line[firstNumIndex]}";

        string lastNumber = lastSpelledOutNumIndex > lastNumIndex
            ? GetString(line, lastSpelledOutNumIndex, lastLength)
            : $"{line[lastNumIndex]}";

        int numberResult = int.Parse($"{firstNumber}{lastNumber}");
        return numberResult;
    }

    private static string GetString(string line, int spelledOutIndex, int spelledOutLength)
    {
        string spelledOutNumber = line.Substring(spelledOutIndex, spelledOutLength);
        int spelledOutNumberAsInt = SpelledOutNumbers.ToList()
                                        .IndexOf(spelledOutNumber)
                                    + 1;
        return spelledOutNumberAsInt.ToString();
    }
}