namespace DataStructuresQA.Arrays;

/// <summary>All the ways to create arrays and lists in C#.</summary>
internal static class Initialization
{
    public static void Run()
    {
        FixedArrays();
        ListDynamicArray();
        ArrayFromCollection();
    }

    private static void FixedArrays()
    {
        Console.WriteLine("=== Fixed-size T[] ===");

        // Declare with size — elements default to zero / null.
        var buffer = new int[4];
        Console.WriteLine($"new int[4]          -> [{string.Join(", ", buffer)}]  (all zeros)");

        // Inline initializer — compiler infers length.
        var scores = new[] { 10, 20, 30 };
        Console.WriteLine($"new[] {{10,20,30}}    -> [{string.Join(", ", scores)}]");

        // Explicit type + initializer.
        string[] tags = { "smoke", "api", "regression" };
        Console.WriteLine($"string[] tags       -> [{string.Join(", ", tags)}]");

        // Array.Fill — set all elements to the same value.
        var ones = new int[5];
        Array.Fill(ones, 1);
        Console.WriteLine($"Array.Fill(arr, 1)  -> [{string.Join(", ", ones)}]");
    }

    private static void ListDynamicArray()
    {
        Console.WriteLine("\n=== List<T> — resizable array ===");

        // Empty list.
        var empty = new List<int>();
        Console.WriteLine($"new List<int>()     -> Count={empty.Count}");

        // List with initial values.
        var names = new List<string> { "Alice", "Bob" };
        Console.WriteLine($"List with values    -> [{string.Join(", ", names)}]");

        // Add grows the list.
        names.Add("Charlie");
        Console.WriteLine($"After Add(Charlie)  -> [{string.Join(", ", names)}]");

        // Capacity vs Count.
        var cap = new List<int>(capacity: 100); // pre-allocate without adding items
        Console.WriteLine($"new List<int>(100)  -> Count={cap.Count}, Capacity={cap.Capacity}");
    }

    private static void ArrayFromCollection()
    {
        Console.WriteLine("\n=== Create array / list from existing data ===");

        int[] source = { 1, 2, 3, 4, 5 };

        // Array → List.
        var list = new List<int>(source);
        Console.WriteLine($"List from array     -> [{string.Join(", ", list)}]");

        // LINQ → array.
        var evens = source.Where(x => x % 2 == 0).ToArray();
        Console.WriteLine($"Where(even).ToArray -> [{string.Join(", ", evens)}]");

        // Enumerable.Range — generate a numeric sequence.
        var range = Enumerable.Range(1, 5).ToArray();
        Console.WriteLine($"Range(1,5)          -> [{string.Join(", ", range)}]");

        // Enumerable.Repeat — fill with a constant.
        var repeated = Enumerable.Repeat("x", 3).ToArray();
        Console.WriteLine($"Repeat(\"x\",3)        -> [{string.Join(", ", repeated)}]");
    }
}
