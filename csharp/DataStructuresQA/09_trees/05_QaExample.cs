namespace DataStructuresQA.Trees;

/// <summary>
/// Practical QA automation examples using trees.
/// Scenarios: menu hierarchy validation, permission tree, sorted lookup.
/// </summary>
internal static class QaExample
{
    public static void Run()
    {
        MenuHierarchyValidation();
        PermissionTree();
        SortedLookupWithBst();
    }

    private static void MenuHierarchyValidation()
    {
        Console.WriteLine("=== Validate navigation menu hierarchy ===");

        var menu = new MenuNode("Home");
        var products = menu.AddChild("Products");
        products.AddChild("Electronics");
        products.AddChild("Clothing");
        var support = menu.AddChild("Support");
        support.AddChild("FAQ");
        support.AddChild("Contact");

        Console.WriteLine($"Root: '{menu.Label}'");
        Console.WriteLine($"Children: [{string.Join(", ", menu.Children.Select(c => c.Label))}]");

        var allLabels = menu.AllDescendants().Select(n => n.Label).ToList();
        Console.WriteLine($"All menu items: [{string.Join(", ", allLabels)}]");

        Console.WriteLine($"Contains 'FAQ': {allLabels.Contains("FAQ")}");
        Console.WriteLine($"Contains 'Admin': {allLabels.Contains("Admin")}");
    }

    private static void PermissionTree()
    {
        Console.WriteLine("\n=== Permission hierarchy traversal ===");

        var bst = new Initialization.BinarySearchTree();
        var permissions = new[] { 50, 30, 70, 20, 40, 60, 80 };
        foreach (var p in permissions) bst.Insert(p);

        var sorted = bst.InOrder();
        Console.WriteLine($"Permission levels (sorted): [{string.Join(", ", sorted)}]");
        Console.WriteLine($"User level 60 has access: {bst.Contains(60)}");
        Console.WriteLine($"User level 99 has access: {bst.Contains(99)}");
    }

    private static void SortedLookupWithBst()
    {
        Console.WriteLine("\n=== Response time percentiles using BST sort ===");

        var responseTimes = new[] { 245, 120, 380, 95, 210, 450, 175 };
        var bst = new Initialization.BinarySearchTree();
        foreach (var t in responseTimes) bst.Insert(t);

        var sorted = bst.InOrder();
        var p50 = sorted[sorted.Count / 2];
        var p95 = sorted[(int)(sorted.Count * 0.95)];
        var max = sorted[^1];

        Console.WriteLine($"Response times: [{string.Join(", ", responseTimes)}]");
        Console.WriteLine($"Sorted:         [{string.Join(", ", sorted)}]");
        Console.WriteLine($"p50={p50}ms  p95={p95}ms  max={max}ms");
    }

    // ── Simple tree node for menu ─────────────────────────────────────────────

    private sealed class MenuNode(string label)
    {
        public string Label { get; } = label;
        public List<MenuNode> Children { get; } = new();

        public MenuNode AddChild(string childLabel)
        {
            var child = new MenuNode(childLabel);
            Children.Add(child);
            return child;
        }

        public IEnumerable<MenuNode> AllDescendants()
        {
            foreach (var child in Children)
            {
                yield return child;
                foreach (var desc in child.AllDescendants())
                    yield return desc;
            }
        }
    }
}
