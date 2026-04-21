namespace DataStructuresQA.Dictionaries;

/// <summary>Converting Dictionary to/from other collection types.</summary>
internal static class Conversions
{
    public static void Run()
    {
        Console.WriteLine("=== Array → Dictionary ===");
        var employees = new[] { new { Id = "e1", Name = "Ann" }, new { Id = "e2", Name = "Bob" } };
        var byId = employees.ToDictionary(e => e.Id);
        Console.WriteLine($"ToDictionary(e=>e.Id)   -> found e1: {byId["e1"].Name}");

        Console.WriteLine("\n=== Dictionary → List of pairs ===");
        var d = new Dictionary<string, int> { ["a"] = 1, ["b"] = 2 };
        var pairs = d.Select(kv => (kv.Key, kv.Value)).ToList();
        Console.WriteLine($"Select kv pair          -> {string.Join(", ", pairs.Select(p => $"({p.Key},{p.Value})"))}");

        Console.WriteLine("\n=== Dictionary → sorted keys list ===");
        var keys = d.Keys.OrderBy(k => k).ToList();
        Console.WriteLine($"Keys sorted             -> [{string.Join(", ", keys)}]");

        Console.WriteLine("\n=== GroupBy → Dictionary of lists ===");
        var scores = new[] { ("Ann", "pass"), ("Bob", "fail"), ("Carl", "pass"), ("Dan", "fail") };
        var byStatus = scores
            .GroupBy(t => t.Item2)
            .ToDictionary(g => g.Key, g => g.Select(t => t.Item1).ToList());

        foreach (var (status, names) in byStatus)
            Console.WriteLine($"  {status}: [{string.Join(", ", names)}]");
    }
}
