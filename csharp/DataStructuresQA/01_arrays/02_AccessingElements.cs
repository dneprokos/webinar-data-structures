namespace DataStructuresQA.Arrays;

/// <summary>Reading elements by index, iterating, and searching arrays/lists.</summary>
internal static class AccessingElements
{
    public static void Run()
    {
        IndexAccess();
        Iteration();
        Searching();
    }

    private static void IndexAccess()
    {
        Console.WriteLine("=== Index access (zero-based) ===");

        var letters = new[] { 'a', 'b', 'c', 'd' };

        Console.WriteLine($"letters[0]           = '{letters[0]}'  (first)");
        Console.WriteLine($"letters[2]           = '{letters[2]}'  (third)");
        Console.WriteLine($"letters[^1]          = '{letters[^1]}' (last — index from end)");
        Console.WriteLine($"letters[^2]          = '{letters[^2]}' (second-to-last)");

        // Range slice (returns a new array).
        var middle = letters[1..3]; // indices 1 and 2
        Console.WriteLine($"letters[1..3]        = [{string.Join(", ", middle.Select(c => $"'{c}'"))}]");

        // Modify by index.
        var nums = new[] { 10, 20, 30 };
        nums[1] = 99;
        Console.WriteLine($"After nums[1]=99     = [{string.Join(", ", nums)}]");
    }

    private static void Iteration()
    {
        Console.WriteLine("\n=== Iterating ===");

        var scores = new[] { 55, 92, 81 };

        // foreach — most common, read-only.
        Console.Write("foreach:             ");
        foreach (var s in scores) Console.Write($"{s} ");
        Console.WriteLine();

        // for with index — when you need the index.
        Console.Write("for with index:      ");
        for (var i = 0; i < scores.Length; i++)
            Console.Write($"[{i}]={scores[i]} ");
        Console.WriteLine();

        // LINQ ForEach on List.
        var list = new List<string> { "a", "b", "c" };
        Console.Write("List.ForEach:        ");
        list.ForEach(x => Console.Write($"{x} "));
        Console.WriteLine();
    }

    private static void Searching()
    {
        Console.WriteLine("\n=== Searching ===");

        var fruits = new[] { "apple", "banana", "cherry", "banana" };

        Console.WriteLine($"Contains(\"banana\")   = {fruits.Contains("banana")}");
        Console.WriteLine($"IndexOf(\"banana\")    = {Array.IndexOf(fruits, "banana")}  (first occurrence)");

        // LINQ first/last match.
        var first = fruits.FirstOrDefault(f => f.StartsWith('c'));
        Console.WriteLine($"First starts 'c'     = {first}");

        // Check all / any condition.
        Console.WriteLine($"Any length > 5       = {fruits.Any(f => f.Length > 5)}");
        Console.WriteLine($"All length > 3       = {fruits.All(f => f.Length > 3)}");
    }
}
