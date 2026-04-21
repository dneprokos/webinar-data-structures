namespace DataStructuresQA.Lists;

/// <summary>Add, remove, sort, and other common List&lt;T&gt; methods.</summary>
internal static class CommonMethods
{
    public static void Run()
    {
        AddRemove();
        Sorting();
        AggregatesAndChecks();
    }

    private static void AddRemove()
    {
        Console.WriteLine("=== Add & Remove ===");

        var list = new List<string> { "a", "b", "c" };

        list.Add("d");
        Console.WriteLine($"Add('d')          -> [{string.Join(", ", list)}]");

        list.AddRange(new[] { "e", "f" });
        Console.WriteLine($"AddRange(['e','f'])-> [{string.Join(", ", list)}]");

        list.Insert(1, "X");
        Console.WriteLine($"Insert(1,'X')     -> [{string.Join(", ", list)}]");

        list.Remove("X");
        Console.WriteLine($"Remove('X')       -> [{string.Join(", ", list)}]");

        list.RemoveAt(list.Count - 1);
        Console.WriteLine($"RemoveAt(last)    -> [{string.Join(", ", list)}]");

        list.RemoveAll(x => x == "b");
        Console.WriteLine($"RemoveAll('b')    -> [{string.Join(", ", list)}]");

        list.Clear();
        Console.WriteLine($"Clear()           -> Count={list.Count}");
    }

    private static void Sorting()
    {
        Console.WriteLine("\n=== Sort ===");

        var nums = new List<int> { 3, 1, 4, 1, 5 };
        nums.Sort();
        Console.WriteLine($"Sort() in-place   -> [{string.Join(", ", nums)}]");

        var names = new List<string> { "Zebra", "apple", "Mango" };
        names.Sort(StringComparer.OrdinalIgnoreCase);
        Console.WriteLine($"Sort(OIC)         -> [{string.Join(", ", names)}]");

        var ordered = nums.OrderByDescending(x => x).ToList();
        Console.WriteLine($"OrderByDesc       -> [{string.Join(", ", ordered)}]");
    }

    private static void AggregatesAndChecks()
    {
        Console.WriteLine("\n=== Aggregates & checks ===");

        var scores = new List<int> { 55, 92, 81, 40, 88 };

        Console.WriteLine($"Count             = {scores.Count}");
        Console.WriteLine($"Sum               = {scores.Sum()}");
        Console.WriteLine($"Average           = {scores.Average():F1}");
        Console.WriteLine($"Min / Max         = {scores.Min()} / {scores.Max()}");
        Console.WriteLine($"Any(>90)          = {scores.Any(s => s > 90)}");
        Console.WriteLine($"All(>0)           = {scores.All(s => s > 0)}");
    }
}
