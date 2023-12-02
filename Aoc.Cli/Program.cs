using Aoc.Cli;
using Aoc.Types;
using Spectre.Console;

Solutions.Year year = Prompt(
    new SelectionPrompt<Solutions.Year>()
        .Title(
            "Choose year"
        )
        .AddChoices(
            Enum.GetValues<Solutions.Year>()
        ),
    Enum.Parse<Solutions.Year>(
        $"_{DateTime.Now.Year}",
        true
    )
);

Solutions.Day day = Prompt(
    new SelectionPrompt<Solutions.Day>()
        .Title(
            "Select day"
        )
        .AddChoices(
            Enum.GetValues<Solutions.Day>()
        ),
    Enum.Parse<Solutions.Day>(
        $"_{DateTime.Now.Day.ToString().PadLeft(2, '0')}",
        true
    )
);

List<Solutions.Part> parts = Prompt(
    new MultiSelectionPrompt<Solutions.Part>()
        .Title(
            "Choose parts to execute"
        )
        .AddChoices(
            Enum.GetValues<Solutions.Part>()
        ),
    new List<Solutions.Part>
    {
        Solutions.Part._1,
        Solutions.Part._2
    }
);

IEnumerable<IPart> solutions = Solutions.GetSolutions(
    year,
    day,
    parts.ToArray()
);

string defaultInputPath =
    $@"C:\Dev\AoC\{year.ToString().Replace("_", null)}\Day{day.ToString().Replace("_", null)}\input.txt";

bool useDefaultInputPath = Prompt(
    new ConfirmationPrompt(
        $"Use default input path ({defaultInputPath})?"
    ),
    true
);

string inputPath = useDefaultInputPath switch
{
    true => Path.Exists(
        defaultInputPath
    )
        ? defaultInputPath
        : throw new InvalidOperationException(
            $"Invalid path {defaultInputPath}"
        ),
    false => AnsiConsole.Prompt(
        new TextPrompt<string>(
                "Enter path"
            ).ValidationErrorMessage(
                "[red]That is not a valid path[/]"
            )
            .Validate(
                Path.Exists
            )
    )
};

foreach (IPart solution in solutions)
{
    AnsiConsole.WriteLine(
        $"Executing {solution.Name} ({solution.Description}):"
    );

    string[] input = await File.ReadAllLinesAsync(
        inputPath
    );

    string? result = solution.Solve(
        input
    );

    AnsiConsole.WriteLine(
        result ?? "[red]No result found[/]"
    );
}

return;

static T Prompt<T>(IPrompt<T> prompt, T onDebugReturn)
{
#if DEBUG
    return onDebugReturn;
#else
    return AnsiConsole.Prompt(
        prompt
    );
#endif
}
