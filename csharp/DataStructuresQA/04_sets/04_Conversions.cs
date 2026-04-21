namespace DataStructuresQA.Sets;

/// <summary>Converting HashSet to/from other collection types.</summary>
internal static class Conversions
{
    public static void Run()
    {
        Console.WriteLine("=== Array → HashSet (dedup) ===");
        var arr = new[] { 1, 2, 2, 3, 3, 3 };
        var set = arr.ToHashSet();
        Console.WriteLine($"ToHashSet()        -> [{string.Join(", ", set.Order())}]");

        Console.WriteLine("\n=== HashSet → sorted List ===");
        var roles = new HashSet<string> { "viewer", "admin", "editor" };
        var sorted = roles.OrderBy(r => r).ToList();
        Console.WriteLine($"OrderBy.ToList()   -> [{string.Join(", ", sorted)}]");

        Console.WriteLine("\n=== HashSet → Array ===");
        var arr2 = roles.ToArray();
        Console.WriteLine($"ToArray()          -> Length={arr2.Length}");

        Console.WriteLine("\n=== Deduplicate list via set ===");
        var withDups = new List<string> { "a", "b", "a", "c", "b" };
        var deduped = withDups.Distinct().ToList();
        Console.WriteLine($"Distinct().ToList()-> [{string.Join(", ", deduped)}]");
    }
}
