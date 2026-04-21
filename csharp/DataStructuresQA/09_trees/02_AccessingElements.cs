namespace DataStructuresQA.Trees;

/// <summary>Searching and traversing the Binary Search Tree.</summary>
internal static class AccessingElements
{
    public static void Run()
    {
        var tree = BuildTree(new[] { 10, 5, 15, 3, 7, 12, 20 });

        Console.WriteLine("=== Contains (O(log n) average) ===");
        Console.WriteLine($"Contains(7)   = {tree.Contains(7)}");
        Console.WriteLine($"Contains(99)  = {tree.Contains(99)}");
        Console.WriteLine($"Contains(15)  = {tree.Contains(15)}");

        Console.WriteLine("\n=== In-order traversal (sorted output) ===");
        var inOrder = tree.InOrder();
        Console.WriteLine($"In-order:  [{string.Join(", ", inOrder)}]");

        Console.WriteLine("\n=== Min / Max ===");
        Console.WriteLine($"Min (leftmost) = {inOrder[0]}");
        Console.WriteLine($"Max (rightmost)= {inOrder[^1]}");
    }

    private static Initialization.BinarySearchTree BuildTree(int[] values)
    {
        var tree = new Initialization.BinarySearchTree();
        foreach (var v in values) tree.Insert(v);
        return tree;
    }
}
