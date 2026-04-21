namespace DataStructuresQA.Lists;

/// <summary>Reading, iterating, and searching List&lt;T&gt;.</summary>
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
        Console.WriteLine("=== Index access ===");

        var items = new List<string> { "apple", "banana", "cherry" };

        Console.WriteLine($"items[0]         = {items[0]}");
        Console.WriteLine($"items[^1]        = {items[^1]}  (last)");
        Console.WriteLine($"items.Count      = {items.Count}");

        items[1] = "blueberry";
        Console.WriteLine($"After [1]='blueberry': [{string.Join(", ", items)}]");
    }

    private static void Iteration()
    {
        Console.WriteLine("\n=== Iterating ===");

        var scores = new List<int> { 55, 92, 81 };

        Console.Write("foreach:         ");
        foreach (var s in scores) Console.Write($"{s} ");
        Console.WriteLine();

        scores.ForEach(s => Console.Write($"{s} "));
        Console.WriteLine(" <- List.ForEach");
    }

    private static void Searching()
    {
        Console.WriteLine("\n=== Searching ===");

        var fruits = new List<string> { "apple", "banana", "cherry" };

        Console.WriteLine($"Contains('banana')   = {fruits.Contains("banana")}");
        Console.WriteLine($"IndexOf('banana')    = {fruits.IndexOf("banana")}");
        Console.WriteLine($"Exists(len>5)        = {fruits.Exists(f => f.Length > 5)}");
        Console.WriteLine($"Find(starts 'c')     = {fruits.Find(f => f.StartsWith('c'))}");
        Console.WriteLine($"FindAll(len>5)       = [{string.Join(", ", fruits.FindAll(f => f.Length > 5))}]");
    }
}
