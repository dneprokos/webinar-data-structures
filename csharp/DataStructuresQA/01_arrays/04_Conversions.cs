namespace DataStructuresQA.Arrays;

/// <summary>Converting arrays and lists to/from other collection types.</summary>
internal static class Conversions
{
    public static void Run()
    {
        ArrayToList();
        ListToArray();
        ToSet();
        ToDictionary();
        ToJoinedString();
    }

    private static void ArrayToList()
    {
        Console.WriteLine("=== Array → List<T> ===");

        int[] arr = { 1, 2, 3, 4, 5 };

        var list = arr.ToList();
        Console.WriteLine($"arr.ToList()         -> Count={list.Count}  [{string.Join(", ", list)}]");

        var list2 = new List<int>(arr);
        Console.WriteLine($"new List<int>(arr)   -> Count={list2.Count}  [{string.Join(", ", list2)}]");
    }

    private static void ListToArray()
    {
        Console.WriteLine("\n=== List<T> → Array ===");

        var list = new List<string> { "smoke", "api", "regression" };

        var arr = list.ToArray();
        Console.WriteLine($"list.ToArray()       -> Length={arr.Length}  [{string.Join(", ", arr)}]");
    }

    private static void ToSet()
    {
        Console.WriteLine("\n=== Array / List → HashSet (dedup) ===");

        var withDups = new[] { 1, 2, 2, 3, 3, 3 };
        var unique = withDups.ToHashSet();
        Console.WriteLine($"ToHashSet()          -> [{string.Join(", ", unique.Order())}]  (duplicates removed)");
    }

    private static void ToDictionary()
    {
        Console.WriteLine("\n=== Array → Dictionary ===");

        var employees = new[]
        {
            new { Id = "e1", Name = "Ann" },
            new { Id = "e2", Name = "Bob" },
        };

        var byId = employees.ToDictionary(e => e.Id, e => e.Name);
        foreach (var (id, name) in byId)
            Console.WriteLine($"  [{id}] = {name}");
    }

    private static void ToJoinedString()
    {
        Console.WriteLine("\n=== Array → string (join) ===");

        var ids = new[] { 2, 5, 7 };
        Console.WriteLine($"string.Join(\",\", ids) -> {string.Join(",", ids)}");

        var csv = new[] { "Alice", "Bob", "Charlie" };
        Console.WriteLine($"CSV line             -> {string.Join(", ", csv)}");
    }
}
