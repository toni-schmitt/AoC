namespace Aoc.Types;

public interface IPart
{
    string Name { get; }
    string Description { get; }

    string? Solve(IEnumerable<string> input);
}
