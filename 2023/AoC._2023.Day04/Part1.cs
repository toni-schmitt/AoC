using AoC.Types;

namespace AoC._2023.Day04;

public class Part1 : ISolution
{
    public string Name { get; } = typeof(Part1).FullName
                                  ?? throw new InvalidOperationException();
    public string Description { get; } = "Scratch cards";

    public string? Solve(IEnumerable<string> input)
    {
        List<ScratchCard> scratchCards = GetScratchCards(
                CleanInput(
                    input
                )
            )
            .ToList();

        IEnumerable<int> points = GetPoints(
            scratchCards
        );

        return points.Sum()
            .ToString();
    }

    private static IEnumerable<int> GetPoints(
        IEnumerable<ScratchCard> scratchCards
    )
    {
        foreach (ScratchCard scratchCard in scratchCards)
        {
            List<int> intersected = scratchCard.WinningNumbers.Intersect(
                    scratchCard.Numbers
                )
                .ToList();

            int points = 0;

            for (int i = 0; i < intersected.Count; ++i)
            {
                points = (i == 0) switch
                {
                    true => points + 1,
                    false => points * 2
                };
            }

            yield return points;
        }
    }

    private static IEnumerable<string> CleanInput(IEnumerable<string> input)
        => input.Select(
            (x, i) => x.Trim()
                .Replace(
                    "Card",
                    null
                )
                .Trim()
                .Replace(
                    $"{i + 1}:",
                    null
                )
                .Trim()
        );

    private static IEnumerable<ScratchCard> GetScratchCards(
        IEnumerable<string> input
    )
    {
        foreach (string line in input)
        {
            string[] parts = line.Trim()
                .Split(
                    '|'
                )
                .Select(
                    x => x.Trim()
                )
                .ToArray();

            Console.WriteLine(
                $"{nameof(parts)}: {string.Join(", ", parts)}"
            );

            IEnumerable<int> winningNumbers = parts[0]
                .Split(
                    ' '
                )
                .Where(
                    x => string.IsNullOrWhiteSpace(
                        x
                    ) is false
                )
                .Select(
                    int.Parse
                )
                .ToList();

            IEnumerable<int> numbers = parts[1]
                .Split(
                    ' '
                )
                .Where(
                    x => string.IsNullOrWhiteSpace(
                        x
                    ) is false
                )
                .Select(
                    int.Parse
                )
                .ToList();

            yield return new ScratchCard(
                winningNumbers,
                numbers
            );
        }
    }
}
