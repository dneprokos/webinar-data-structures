namespace DataStructuresQA.Trees;

/// <summary>Insert, search, traversal orders, height, and count.</summary>
internal static class CommonMethods
{
    public static void Run()
    {
        var tree = BuildTree(new[] { 10, 5, 15, 3, 7, 12, 20 });

        Console.WriteLine("=== Insert and search ===");
        tree.Insert(6);
        Console.WriteLine($"After Insert(6): Contains(6)={tree.Contains(6)}");

        Console.WriteLine("\n=== Traversals ===");
        Console.WriteLine($"In-order  (sorted): [{string.Join(", ", tree.InOrder())}]");
        Console.WriteLine($"Pre-order (root first): [{string.Join(", ", tree.PreOrder())}]");
        Console.WriteLine($"Post-order (leaves first): [{string.Join(", ", tree.PostOrder())}]");

        Console.WriteLine("\n=== Count ===");
        Console.WriteLine($"Node count: {tree.Count}");
    }

    private static FullBst BuildTree(int[] values)
    {
        var tree = new FullBst();
        foreach (var v in values) tree.Insert(v);
        return tree;
    }

    public sealed class FullBst
    {
        private Node? _root;
        public int Count { get; private set; }

        private sealed class Node(int v)
        {
            public int Value { get; } = v;
            public Node? Left { get; set; }
            public Node? Right { get; set; }
        }

        public void Insert(int v) { _root = InsertNode(_root, v); Count++; }
        private static Node InsertNode(Node? node, int v)
        {
            if (node is null) return new Node(v);
            if (v < node.Value) node.Left = InsertNode(node.Left, v);
            else if (v > node.Value) node.Right = InsertNode(node.Right, v);
            return node;
        }

        public bool Contains(int v) { var n = _root; while (n != null) { if (v == n.Value) return true; n = v < n.Value ? n.Left : n.Right; } return false; }

        public List<int> InOrder() { var r = new List<int>(); void Visit(Node? n) { if (n is null) return; Visit(n.Left); r.Add(n.Value); Visit(n.Right); } Visit(_root); return r; }
        public List<int> PreOrder() { var r = new List<int>(); void Visit(Node? n) { if (n is null) return; r.Add(n.Value); Visit(n.Left); Visit(n.Right); } Visit(_root); return r; }
        public List<int> PostOrder() { var r = new List<int>(); void Visit(Node? n) { if (n is null) return; Visit(n.Left); Visit(n.Right); r.Add(n.Value); } Visit(_root); return r; }
    }
}
