namespace AoC._2023.Day01;

internal static class StringExtensions
{
    public static (int Index, int Length) IndexAndLengthOfAny(
        this string s,
        params string[] values
    )
    {
        List<(int Index, int Length)> indexes = GetIndexes(
                s,
                true,
                values
            )
            .ToList();

        return indexes switch
        {
            {Count: 0} => (int.MaxValue, 0),
            _ => indexes.MinBy(
                x => x.Index
            )
        };
    }

    public static (int Index, int Length) LastIndexAndLengthOfAny(
        this string s,
        params string[] values
    )
    {
        List<(int Index, int Length)> indexes = GetIndexes(
                s,
                false,
                values
            )
            .ToList();

        return indexes switch
        {
            {Count: 0} => (int.MinValue, 0),
            _ => indexes.MaxBy(
                x => x.Index
            )
        };
    }

    private static IEnumerable<(int Index, int Length)> GetIndexes(
        string s,
        bool firstIndexOf = true,
        params string[] values
    )
        => from value in values
            let index = firstIndexOf switch
            {
                true => s.IndexOf(
                    value,
                    StringComparison.Ordinal
                ),
                false => s.LastIndexOf(
                    value,
                    StringComparison.Ordinal
                )
            }
            select (Index: index, value.Length)
            into indexAndLength
            where indexAndLength.Index != -1
            select indexAndLength;
}
