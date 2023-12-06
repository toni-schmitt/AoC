using AoC.Types;

namespace AoC._2023.Day04;

public class Part2 : ISolution
{
    public string Name { get; } = typeof(Part2).FullName
                                  ?? throw new InvalidOperationException();
    public string Description { get; } = "Scratch cards";

    public string? Solve(IEnumerable<string> input)
    {
        IEnumerable<string> cleanInput = CleanInput(
            input
        );

        List<ScratchCard> scratchCards = GetScratchCards(
                cleanInput
            )
            .ToList();

        List<int> points = GetPoints(
                scratchCards
            )
            .ToList();

        List<ScratchCardWithCount> u = X(
            scratchCards,
            points
        );

        return u.Sum(
                x => x.Count
            )
            .ToString();
    }

    private static List<ScratchCardWithCount> X(
        IReadOnlyCollection<ScratchCard> scratchCards,
        List<int> points
    )
    {
        if (scratchCards.Count != points.Count)
        {
            throw new InvalidOperationException();
        }

        using List<int>.Enumerator pointsEnumerator = points.GetEnumerator();

        List<ScratchCardWithCount> scratchCardsWithCount =
            scratchCards.Select(
                    x => new ScratchCardWithCount(
                        x,
                        1
                    )
                )
                .ToList();

        for (
            int i = 0;
            i < scratchCardsWithCount.Count
            && pointsEnumerator.MoveNext();
            ++i
        )
        {
            for (int j = 0; j < scratchCardsWithCount[i].Count; ++j)
            {
                foreach (
                    ScratchCardWithCount scratchCardWithCount in
                    scratchCardsWithCount.Skip(
                            i + 1
                        )
                        .Take(
                            pointsEnumerator.Current
                        )
                )
                {
                    scratchCardWithCount.Count += 1;
                }
            }
        }

        return scratchCardsWithCount;
    }

    private static IEnumerable<int> GetPoints(
        IEnumerable<ScratchCard> scratchCards
    )
        => scratchCards.Select(
                scratchCard => scratchCard.WinningNumbers.Intersect(
                    scratchCard.Numbers
                )
            )
            .Select(
                intersected => intersected.Count()
            );

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

    private record ScratchCardWithCount
    {
        public ScratchCardWithCount(ScratchCard ScratchCard, int Count)
        {
            this.ScratchCard = ScratchCard;
            this.Count = Count;
        }

        public ScratchCard ScratchCard { get; }
        public int Count { get; set; }

        public void Deconstruct(out ScratchCard ScratchCard, out int Count)
        {
            ScratchCard = this.ScratchCard;
            Count = this.Count;
        }
    }
}
