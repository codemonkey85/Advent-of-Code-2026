# Advent of Code 2026

[![CI](https://github.com/codemonkey85/Advent-of-Code-2026/actions/workflows/ci.yml/badge.svg)](https://github.com/codemonkey85/Advent-of-Code-2026/actions/workflows/ci.yml)

Based on [AoCTemplate](https://github.com/eduherminio/AdventOfCode.Template) by [eduherminio](https://github.com/eduherminio).

## Run puzzles

Install the .NET 11 SDK specified in `global.json`. From the repository root:

```console
dotnet run --project AdventOfCode                # Latest implemented day
dotnet run --project AdventOfCode -- 1           # Day 1
dotnet run --project AdventOfCode -- 1 2         # Specific days, once implemented
dotnet run --project AdventOfCode -- all         # All implemented days
dotnet run --project AdventOfCode -- --plain 1   # Plain text, no live display
```

Plain output is automatic when standard input or output is redirected. Put your personal input in `AdventOfCode/Inputs/01.txt` for Day 1, `02.txt` for Day 2, and so on. Create the directory if needed. Inputs are ignored by Git and copied to the build output.

## Add and test a day

1. Add a `DayXX` class under `AdventOfCode/Days` using `DayXX() : TextDay(DayXX.SolvePart1, DayXX.SolvePart2)`. The two static solver methods take the raw input and return an answer string. `TextDay` loads the input on the first solve and reuses it for both parts. For days that need custom input handling, inherit `BaseDay` directly.
2. Add an inline sample test in `AdventOfCode.Tests`. `Day01` and its test currently demonstrate the pattern with placeholder logic. Replace both with the real puzzle and sample when available.
3. Record verified personal answers with `[AocExpected("123", "456")]`. An omitted or `null` answer generates no test for that part. An explicit empty string generates a test.

```console
dotnet test AdventOfCode.slnx --filter "Category!=RealInput"
dotnet test AdventOfCode.slnx --filter "Category=RealInput"
```

The first command matches CI and needs no personal files. The second runs the generated personal-answer tests and needs the inputs for those days. Run `dotnet test AdventOfCode.slnx` for both.
