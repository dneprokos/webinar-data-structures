namespace DataStructuresQA.Linq;

/// <summary>LINQ aggregation: Count, Sum, Average, Min, Max, Aggregate.</summary>
internal static class Aggregation
{
    private static readonly Score[] Scores =
    [
        new("Ann", 92), new("Bob", 85), new("Carl", 78),
        new("Diana", 95), new("Eve", 60),
    ];

    public static void Run()
    {
        BasicAggregates();
        ConditionalAggregates();
        CustomAggregate();
    }

    private static void BasicAggregates()
    {
        Console.WriteLine("=== Basic aggregates ===");
        Console.WriteLine($"Count                = {Scores.Count()}");
        Console.WriteLine($"Sum(Value)           = {Scores.Sum(s => s.Value)}");
        Console.WriteLine($"Average(Value)       = {Scores.Average(s => s.Value):F1}");
        Console.WriteLine($"Min(Value)           = {Scores.Min(s => s.Value)}");
        Console.WriteLine($"Max(Value)           = {Scores.Max(s => s.Value)}");
        Console.WriteLine($"MinBy(Value)         = {Scores.MinBy(s => s.Value)?.Name}");
        Console.WriteLine($"MaxBy(Value)         = {Scores.MaxBy(s => s.Value)?.Name}");
    }

    private static void ConditionalAggregates()
    {
        Console.WriteLine("\n=== Conditional aggregates ===");
        Console.WriteLine($"Count(>= 80)         = {Scores.Count(s => s.Value >= 80)}");
        Console.WriteLine($"Sum where >= 80      = {Scores.Where(s => s.Value >= 80).Sum(s => s.Value)}");
        Console.WriteLine($"Average >= 80        = {Scores.Where(s => s.Value >= 80).Average(s => s.Value):F1}");
    }

    private static void CustomAggregate()
    {
        Console.WriteLine("\n=== Aggregate (fold / reduce) ===");

        // Product of all values.
        var product = Scores.Aggregate(1L, (acc, s) => acc * s.Value);
        Console.WriteLine($"Product of all       = {product}");

        // Build CSV from names.
        var csv = Scores.Aggregate(string.Empty, (acc, s) => acc.Length == 0 ? s.Name : $"{acc},{s.Name}");
        Console.WriteLine($"Names as CSV         = {csv}");

        // Concat strings with seed and result selector.
        var report = Scores.Aggregate(
            seed: "Scores: ",
            func: (acc, s) => $"{acc}[{s.Name}:{s.Value}] ",
            resultSelector: result => result.Trim());
        Console.WriteLine($"Report               = {report}");
    }

    private sealed record Score(string Name, int Value);
}
