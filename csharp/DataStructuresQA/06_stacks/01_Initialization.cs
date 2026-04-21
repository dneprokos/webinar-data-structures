namespace DataStructuresQA.Stacks;

/// <summary>Creating Stack instances in C#.</summary>
internal static class Initialization
{
    public static void Run()
    {
        Console.WriteLine("=== Empty stack ===");
        var empty = new Stack<int>();
        Console.WriteLine($"new Stack<int>()       -> Count={empty.Count}");

        Console.WriteLine("\n=== Stack from collection ===");
        var fromList = new Stack<string>(new[] { "a", "b", "c" });
        Console.WriteLine($"Stack from array       -> Count={fromList.Count}  top={fromList.Peek()}");

        Console.WriteLine("\n=== Build by pushing ===");
        var s = new Stack<int>();
        foreach (var v in new[] { 101, 102, 103 })
            s.Push(v);
        Console.WriteLine($"After pushing 101,102,103 -> top={s.Peek()}, Count={s.Count}");
    }
}
