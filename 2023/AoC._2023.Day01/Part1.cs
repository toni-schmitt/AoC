using System.Buffers;
using AoC.Types;

namespace AoC._2023.Day01;

public class Part1 : ISolution
{
    private static readonly SearchValues<char> s_numbersSearchValues =
        SearchValues.Create(
            "0123456789"
        );

    public string Name { get; } = typeof(Part1).FullName
                                  ?? throw new InvalidOperationException();
    public string Description { get; } = "TREBUCHET";

    public string? Solve(IEnumerable<string> input)
    {
        IEnumerable<int> nums = GetNumbersFromInput(
                input
            )
            .ToList();

        return nums.Sum()
            .ToString();
    }

    private static IEnumerable<int> GetNumbersFromInput(
        IEnumerable<string> input
    ) => from line in input
        let firstNumIndex = line.AsSpan()
            .IndexOfAny(
                s_numbersSearchValues
            )
        let lastNumIndex = line.AsSpan()
            .LastIndexOfAny(
                s_numbersSearchValues
            )
        select int.Parse(
            $"{line[firstNumIndex]}{line[lastNumIndex]}"
        );
}
