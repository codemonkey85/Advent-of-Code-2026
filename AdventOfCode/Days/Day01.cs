namespace AdventOfCode.Days;

[AocExpected]
public sealed class Day01 : BaseDay
{
    private readonly string input;

    public Day01() => input = File.ReadAllText(Path.GetFullPath(InputFilePath, AppContext.BaseDirectory));

    public override ValueTask<string> Solve_1() => new(SolvePart1(input));

    public override ValueTask<string> Solve_2() => new(SolvePart2(input));

    // Smoke-test logic for the scaffold. Replace it when the puzzle is released.
    public static string SolvePart1(string input) => ReadLines(input).Length.ToString(CultureInfo.InvariantCulture);

    public static string SolvePart2(string input) => ReadLines(input).Sum(line => line.Length)
        .ToString(CultureInfo.InvariantCulture);

    private static string[] ReadLines(string input) => input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
}
