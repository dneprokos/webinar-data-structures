namespace DataStructuresQA.Queues;

/// <summary>Creating Queue instances in C#.</summary>
internal static class Initialization
{
    public static void Run()
    {
        Console.WriteLine("=== Empty queue ===");
        var empty = new Queue<int>();
        Console.WriteLine($"new Queue<int>()       -> Count={empty.Count}");

        Console.WriteLine("\n=== Queue from collection ===");
        var fromList = new Queue<string>(new[] { "a", "b", "c" });
        Console.WriteLine($"Queue(['a','b','c'])    -> Count={fromList.Count}  front={fromList.Peek()}");

        Console.WriteLine("\n=== Build by enqueueing ===");
        var q = new Queue<string>();
        q.Enqueue("sync-users");
        q.Enqueue("purge-cache");
        q.Enqueue("notify-slack");
        Console.WriteLine($"After 3 Enqueues       -> Count={q.Count}  front={q.Peek()}");
    }
}
