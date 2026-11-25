namespace AdventOfCode.Days;

[AocExpected]
public sealed class Day12() : TextDay(SolvePart1, SolvePart2)
{
    // Smoke-test logic for the scaffold. Replace it when the puzzle is released.
    public static string SolvePart1(string input) => ReadLines(input).Length.ToString(CultureInfo.InvariantCulture);

    public static string SolvePart2(string input) => ReadLines(input).Sum(line => line.Length)
        .ToString(CultureInfo.InvariantCulture);

    private static string[] ReadLines(string input) => input.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
}
