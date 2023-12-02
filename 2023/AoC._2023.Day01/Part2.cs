using System.Buffers;
using AoC.Types;

namespace AoC._2023.Day01;

public class Part2 : ISolution
{
    private static readonly SearchValues<char> s_numbersSearchValues =
        SearchValues.Create(
            "123456789"
        );

    private static readonly string[] s_spelledOutNumbers =
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

    public string Name { get; } = typeof(Part2).FullName
                                  ?? throw new InvalidOperationException();
    public string Description { get; } =
        "s_p_e_l_l_e_d___o_u_t___T_R_E_B_U_C_H_E_T";

    public string? Solve(IEnumerable<string> input)
    {
        IEnumerable<int> nums = GetNumbersFromInput(
            input
        );

        return nums.Sum()
            .ToString();
    }

    private static IEnumerable<int> GetNumbersFromInput(
        IEnumerable<string> input
    ) => input.Select(
        GetNumberFromLine
    );

    private static int GetNumberFromLine(string line)
    {
        int firstNumIndex = line.AsSpan()
            .IndexOfAny(
                s_numbersSearchValues
            );

        int lastNumIndex = line.AsSpan()
            .LastIndexOfAny(
                s_numbersSearchValues
            );

        (int firstSpelledOutNumIndex, int firstLength) =
            line.IndexAndLengthOfAny(
                s_spelledOutNumbers
            );

        (int lastSpelledOutNumIndex, int lastLength) =
            line.LastIndexAndLengthOfAny(
                s_spelledOutNumbers
            );

        string firstNumber =
            firstNumIndex == -1 || firstSpelledOutNumIndex < firstNumIndex
                ? GetString(
                    line,
                    firstSpelledOutNumIndex,
                    firstLength
                )
                : $"{line[firstNumIndex]}";

        string lastNumber = lastSpelledOutNumIndex > lastNumIndex
            ? GetString(
                line,
                lastSpelledOutNumIndex,
                lastLength
            )
            : $"{line[lastNumIndex]}";

        int numberResult = int.Parse(
            $"{firstNumber}{lastNumber}"
        );

        return numberResult;
    }

    private static string GetString(
        string line,
        int spelledOutIndex,
        int spelledOutLength
    )
    {
        string spelledOutNumber = line.Substring(
            spelledOutIndex,
            spelledOutLength
        );

        int spelledOutNumberAsInt = s_spelledOutNumbers.ToList()
                                        .IndexOf(
                                            spelledOutNumber
                                        )
                                    + 1;

        return spelledOutNumberAsInt.ToString();
    }
}
