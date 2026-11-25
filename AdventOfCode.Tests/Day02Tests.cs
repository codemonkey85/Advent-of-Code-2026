namespace AdventOfCode.Tests;

public sealed class Day02Tests
{
    [Fact]
    public void Scaffold_solves_inline_input()
    {
        const string sample = "alpha\r\n\r\nbeta\n";

        Assert.Equal("2", Day02.SolvePart1(sample));
        Assert.Equal("9", Day02.SolvePart2(sample));
    }
}
