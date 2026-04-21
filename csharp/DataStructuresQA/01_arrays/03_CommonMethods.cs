namespace DataStructuresQA.Arrays;

/// <summary>Add, remove, sort, search, and other useful array/list methods.</summary>
internal static class CommonMethods
{
    public static void Run()
    {
        AddingAndRemoving();
        Sorting();
        Filtering();
        Projection();
    }

    private static void AddingAndRemoving()
    {
        Console.WriteLine("=== Adding & Removing (List<T>) ===");

        var list = new List<string> { "a", "b", "c", "b" };

        list.Add("d");
        Console.WriteLine($"Add(\"d\")             -> [{string.Join(", ", list)}]");

        list.Insert(1, "X");
        Console.WriteLine($"Insert(1,\"X\")        -> [{string.Join(", ", list)}]");

        list.Remove("b");
        Console.WriteLine($"Remove(\"b\")          -> [{string.Join(", ", list)}]  (first match only)");

        list.RemoveAt(0);
        Console.WriteLine($"RemoveAt(0)          -> [{string.Join(", ", list)}]");

        list.RemoveAll(x => x == "b");
        Console.WriteLine($"RemoveAll(==\"b\")     -> [{string.Join(", ", list)}]");

        list.Clear();
        Console.WriteLine($"Clear()              -> Count={list.Count}");
    }

    private static void Sorting()
    {
        Console.WriteLine("\n=== Sorting ===");

        // Array.Sort — in-place, mutates the original.
        var values = new[] { 3, 1, 4, 1, 5 };
        Array.Sort(values);
        Console.WriteLine($"Array.Sort (in-place)    -> [{string.Join(", ", values)}]");

        // List.Sort — also in-place.
        var names = new List<string> { "zebra", "apple", "Mango" };
        names.Sort(StringComparer.OrdinalIgnoreCase);
        Console.WriteLine($"List.Sort (OIC)          -> [{string.Join(", ", names)}]");

        // OrderBy — creates a new sorted sequence (non-mutating).
        var original = new[] { 9, 2, 7 };
        var asc = original.OrderBy(x => x).ToArray();
        var desc = original.OrderByDescending(x => x).ToArray();
        Console.WriteLine($"OrderBy asc              -> [{string.Join(", ", asc)}]");
        Console.WriteLine($"OrderByDescending        -> [{string.Join(", ", desc)}]");
    }

    private static void Filtering()
    {
        Console.WriteLine("\n=== Filtering ===");

        var scores = new[] { 55, 92, 81, 40, 88 };

        var passed = scores.Where(s => s >= 80).ToArray();
        Console.WriteLine($"Where(>= 80)         -> [{string.Join(", ", passed)}]");

        var mids = scores.Where(s => s is > 50 and < 90).ToArray();
        Console.WriteLine($"Where(50 < s < 90)   -> [{string.Join(", ", mids)}]");

        var words = new[] { "a", "", "bb", "ccc" };
        var nonEmpty = words.Where(w => w.Length > 0).ToArray();
        Console.WriteLine($"Where non-empty      -> [{string.Join(", ", nonEmpty)}]");
    }

    private static void Projection()
    {
        Console.WriteLine("\n=== Projection / Map ===");

        var scores = new[] { 55, 92, 81, 40, 88 };

        var doubled = scores.Select(s => s * 2).ToArray();
        Console.WriteLine($"Select(s => s*2)     -> [{string.Join(", ", doubled)}]");

        var labels = scores.Select(s => $"s={s}").ToArray();
        Console.WriteLine($"Select to strings    -> [{string.Join(", ", labels)}]");

        var employees = new[]
        {
            new { Name = "Ann", Title = "SDET" },
            new { Name = "Bob", Title = "QA" },
        };
        var empNames = employees.Select(e => e.Name).ToArray();
        Console.WriteLine($"Select names         -> [{string.Join(", ", empNames)}]");
    }
}
