using Aoc.Types;

namespace Day02;

public class Part1 : IPart
{
    private readonly static GameFactory GameFactory = new();

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


        IEnumerable<Game> games = input.Select(GameFactory.Create);

        IEnumerable<int> possibleGames = from game in games
            let maxCubeSetOfGame = game.CubeSets
                .SelectMany(x => x)
                .GroupBy(x => x.Key)
                .ToDictionary(
                    x => x.Key,
                    x => x.Max(y => y.Value)
                )
            where maxCubeSetOfGame.All(x => x.Value <= possibleWith[x.Key])
            select game.Index;

        return possibleGames.Sum()
            .ToString();
    }
}