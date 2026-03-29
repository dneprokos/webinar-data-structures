namespace DataStructuresQA.Examples;

/// <summary>Queue FIFO: ordered work items.</summary>
internal static class QueueExample
{
    public static void Run()
    {
        var jobs = new Queue<string>();
        jobs.Enqueue("sync-users");
        jobs.Enqueue("purge-cache");
        jobs.Enqueue("notify-slack");

        while (jobs.Count > 0)
            Console.WriteLine("processing: " + jobs.Dequeue());
    }
}
