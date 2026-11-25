namespace AdventOfCode.Tests;

public sealed class Day09Tests
{
    [Fact]
    public void Scaffold_solves_inline_input()
    {
        const string sample = "alpha\r\n\r\nbeta\n";

        Assert.Equal("2", Day09.SolvePart1(sample));
        Assert.Equal("9", Day09.SolvePart2(sample));
    }
}
