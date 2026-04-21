namespace DataStructuresQA.Trees;

/// <summary>Converting BST to sorted list, and building BST from existing data.</summary>
internal static class Conversions
{
    public static void Run()
    {
        Console.WriteLine("=== BST → sorted list (in-order) ===");
        var tree = new Initialization.BinarySearchTree();
        foreach (var v in new[] { 5, 3, 7, 1, 4, 6, 8 }) tree.Insert(v);
        var sorted = tree.InOrder();
        Console.WriteLine($"In-order list: [{string.Join(", ", sorted)}]");

        Console.WriteLine("\n=== Unsorted array → BST → sorted array ===");
        var unsorted = new[] { 9, 2, 7, 1, 5 };
        var tree2 = new Initialization.BinarySearchTree();
        foreach (var v in unsorted) tree2.Insert(v);
        var sortedArr = tree2.InOrder().ToArray();
        Console.WriteLine($"Input:  [{string.Join(", ", unsorted)}]");
        Console.WriteLine($"Sorted: [{string.Join(", ", sortedArr)}]");

        Console.WriteLine("\n=== BST → List (BFS / level order) ===");
        Console.WriteLine("(Not shown here — see BFS / Queue for level-order traversal)");
    }
}
