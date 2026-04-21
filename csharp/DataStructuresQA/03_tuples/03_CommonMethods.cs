namespace DataStructuresQA.Tuples;

/// <summary>Comparing, sorting, and using tuples in collections.</summary>
internal static class CommonMethods
{
    public static void Run()
    {
        Equality();
        SortingWithTuples();
        TupleInCollections();
    }

    private static void Equality()
    {
        Console.WriteLine("=== Equality ===");

        var a = (1, "hello");
        var b = (1, "hello");
        var c = (2, "hello");

        Console.WriteLine($"a == b: {a == b}");
        Console.WriteLine($"a == c: {a == c}");
    }

    private static void SortingWithTuples()
    {
        Console.WriteLine("\n=== Sort by tuple — lexicographic ===");

        var scores = new[] { ("Bob", 85), ("Ann", 92), ("Ann", 78) };

        // Sort by Name first, then by Score descending.
        var sorted = scores
            .OrderBy(t => t.Item1)
            .ThenByDescending(t => t.Item2)
            .ToArray();

        foreach (var (name, score) in sorted)
            Console.WriteLine($"  {name}: {score}");
    }

    private static void TupleInCollections()
    {
        Console.WriteLine("\n=== Tuples in collections ===");

        // Dictionary with tuple value.
        var config = new Dictionary<string, (string Value, bool IsSecret)>
        {
            ["db_host"] = ("localhost", false),
            ["db_pass"] = ("s3cr3t", true),
        };

        foreach (var (key, (value, isSecret)) in config)
            Console.WriteLine($"  {key} = {(isSecret ? "***" : value)}");
    }
}
