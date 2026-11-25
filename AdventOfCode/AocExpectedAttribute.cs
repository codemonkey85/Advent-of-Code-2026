using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
// A null answer means that part is not ready for a regression test.
public sealed class AocExpectedAttribute(string? part1 = null, string? part2 = null) : Attribute
{
    public string? Part1 { get; } = part1;

    public string? Part2 { get; } = part2;
}
