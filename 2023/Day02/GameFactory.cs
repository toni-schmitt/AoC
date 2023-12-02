namespace Day02;

public class GameFactory
{
    public Game Create(string line)
    {
        int gameIndex = GetGameIndex(line);
        IEnumerable<CubeSet> cubeSets = GetCubeSets(
            line.Replace($"Game {gameIndex}:", null)
                .Trim());

        return new Game(gameIndex, cubeSets);
    }

    private static int GetGameIndex(string line)
    {
        line = line.Replace("Game", null)
            .Trim();

        line = line[..line.IndexOf(':')];

        int gameIndex = int.Parse(line);

        return gameIndex;
    }

    private static IEnumerable<CubeSet> GetCubeSets(string line)
    {
        string[] sets = line.Split(';');

        foreach (string set in sets)
        {
            string[] cubes = set.Trim()
                .Split(',');
            CubeSet cubeSet = GetCubeSet(cubes);

            yield return cubeSet;
        }
    }

    private static CubeSet GetCubeSet(IEnumerable<string> cubes)
    {
        CubeSet cubeSet = new();
        foreach (string cube in cubes)
        {
            string[] x = cube.Trim()
                .Split(' ');
            int numberOfCubes = int.Parse(x[0]);

            var color = Enum.Parse<Color>(x[1], true);

            cubeSet.Add(color, numberOfCubes);
        }

        return cubeSet;
    }
}