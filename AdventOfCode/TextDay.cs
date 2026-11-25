namespace AdventOfCode;

public abstract class TextDay(
    Func<string, string> part1,
    Func<string, string> part2) : BaseDay
{
    private string Input => field ??=
        File.ReadAllText(Path.GetFullPath(InputFilePath, AppContext.BaseDirectory));

    public sealed override ValueTask<string> Solve_1() => new(part1(Input));

    public sealed override ValueTask<string> Solve_2() => new(part2(Input));
}
