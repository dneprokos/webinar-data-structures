namespace DataStructuresQA.Queues;

/// <summary>Enqueue, Dequeue, Peek, and FIFO demonstration.</summary>
internal static class CommonMethods
{
    public static void Run()
    {
        Console.WriteLine("=== Enqueue, Dequeue, Peek ===");
        var q = new Queue<string>();
        q.Enqueue("a"); q.Enqueue("b"); q.Enqueue("c");
        Console.WriteLine($"After Enqueue a,b,c -> Count={q.Count}, front={q.Peek()}");
        var dequeued = q.Dequeue();
        Console.WriteLine($"Dequeue()           = {dequeued}  Count={q.Count}");

        Console.WriteLine("\n=== TryDequeue (safe) ===");
        if (q.TryDequeue(out var v))
            Console.WriteLine($"TryDequeue()        = {v}");

        Console.WriteLine("\n=== Clear ===");
        q.Clear();
        Console.WriteLine($"Clear()             -> Count={q.Count}");

        Console.WriteLine("\n=== FIFO demonstration ===");
        var fifo = new Queue<string>();
        foreach (var s in new[] { "first", "second", "third" })
            fifo.Enqueue(s);
        Console.Write("Dequeue order (FIFO): ");
        while (fifo.Count > 0)
            Console.Write(fifo.Dequeue() + " ");
        Console.WriteLine();
    }
}
