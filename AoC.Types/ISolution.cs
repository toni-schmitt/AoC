namespace AoC.Types;

public interface ISolution
{
    string Name { get; }
    string Description { get; }

    string? Solve(IEnumerable<string> input);
}
