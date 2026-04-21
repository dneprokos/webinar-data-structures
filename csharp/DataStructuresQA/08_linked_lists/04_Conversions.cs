namespace DataStructuresQA.LinkedLists;

/// <summary>Converting LinkedList to/from arrays, lists, and other collections.</summary>
internal static class Conversions
{
    public static void Run()
    {
        var ll = new LinkedList<int>(new[] { 1, 2, 3, 4, 5 });

        Console.WriteLine("=== LinkedList → Array ===");
        var arr = ll.ToArray();
        Console.WriteLine($"ToArray()          -> [{string.Join(", ", arr)}]");

        Console.WriteLine("\n=== LinkedList → List<T> ===");
        var list = ll.ToList();
        Console.WriteLine($"ToList()           -> [{string.Join(", ", list)}]");

        Console.WriteLine("\n=== Array → LinkedList ===");
        var fromArr = new LinkedList<string>(new[] { "x", "y", "z" });
        Console.WriteLine($"new LinkedList(arr) -> First={fromArr.First?.Value}  Count={fromArr.Count}");

        Console.WriteLine("\n=== LinkedList → Queue (preserve FIFO order) ===");
        var queue = new Queue<int>(ll);
        Console.WriteLine($"new Queue(ll)       -> Count={queue.Count}  Front={queue.Peek()}");

        Console.WriteLine("\n=== Stack of reversed nodes ===");
        var stack = new Stack<int>(ll);
        Console.WriteLine($"new Stack(ll)       -> Top={stack.Peek()}  (reversed: last-in on top)");

        Console.WriteLine("\n=== Filter and rebuild as new LinkedList ===");
        var evens = new LinkedList<int>(ll.Where(x => x % 2 == 0));
        Console.WriteLine($"Even nodes only     -> [{string.Join(", ", evens)}]");
    }
}
