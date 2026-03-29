namespace DataStructuresQA.Examples;

/// <summary>Stack LIFO: parallel tests sharing a pool of client ids (from Medium article).</summary>
internal static class StackExample
{
    public static void Run()
    {
        var pool = new Stack<int>();
        foreach (var id in new[] { 101, 102, 103 })
            pool.Push(id);

        var taken = pool.Pop();
        Console.WriteLine($"Test uses client {taken}; pool left: {pool.Count}");
        pool.Push(taken);
        Console.WriteLine($"Returned client; pool size: {pool.Count}");
    }
}
