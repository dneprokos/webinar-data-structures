namespace DataStructuresQA.Sets;

/// <summary>Creating HashSet instances in C#.</summary>
internal static class Initialization
{
    public static void Run()
    {
        Console.WriteLine("=== Empty set ===");
        var empty = new HashSet<int>();
        Console.WriteLine($"new HashSet<int>()     -> Count={empty.Count}");

        Console.WriteLine("\n=== Set with initial values ===");
        var tags = new HashSet<string> { "smoke", "api", "regression" };
        Console.WriteLine($"inline values          -> [{string.Join(", ", tags)}]");

        Console.WriteLine("\n=== From array (dedup) ===");
        var withDups = new[] { 1, 2, 2, 3, 3, 3 };
        var unique = new HashSet<int>(withDups);
        Console.WriteLine($"from [1,2,2,3,3,3]     -> [{string.Join(", ", unique.Order())}]  (Count={unique.Count})");

        Console.WriteLine("\n=== Case-insensitive string set ===");
        var urls = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "https://A.com", "https://a.com" };
        Console.WriteLine($"case-insensitive       -> Count={urls.Count}  (treated as duplicate)");

        Console.WriteLine("\n=== SortedSet — ordered unique elements ===");
        var sorted = new SortedSet<int> { 5, 1, 3, 1, 4 };
        Console.WriteLine($"SortedSet              -> [{string.Join(", ", sorted)}]");
    }
}
