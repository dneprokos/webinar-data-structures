namespace DataStructuresQA.Stacks;

/// <summary>Converting Stack to/from other types.</summary>
internal static class Conversions
{
    public static void Run()
    {
        Console.WriteLine("=== Stack → Array (snapshot, top first) ===");
        var stack = new Stack<int>(new[] { 1, 2, 3 });
        var arr = stack.ToArray(); // top-to-bottom
        Console.WriteLine($"ToArray()          -> [{string.Join(", ", arr)}]  (top is [0])");

        Console.WriteLine("\n=== Stack → List ===");
        var list = stack.ToList();
        Console.WriteLine($"ToList()           -> [{string.Join(", ", list)}]");

        Console.WriteLine("\n=== List → Stack ===");
        var fromList = new Stack<string>(new[] { "a", "b", "c" });
        Console.WriteLine($"new Stack(list)    -> top={fromList.Peek()}");

        Console.WriteLine("\n=== Reverse a list using a stack ===");
        var original = new[] { 1, 2, 3, 4, 5 };
        var tempStack = new Stack<int>(original);
        var reversed = tempStack.ToArray(); // ToArray preserves LIFO order = reversed
        Console.WriteLine($"Original:          [{string.Join(", ", original)}]");
        Console.WriteLine($"Reversed via stack:[{string.Join(", ", reversed)}]");
    }
}
