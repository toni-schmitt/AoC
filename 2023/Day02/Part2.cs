using Aoc.Types;

namespace Day02;

public class Part2 : IPart
{
    private readonly static GameFactory GameFactory = new();

    public string? Solve(IEnumerable<string> input)
    {
        IEnumerable<Game> games = input.Select(GameFactory.Create);

        IEnumerable<CubeSet> minCubesNeeded = games.Select(
            game => game.CubeSets
                .SelectMany(x => x)
                .GroupBy(x => x.Key)
                .ToDictionary(
                    x => x.Key,
                    x => x.Max(y => y.Value)
                )
        );

        IEnumerable<int> powers = minCubesNeeded.Select(set => set.Values.Aggregate((i, k) => i * k));

        return powers.Sum()
            .ToString();
    }
}