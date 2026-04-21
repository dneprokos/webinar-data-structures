namespace DataStructuresQA.LinkedLists;

/// <summary>Creating LinkedList instances in C#.</summary>
internal static class Initialization
{
    public static void Run()
    {
        Console.WriteLine("=== Empty linked list ===");
        var empty = new LinkedList<int>();
        Console.WriteLine($"new LinkedList<int>()      -> Count={empty.Count}");

        Console.WriteLine("\n=== LinkedList from collection ===");
        var fromList = new LinkedList<string>(new[] { "login", "dashboard", "profile" });
        Console.WriteLine($"LinkedList(['login',...])  -> Count={fromList.Count}  First={fromList.First?.Value}  Last={fromList.Last?.Value}");

        Console.WriteLine("\n=== Build by adding nodes ===");
        var ll = new LinkedList<string>();
        ll.AddLast("step-1");
        ll.AddLast("step-2");
        ll.AddLast("step-3");
        Console.WriteLine($"After 3 AddLast calls      -> Count={ll.Count}  First={ll.First?.Value}  Last={ll.Last?.Value}");

        Console.WriteLine("\n=== Add to front ===");
        ll.AddFirst("step-0");
        Console.WriteLine($"After AddFirst('step-0')   -> First={ll.First?.Value}  Count={ll.Count}");
    }
}
