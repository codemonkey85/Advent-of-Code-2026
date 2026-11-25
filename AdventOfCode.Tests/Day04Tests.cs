namespace AdventOfCode.Tests;

public sealed class Day04Tests
{
    [Fact]
    public void Scaffold_solves_inline_input()
    {
        const string sample = "alpha\r\n\r\nbeta\n";

        Assert.Equal("2", Day04.SolvePart1(sample));
        Assert.Equal("9", Day04.SolvePart2(sample));
    }
}
