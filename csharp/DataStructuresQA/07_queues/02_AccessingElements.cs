namespace DataStructuresQA.Queues;

/// <summary>Reading from Queue: Peek, Dequeue, Contains, and iteration.</summary>
internal static class AccessingElements
{
    public static void Run()
    {
        var q = new Queue<string>(new[] { "first", "second", "third" });

        Console.WriteLine("=== Peek (read front without removing) ===");
        Console.WriteLine($"Peek()             = {q.Peek()}");
        Console.WriteLine($"Count after Peek   = {q.Count}  (unchanged)");

        Console.WriteLine("\n=== TryPeek (safe) ===");
        if (q.TryPeek(out var front))
            Console.WriteLine($"TryPeek()          = {front}");

        Console.WriteLine("\n=== Contains ===");
        Console.WriteLine($"Contains('second') = {q.Contains("second")}");
        Console.WriteLine($"Contains('missing')= {q.Contains("missing")}");

        Console.WriteLine("\n=== Iteration (front → back) ===");
        foreach (var item in q)
            Console.WriteLine($"  {item}");
    }
}
