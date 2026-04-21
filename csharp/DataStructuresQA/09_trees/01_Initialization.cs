namespace DataStructuresQA.Trees;

/// <summary>Building a Binary Search Tree by inserting values.</summary>
internal static class Initialization
{
    public static void Run()
    {
        Console.WriteLine("=== Create BST and insert values ===");

        var tree = new BinarySearchTree();
        var values = new[] { 10, 5, 15, 3, 7, 12, 20 };

        foreach (var v in values)
        {
            tree.Insert(v);
            Console.WriteLine($"Insert({v,3}) -> root={tree.Root?.Value}");
        }

        Console.WriteLine($"\nTree has {tree.Count} nodes");
        Console.WriteLine("Structure after inserting [10,5,15,3,7,12,20]:");
        Console.WriteLine("          10");
        Console.WriteLine("         /  \\");
        Console.WriteLine("        5    15");
        Console.WriteLine("       / \\  /  \\");
        Console.WriteLine("      3   7 12  20");
    }

    // Expose the tree types for other files in this folder.
    public sealed class Node(int value)
    {
        public int Value { get; } = value;
        public Node? Left { get; set; }
        public Node? Right { get; set; }
    }

    public sealed class BinarySearchTree
    {
        public Node? Root { get; private set; }
        public int Count { get; private set; }

        public void Insert(int value)
        {
            Root = Insert(Root, value);
            Count++;
        }

        private static Node Insert(Node? node, int value)
        {
            if (node is null) return new Node(value);
            if (value <= node.Value) node.Left = Insert(node.Left, value);
            else node.Right = Insert(node.Right, value);
            return node;
        }

        public bool Contains(int value) => Contains(Root, value);

        private static bool Contains(Node? node, int value)
        {
            while (node is not null)
            {
                if (value == node.Value) return true;
                node = value < node.Value ? node.Left : node.Right;
            }
            return false;
        }

        public List<int> InOrder()
        {
            var result = new List<int>();
            InOrder(Root, result);
            return result;
        }

        private static void InOrder(Node? node, List<int> result)
        {
            if (node is null) return;
            InOrder(node.Left, result);
            result.Add(node.Value);
            InOrder(node.Right, result);
        }
    }
}
