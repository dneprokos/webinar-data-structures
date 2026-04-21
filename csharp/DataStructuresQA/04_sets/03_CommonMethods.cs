namespace DataStructuresQA.Sets;

/// <summary>Set operations: union, intersection, difference, subset/superset.</summary>
internal static class CommonMethods
{
    public static void Run()
    {
        AddRemove();
        SetOperations();
        SubsetSuperset();
    }

    private static void AddRemove()
    {
        Console.WriteLine("=== Add & Remove ===");
        var set = new HashSet<int> { 1, 2, 3 };
        var added = set.Add(4);
        Console.WriteLine($"Add(4)             -> {added}  [{string.Join(", ", set.Order())}]");
        var duplicate = set.Add(2);
        Console.WriteLine($"Add(2) duplicate   -> {duplicate}  (already exists, no change)");
        set.Remove(1);
        Console.WriteLine($"Remove(1)          -> [{string.Join(", ", set.Order())}]");
    }

    private static void SetOperations()
    {
        Console.WriteLine("\n=== Set operations ===");
        var a = new HashSet<int> { 1, 2, 3, 4 };
        var b = new HashSet<int> { 3, 4, 5, 6 };

        // Mutating variants.
        var union = new HashSet<int>(a);
        union.UnionWith(b);
        Console.WriteLine($"Union              -> [{string.Join(", ", union.Order())}]");

        var inter = new HashSet<int>(a);
        inter.IntersectWith(b);
        Console.WriteLine($"Intersection       -> [{string.Join(", ", inter.Order())}]");

        var diff = new HashSet<int>(a);
        diff.ExceptWith(b);
        Console.WriteLine($"Difference (a-b)   -> [{string.Join(", ", diff.Order())}]");

        var symDiff = new HashSet<int>(a);
        symDiff.SymmetricExceptWith(b);
        Console.WriteLine($"SymmetricDiff      -> [{string.Join(", ", symDiff.Order())}]");

        // Non-mutating LINQ versions.
        Console.WriteLine($"a.Union(b)         -> [{string.Join(", ", a.Union(b).Order())}]");
        Console.WriteLine($"a.Intersect(b)     -> [{string.Join(", ", a.Intersect(b).Order())}]");
        Console.WriteLine($"a.Except(b)        -> [{string.Join(", ", a.Except(b).Order())}]");
    }

    private static void SubsetSuperset()
    {
        Console.WriteLine("\n=== Subset / Superset ===");
        var full = new HashSet<string> { "fail", "pass", "skip", "warn" };
        var subset = new HashSet<string> { "fail", "pass" };

        Console.WriteLine($"subset.IsSubsetOf(full)   = {subset.IsSubsetOf(full)}");
        Console.WriteLine($"full.IsSupersetOf(subset) = {full.IsSupersetOf(subset)}");
        Console.WriteLine($"full.Overlaps(subset)     = {full.Overlaps(subset)}");
    }
}
