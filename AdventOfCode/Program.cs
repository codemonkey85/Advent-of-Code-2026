const string usage = "Usage: dotnet run --project AdventOfCode -- [--plain] [all | DAY [DAY ...]]";

if (args is ["--help"] or ["-h"])
{
    Console.WriteLine(usage);
    return 0;
}

var plain = Console.IsOutputRedirected || Console.IsInputRedirected;
var all = false;
var requested = new HashSet<uint>();

foreach (var arg in args)
{
    if (arg == "--plain")
    {
        plain = true;
    }
    else if (arg.Equals("all", StringComparison.OrdinalIgnoreCase))
    {
        all = true;
    }
    else if (uint.TryParse(arg, NumberStyles.None, CultureInfo.InvariantCulture, out var day) && day > 0)
    {
        requested.Add(day);
    }
    else
    {
        Console.Error.WriteLine($"Invalid argument '{arg}'.");
        Console.Error.WriteLine(usage);
        return 2;
    }
}

if (all && requested.Count > 0)
{
    Console.Error.WriteLine("Choose either 'all' or specific days.");
    Console.Error.WriteLine(usage);
    return 2;
}

var available = new SortedDictionary<uint, Type>();
foreach (var type in typeof(Program).Assembly.GetExportedTypes())
{
    if (!type.IsAbstract && !type.ContainsGenericParameters && type.IsSubclassOf(typeof(BaseDay)) &&
        type.Name.StartsWith("Day", StringComparison.Ordinal) &&
        uint.TryParse(type.Name.AsSpan(3).TrimStart('_'), NumberStyles.None, CultureInfo.InvariantCulture, out var day))
    {
        available.Add(day, type);
    }
}

foreach (var day in requested)
{
    if (!available.ContainsKey(day))
    {
        Console.Error.WriteLine($"Day {day} is not implemented.");
        return 2;
    }
}

if (available.Count == 0)
{
    Console.Error.WriteLine("No puzzle days are implemented.");
    return 1;
}

var selected = all
    ? available.ToArray()
    : requested.Count == 0
        ? [available.Last()]
        : [.. available.Where(entry => requested.Contains(entry.Key))];

try
{
    if (plain)
    {
        foreach (var (number, type) in selected)
        {
            var day = (BaseDay)Activator.CreateInstance(type)!;
            Console.WriteLine($"Day {number:00} Part 1: {await day.Solve_1()}");
            Console.WriteLine($"Day {number:00} Part 2: {await day.Solve_2()}");
        }
    }
    else
    {
        await Solver.Solve(selected.Select(entry => entry.Value), options =>
        {
            options.ClearConsole = false;
            options.ShowConstructorElapsedTime = all;
            options.ShowTotalElapsedTimePerDay = all;
        });
    }
}
catch (Exception exception) when (exception.GetBaseException() is FileNotFoundException or DirectoryNotFoundException)
{
    Console.Error.WriteLine($"Unable to run the puzzle: {exception.GetBaseException().Message}");
    Console.Error.WriteLine("Put your personal input in AdventOfCode/Inputs/XX.txt and rebuild.");
    return 1;
}

return 0;
