namespace DataStructuresQA.Queues;

/// <summary>Converting Queue to/from other types.</summary>
internal static class Conversions
{
    public static void Run()
    {
        Console.WriteLine("=== Queue → Array (front first) ===");
        var q = new Queue<int>(new[] { 1, 2, 3 });
        var arr = q.ToArray();
        Console.WriteLine($"ToArray()          -> [{string.Join(", ", arr)}]  (front is [0])");

        Console.WriteLine("\n=== Queue → List ===");
        var list = q.ToList();
        Console.WriteLine($"ToList()           -> [{string.Join(", ", list)}]");

        Console.WriteLine("\n=== List → Queue ===");
        var fromList = new Queue<string>(new[] { "sync", "purge", "notify" });
        Console.WriteLine($"Queue from list    -> front={fromList.Peek()}");

        Console.WriteLine("\n=== Process all and collect results ===");
        var jobs = new Queue<string>(new[] { "job1", "job2", "job3" });
        var results = new List<string>();
        while (jobs.Count > 0)
            results.Add($"done:{jobs.Dequeue()}");
        Console.WriteLine($"Results:           [{string.Join(", ", results)}]");
    }
}
