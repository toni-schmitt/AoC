using AoC.Types;

namespace AoC._2023.Day03;

public class Part1 : ISolution
{

    public string Name { get; } = typeof(Part1).FullName
                                  ?? throw new InvalidOperationException();
    public string Description { get; } =
        "Fixing the gondolas (with some spaghetti)";

    public string? Solve(IEnumerable<string> input) => Solve(
            input.ToList()
        )
        .ToString();

    // we love us some good spaghetti
    private int Solve(IList<string> input)
    {
        Console.Error.WriteLine(
            "Solving..."
        );

        List<int> numbersAdjacentToSymbols = new();

        for (int i = 0; i < input.Count; ++i)
        {
            for (int j = 0; j < input[i].Length; ++j)
            {
                if (IsSymbol(
                        input[i][j]
                    ) is false)
                {
                    continue;
                }
                //
                // // List<(int i, int j)> possibleIndexesOfAnAdjacentNumberInLine = new List<(int i, int j)>
                // // {
                // //     (i, j - 1), // left of symbol
                // //     (i, j + 1), // right of symbol
                // //     // (i - 1, j), // above symbol
                // //     // (i - 1, j - 1), // above and left of symbol
                // //     // (i - 1, j + 1), // above and right of symbol
                // //     // (i + 1, j), // below symbol
                // //     // (i + 1, j - 1), // below and left of symbol
                // //     // (i + 1, j + 1), // below and right of symbol
                // // };
                //
                // var possibleIndexSetsOfAnAdjacentNumber =
                //     new List<List<(int, int)>>()
                //     {
                //         new()
                //         {
                //             (i, j - 1) // left of symbol
                //         },
                //         new()
                //         {
                //             (i, j + 1) // right of symbol
                //         },
                //         new()
                //         {
                //             (i - 1, j), // above symbol
                //             (i - 1, j - 1), // above and left of symbol
                //             (i - 1, j + 1), // above and right of symbol
                //         },
                //         new()
                //         {
                //             (i + 1, j), // below symbol
                //             (i + 1, j - 1), // below and left of symbol
                //             (i + 1, j + 1), // below and right of symbol
                //         }
                //     };
                //
                // // foreach (var possibleIndexesOfAnAdjacentNumber in
                // //          possibleIndexSetsOfAnAdjacentNumber)
                // // {
                // //     var nbrs = GetNumbersAdjacentToSymbol(
                // //             input,
                // //             possibleIndexesOfAnAdjacentNumber
                // //         )
                // //         .ToList();
                // //
                // //     if (nbrs.Count == 0)
                // //     {
                // //         continue;
                // //     }
                // //
                // //     Console.Error.WriteLine(
                // //         $"Found {nbrs.Count} nbrs adjacent to symbol at ({i}, {j}): {string.Join(", ", nbrs)}"
                // //     );
                // //
                // //     numbersAdjacentToSymbols.AddRange(
                // //         nbrs
                // //     );
                // //
                // // }
                //
                // // numbersAdjacentToSymbols.AddRange(
                // //     possibleIndexesOfAnAdjacentNumber.Where(
                // //             idx => char.IsNumber(
                // //                 input[idx.i][idx.j]
                // //             )
                // //         )
                // //         .Select(
                // //             idx => GetNumberAdjacentToSymbol(
                // //                 input: input,
                // //                 numberIndex: idx
                // //             )
                // //         )
                // // );

                if (char.IsNumber(
                        input[i][j - 1]
                    ))
                {

                    int nbr = GetNumberAdjacentToSymbol(
                        input,
                        (i, j - 1)
                    );

                    numbersAdjacentToSymbols.Add(
                        nbr
                    );
                }

                if (char.IsNumber(
                        input[i][j + 1]
                    ))
                {
                    int nbr = GetNumberAdjacentToSymbol(
                        input,
                        (i, j + 1)
                    );

                    numbersAdjacentToSymbols.Add(
                        nbr
                    );
                }

                if (char.IsNumber(
                        input[i - 1][j]
                    ))
                {
                    int nbr = GetNumberAdjacentToSymbol(
                        input,
                        (i - 1, j)
                    );

                    numbersAdjacentToSymbols.Add(
                        nbr
                    );
                }
                else
                {
                    if (char.IsNumber(
                            input[i - 1][j - 1]
                        ))
                    {
                        int nbr = GetNumberAdjacentToSymbol(
                            input,
                            (i - 1, j - 1)
                        );

                        numbersAdjacentToSymbols.Add(
                            nbr
                        );
                    }

                    if (char.IsNumber(
                            input[i - 1][j + 1]
                        ))
                    {
                        int nbr = GetNumberAdjacentToSymbol(
                            input,
                            (i - 1, j + 1)
                        );

                        numbersAdjacentToSymbols.Add(
                            nbr
                        );
                    }
                }

                if (char.IsNumber(
                        input[i + 1][j]
                    ))
                {
                    int nbr = GetNumberAdjacentToSymbol(
                        input,
                        (i + 1, j)
                    );

                    numbersAdjacentToSymbols.Add(
                        nbr
                    );
                }
                else
                {
                    if (char.IsNumber(
                            input[i + 1][j - 1]
                        ))
                    {
                        int nbr = GetNumberAdjacentToSymbol(
                            input,
                            (i + 1, j - 1)
                        );

                        numbersAdjacentToSymbols.Add(
                            nbr
                        );
                    }

                    if (char.IsNumber(
                            input[i + 1][j + 1]
                        ))
                    {
                        int nbr = GetNumberAdjacentToSymbol(
                            input,
                            (i + 1, j + 1)
                        );

                        numbersAdjacentToSymbols.Add(
                            nbr
                        );
                    }
                }
            }
        }

        return numbersAdjacentToSymbols.Sum();
    }

    private static IEnumerable<int> GetNumbersAdjacentToSymbol(
        IList<string> input,
        IEnumerable<(int i, int j)> possibleIndexesOfAnAdjacentNumber
    )
    {
        (int i, int j)? x = FirstOrNull(
            possibleIndexesOfAnAdjacentNumber,
            idx =>
                idx is {i: >= 0, j: >= 0}
                && idx.i < input.Count
                && idx.j < input[idx.i].Length
                && char.IsNumber(
                    input[idx.i][idx.j]
                )
        );

        if (x is null)
        {
            yield break;
        }

        yield return GetNumberAdjacentToSymbol(
            input,
            x.Value
        );
    }

    private static TSource? FirstOrNull<TSource>(
        IEnumerable<TSource> source,
        Func<TSource, bool> predicate
    )
        where TSource : struct
    {
        try
        {
            return source.First(
                predicate
            );
        }
        catch
        {
            return null;
        }
    }

    private static int GetNumberAdjacentToSymbol(
        IList<string> input,
        (int i, int j) numberIndex
    )
    {
        int numberStartIndex = numberIndex.j;
        int numberEndIndex = numberIndex.j;

        for (int i = numberIndex.j; i >= 0; --i)
        {
            if (char.IsNumber(
                    input[numberIndex.i][i]
                ))
            {
                numberStartIndex = i;
            }
            else
            {
                break;
            }
        }

        for (int i = numberIndex.j; i < input[numberIndex.i].Length; ++i)
        {
            if (char.IsNumber(
                    input[numberIndex.i][i]
                ))
            {
                numberEndIndex = i;
            }
            else
            {
                break;
            }
        }

        string x = input[numberIndex.i][numberStartIndex..(numberEndIndex + 1)];

        return int.Parse(
            x
        );
    }

    private static bool IsSymbol(char c)
        => char.IsNumber(
               c
           ) is false
           && c != '.';
}
