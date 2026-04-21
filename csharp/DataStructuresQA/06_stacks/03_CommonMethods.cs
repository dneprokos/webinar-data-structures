namespace DataStructuresQA.Stacks;

/// <summary>Push, Pop, Peek, and other Stack methods.</summary>
internal static class CommonMethods
{
    public static void Run()
    {
        Console.WriteLine("=== Push, Pop, Peek ===");
        var stack = new Stack<int>();
        stack.Push(1); stack.Push(2); stack.Push(3);
        Console.WriteLine($"After Push 1,2,3   -> Count={stack.Count}, top={stack.Peek()}");

        var popped = stack.Pop();
        Console.WriteLine($"Pop()              = {popped}  Count={stack.Count}");

        Console.WriteLine("\n=== TryPop (safe) ===");
        if (stack.TryPop(out var v))
            Console.WriteLine($"TryPop()           = {v}");

        Console.WriteLine("\n=== Clear ===");
        stack.Clear();
        Console.WriteLine($"Clear()            -> Count={stack.Count}");

        Console.WriteLine("\n=== LIFO demonstration ===");
        var lifo = new Stack<string>();
        foreach (var s in new[] { "first", "second", "third" })
            lifo.Push(s);
        Console.Write("Pop order (LIFO):  ");
        while (lifo.Count > 0)
            Console.Write(lifo.Pop() + " ");
        Console.WriteLine();
    }
}
