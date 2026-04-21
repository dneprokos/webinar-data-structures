namespace DataStructuresQA.Stacks;

/// <summary>Reading from Stack: Peek, Pop, Contains, and iteration.</summary>
internal static class AccessingElements
{
    public static void Run()
    {
        var stack = new Stack<string>(new[] { "first", "second", "third" });

        Console.WriteLine("=== Peek (read top without removing) ===");
        Console.WriteLine($"Peek()             = {stack.Peek()}");
        Console.WriteLine($"Count after Peek   = {stack.Count}  (unchanged)");

        Console.WriteLine("\n=== TryPeek (safe) ===");
        if (stack.TryPeek(out var top))
            Console.WriteLine($"TryPeek()          = {top}");

        Console.WriteLine("\n=== Contains ===");
        Console.WriteLine($"Contains('second') = {stack.Contains("second")}");
        Console.WriteLine($"Contains('missing')= {stack.Contains("missing")}");

        Console.WriteLine("\n=== Iteration (top → bottom) ===");
        foreach (var item in stack)
            Console.WriteLine($"  {item}");

        Console.WriteLine("\n=== No index access ===");
        Console.WriteLine("(Stack has no [i] — use ToArray() for index access if needed)");
    }
}
