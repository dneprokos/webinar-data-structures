namespace DataStructuresQA.LinkedLists;

/// <summary>AddFirst, AddLast, AddBefore, AddAfter, Remove, and Clear on LinkedList.</summary>
internal static class CommonMethods
{
    public static void Run()
    {
        var ll = new LinkedList<string>(new[] { "a", "c" });
        Console.WriteLine($"Start: {string.Join(" -> ", ll)}");

        Console.WriteLine("\n=== AddFirst / AddLast ===");
        ll.AddFirst("START");
        ll.AddLast("END");
        Console.WriteLine($"After AddFirst('START'), AddLast('END'): {string.Join(" -> ", ll)}");

        Console.WriteLine("\n=== AddBefore / AddAfter ===");
        var nodeC = ll.Find("c")!;
        ll.AddBefore(nodeC, "b");
        ll.AddAfter(nodeC, "c+");
        Console.WriteLine($"After AddBefore(c,'b'), AddAfter(c,'c+'): {string.Join(" -> ", ll)}");

        Console.WriteLine("\n=== Remove by value ===");
        ll.Remove("c+");
        Console.WriteLine($"After Remove('c+'):  {string.Join(" -> ", ll)}");

        Console.WriteLine("\n=== Remove by node (O(1)) ===");
        var nodeB = ll.Find("b")!;
        ll.Remove(nodeB);
        Console.WriteLine($"After Remove(nodeB): {string.Join(" -> ", ll)}");

        Console.WriteLine("\n=== RemoveFirst / RemoveLast ===");
        ll.RemoveFirst();
        ll.RemoveLast();
        Console.WriteLine($"After RemoveFirst+RemoveLast: {string.Join(" -> ", ll)}");

        Console.WriteLine("\n=== Clear ===");
        ll.Clear();
        Console.WriteLine($"After Clear() -> Count={ll.Count}");
    }
}
