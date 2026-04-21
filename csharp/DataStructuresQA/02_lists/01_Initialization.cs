namespace DataStructuresQA.Lists;

/// <summary>All the ways to create a List&lt;T&gt; in C#.</summary>
internal static class Initialization
{
    public static void Run()
    {
        EmptyAndPreFilled();
        WithInitialValues();
        FromExistingCollection();
    }

    private static void EmptyAndPreFilled()
    {
        Console.WriteLine("=== Empty list ===");

        var empty = new List<int>();
        Console.WriteLine($"new List<int>()         -> Count={empty.Count}");

        var withCapacity = new List<int>(capacity: 50);
        Console.WriteLine($"new List<int>(50)       -> Count={withCapacity.Count}, Capacity={withCapacity.Capacity}");
    }

    private static void WithInitialValues()
    {
        Console.WriteLine("\n=== List with values ===");

        var tags = new List<string> { "smoke", "api", "regression" };
        Console.WriteLine($"Collection initializer  -> [{string.Join(", ", tags)}]");

        // C# 12 collection expression syntax.
        List<int> scores = [10, 20, 30, 40];
        Console.WriteLine($"Collection expression   -> [{string.Join(", ", scores)}]");
    }

    private static void FromExistingCollection()
    {
        Console.WriteLine("\n=== From existing collection ===");

        int[] arr = { 1, 2, 3, 4, 5 };
        var fromArray = new List<int>(arr);
        Console.WriteLine($"new List<int>(array)    -> [{string.Join(", ", fromArray)}]");

        var fromLinq = Enumerable.Range(1, 5).ToList();
        Console.WriteLine($"Range(1,5).ToList()     -> [{string.Join(", ", fromLinq)}]");

        var evens = arr.Where(x => x % 2 == 0).ToList();
        Console.WriteLine($"Where(even).ToList()    -> [{string.Join(", ", evens)}]");
    }
}
