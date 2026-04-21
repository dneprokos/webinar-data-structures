namespace DataStructuresQA.Tuples;

/// <summary>Converting tuples to/from other types in C#.</summary>
internal static class Conversions
{
    public static void Run()
    {
        TupleToRecord();
        TupleToList();
        DictionaryEntriesToTuples();
    }

    private static void TupleToRecord()
    {
        Console.WriteLine("=== Tuple → record (when you need behavior) ===");

        var raw = (Id: "u1", Name: "Ann", Role: "admin");
        var dto = new UserDto(raw.Id, raw.Name, raw.Role);
        Console.WriteLine($"Tuple → record: {dto}");
    }

    private static void TupleToList()
    {
        Console.WriteLine("\n=== List of tuples ===");

        var items = new List<(string Name, int Price)>
        {
            ("Invisibility Cloak", 10),
            ("Time-Turner", 9),
            ("Elder Wand", 12),
        };

        var prices = items.Select(t => t.Price).ToList();
        Console.WriteLine($"Prices: [{string.Join(", ", prices)}]");

        var expensive = items.Where(t => t.Price > 9).Select(t => t.Name).ToList();
        Console.WriteLine($"Price > 9: [{string.Join(", ", expensive)}]");
    }

    private static void DictionaryEntriesToTuples()
    {
        Console.WriteLine("\n=== Dictionary entries → list of tuples ===");

        var env = new Dictionary<string, string>
        {
            ["BASE_URL"] = "https://api.example.com",
            ["TIMEOUT"] = "30",
        };

        var pairs = env.Select(kv => (Key: kv.Key, Value: kv.Value)).ToList();
        foreach (var (key, value) in pairs)
            Console.WriteLine($"  {key} = {value}");
    }

    private sealed record UserDto(string Id, string Name, string Role);
}
