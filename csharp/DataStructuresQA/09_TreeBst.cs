namespace DataStructuresQA.Examples;

/// <summary>Minimal binary search tree: insert + contains (terminology ties to old ppt).</summary>
internal static class TreeBstExample
{
    public static void Run()
    {
        var tree = new BinarySearchTree();
        foreach (var v in new[] { 10, 5, 15, 3, 7 })
            tree.Insert(v);

        Console.WriteLine(tree.Contains(7));
        Console.WriteLine(tree.Contains(99));
    }

    private sealed class Node(int value)
    {
        public int Value { get; } = value;
        public Node? Left { get; set; }
        public Node? Right { get; set; }
    }

    private sealed class BinarySearchTree
    {
        private Node? _root;

        public void Insert(int value)
        {
            _root = Insert(_root, value);
        }

        private static Node Insert(Node? node, int value)
        {
            if (node is null)
                return new Node(value);

            if (value <= node.Value)
                node.Left = Insert(node.Left, value);
            else
                node.Right = Insert(node.Right, value);

            return node;
        }

        public bool Contains(int value) => Contains(_root, value);

        private static bool Contains(Node? node, int value)
        {
            while (node is not null)
            {
                if (value == node.Value)
                    return true;
                node = value < node.Value ? node.Left : node.Right;
            }

            return false;
        }
    }
}
