using AoC.Types;

namespace AoC._2023.Day02;

public class Part1 : ISolution
{
    private static readonly GameFactory s_gameFactory = new();

    public string Name { get; } = typeof(Part1).FullName
                                  ?? throw new InvalidOperationException();
    public string Description { get; } = "Elves have the most boring games";

    public string? Solve(IEnumerable<string> input)
    {
        CubeSet possibleWith = new()
        {
            {
                Color.Red, 12
            },
            {
                Color.Green, 13
            },
            {
                Color.Blue, 14
            }
        };

        IEnumerable<Game> games = input.Select(
            s_gameFactory.Create
        );

        IEnumerable<int> possibleGames = from game in games
            let maxCubeSetOfGame = game.CubeSets
                .SelectMany(
                    x => x
                )
                .GroupBy(
                    x => x.Key
                )
                .ToDictionary(
                    x => x.Key,
                    x => x.Max(
                        y => y.Value
                    )
                )
            where maxCubeSetOfGame.All(
                x => x.Value <= possibleWith[x.Key]
            )
            select game.Index;

        return possibleGames.Sum()
            .ToString();
    }
}
