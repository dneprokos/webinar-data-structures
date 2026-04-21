namespace DataStructuresQA.LinkedLists;

/// <summary>Traversal, index access (O(n)), Find, and Contains on LinkedList.</summary>
internal static class AccessingElements
{
    public static void Run()
    {
        var ll = new LinkedList<string>(new[] { "/login", "/dashboard", "/profile", "/settings" });

        Console.WriteLine("=== Traverse head → tail ===");
        var node = ll.First;
        int i = 0;
        while (node is not null)
        {
            Console.WriteLine($"  [{i++}] {node.Value}");
            node = node.Next;
        }

        Console.WriteLine("\n=== Access First and Last ===");
        Console.WriteLine($"First = {ll.First?.Value}");
        Console.WriteLine($"Last  = {ll.Last?.Value}");

        Console.WriteLine("\n=== Get by index (O(n)) ===");
        Console.WriteLine($"Index 2 = {GetByIndex(ll, 2)}");

        Console.WriteLine("\n=== Find node by value ===");
        var found = ll.Find("/profile");
        Console.WriteLine(found is not null
            ? $"Find('/profile') -> Value={found.Value}  Prev={found.Previous?.Value}  Next={found.Next?.Value}"
            : "Not found");

        Console.WriteLine("\n=== Contains ===");
        Console.WriteLine($"Contains('/dashboard') = {ll.Contains("/dashboard")}");
        Console.WriteLine($"Contains('/missing')   = {ll.Contains("/missing")}");
    }

    private static T? GetByIndex<T>(LinkedList<T> list, int index)
    {
        var current = list.First;
        for (int i = 0; i < index && current is not null; i++)
            current = current.Next;
        return current is not null ? current.Value : default;
    }
}
