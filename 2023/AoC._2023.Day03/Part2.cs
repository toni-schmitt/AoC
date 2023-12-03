using AoC.Types;

namespace AoC._2023.Day03;

public class Part2 : ISolution
{

    public string Name { get; } = typeof(Part2).FullName
                                  ?? throw new InvalidOperationException();
    public string Description { get; } =
        "Fixing the gondolas now with gears (still some spaghetti)";

    public string? Solve(IEnumerable<string> input) => Solve(
            input.ToList()
        )
        .ToString();

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

                List<int> numbersAdjacentToSymbol = new List<int>();

                if (char.IsNumber(
                        input[i][j - 1]
                    ))
                {

                    int nbr = GetNumberAdjacentToSymbol(
                        input,
                        (i, j - 1)
                    );

                    numbersAdjacentToSymbol.Add(
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

                    numbersAdjacentToSymbol.Add(
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

                    numbersAdjacentToSymbol.Add(
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

                        numbersAdjacentToSymbol.Add(
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

                        numbersAdjacentToSymbol.Add(
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

                    numbersAdjacentToSymbol.Add(
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

                        numbersAdjacentToSymbol.Add(
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

                        numbersAdjacentToSymbol.Add(
                            nbr
                        );
                    }
                }

                if (numbersAdjacentToSymbol.Count != 2)
                {
                    continue;
                }

                numbersAdjacentToSymbols.Add(
                    numbersAdjacentToSymbol[0] * numbersAdjacentToSymbol[1]
                );
            }
        }

        return numbersAdjacentToSymbols.Sum();
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
        => c == '*';
}
