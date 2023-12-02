using System.Buffers;
using Aoc.Types;

namespace Day01;

public class Part1 : IPart
{
    private readonly static SearchValues<char> NumbersSearchValues =
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
                NumbersSearchValues
            )
        let lastNumIndex = line.AsSpan()
            .LastIndexOfAny(
                NumbersSearchValues
            )
        select int.Parse(
            $"{line[firstNumIndex]}{line[lastNumIndex]}"
        );
}
