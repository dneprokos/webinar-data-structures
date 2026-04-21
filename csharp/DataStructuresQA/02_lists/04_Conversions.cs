namespace DataStructuresQA.Lists;

/// <summary>Converting List&lt;T&gt; to and from other collection types.</summary>
internal static class Conversions
{
    public static void Run()
    {
        ToArray();
        ToSet();
        ToDictionary();
        ToQueue();
    }

    private static void ToArray()
    {
        Console.WriteLine("=== List → Array ===");
        var list = new List<string> { "smoke", "api", "regression" };
        var arr = list.ToArray();
        Console.WriteLine($"ToArray()         -> [{string.Join(", ", arr)}]  Length={arr.Length}");
    }

    private static void ToSet()
    {
        Console.WriteLine("\n=== List → HashSet (dedup) ===");
        var with = new List<int> { 1, 2, 2, 3, 3, 3 };
        var set = with.ToHashSet();
        Console.WriteLine($"ToHashSet()       -> [{string.Join(", ", set.Order())}]");
    }

    private static void ToDictionary()
    {
        Console.WriteLine("\n=== List → Dictionary ===");

        var employees = new List<Employee>
        {
            new("e1", "Ann"),
            new("e2", "Bob"),
        };

        var byId = employees.ToDictionary(e => e.Id);
        Console.WriteLine($"ToDictionary(Id)  -> found e1: {byId["e1"].Name}");

        var idToName = employees.ToDictionary(e => e.Id, e => e.Name);
        Console.WriteLine($"key→value         -> {string.Join(", ", idToName.Select(kv => $"{kv.Key}={kv.Value}"))}");
    }

    private static void ToQueue()
    {
        Console.WriteLine("\n=== List → Queue ===");
        var jobs = new List<string> { "sync", "purge", "notify" };
        var queue = new Queue<string>(jobs);
        Console.WriteLine($"Queue count       = {queue.Count}");
        Console.WriteLine($"Dequeue()         = {queue.Dequeue()}");
    }

    private sealed record Employee(string Id, string Name);
}
