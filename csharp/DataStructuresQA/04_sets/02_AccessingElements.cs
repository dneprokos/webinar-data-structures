namespace DataStructuresQA.Sets;

/// <summary>Membership testing and iterating over HashSet.</summary>
internal static class AccessingElements
{
    public static void Run()
    {
        Console.WriteLine("=== Membership test (O(1)) ===");
        var allowed = new HashSet<string> { "admin", "editor", "viewer" };
        Console.WriteLine($"Contains('admin')   = {allowed.Contains("admin")}");
        Console.WriteLine($"Contains('hacker')  = {allowed.Contains("hacker")}");

        Console.WriteLine("\n=== Iterating (no guaranteed order) ===");
        foreach (var role in allowed.OrderBy(r => r))
            Console.WriteLine($"  {role}");

        Console.WriteLine("\n=== Set does NOT support index access ===");
        // allowed[0] would not compile — HashSet has no indexer.
        Console.WriteLine("(Use .ToList() if you need index access)");
        var asList = allowed.OrderBy(r => r).ToList();
        Console.WriteLine($"ToList()[0] = {asList[0]}");
    }
}
