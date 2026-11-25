namespace AdventOfCode.Days;

[AocExpected("", "")]
public sealed class Day01 : BaseDay
{
    private readonly string input;

    public Day01() => input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1");

    public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2");
}
