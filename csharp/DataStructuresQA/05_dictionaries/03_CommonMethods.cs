namespace DataStructuresQA.Dictionaries;

/// <summary>Add, update, remove, merge, and other Dictionary methods.</summary>
internal static class CommonMethods
{
    public static void Run()
    {
        AddUpdate();
        Remove();
        Merge();
        FrequencyMap();
    }

    private static void AddUpdate()
    {
        Console.WriteLine("=== Add & Update ===");
        var d = new Dictionary<string, int>();
        d["a"] = 1;
        d["b"] = 2;
        Console.WriteLine($"After add a,b      -> Count={d.Count}");
        d["a"] = 99;
        Console.WriteLine($"After update a=99  -> a={d["a"]}");
        d.TryAdd("c", 3);
        Console.WriteLine($"TryAdd c=3         -> c={d["c"]}");
        d.TryAdd("c", 999);
        Console.WriteLine($"TryAdd c=999       -> c={d["c"]}  (no change — key already exists)");
    }

    private static void Remove()
    {
        Console.WriteLine("\n=== Remove ===");
        var d = new Dictionary<string, int> { ["x"] = 1, ["y"] = 2, ["z"] = 3 };
        d.Remove("y");
        Console.WriteLine($"Remove('y')        -> [{string.Join(", ", d.Keys.OrderBy(k => k))}]");
        d.Clear();
        Console.WriteLine($"Clear()            -> Count={d.Count}");
    }

    private static void Merge()
    {
        Console.WriteLine("\n=== Merge two dictionaries ===");
        var d1 = new Dictionary<string, int> { ["a"] = 1, ["b"] = 2 };
        var d2 = new Dictionary<string, int> { ["b"] = 99, ["c"] = 3 };

        // d2 wins on conflict.
        var merged = d1.Concat(d2)
            .GroupBy(kv => kv.Key)
            .ToDictionary(g => g.Key, g => g.Last().Value);

        foreach (var (k, v) in merged.OrderBy(kv => kv.Key))
            Console.WriteLine($"  {k}={v}");
    }

    private static void FrequencyMap()
    {
        Console.WriteLine("\n=== Frequency map (count occurrences) ===");
        var words = new[] { "api", "smoke", "api", "regression", "smoke", "api" };

        var freq = new Dictionary<string, int>();
        foreach (var w in words)
            freq[w] = freq.GetValueOrDefault(w) + 1;

        foreach (var (word, count) in freq.OrderByDescending(kv => kv.Value))
            Console.WriteLine($"  {word,-12} x{count}");
    }
}
