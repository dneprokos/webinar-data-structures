namespace DataStructuresQA.Examples;

/// <summary>HashSet: unique items when merging several sources.</summary>
internal static class SetsExample
{
    public static void Run()
    {
        var fromApi = new[] { 1, 2, 3, 3 };
        var fromDb = new[] { 3, 4, 5 };
        var merged = new HashSet<int>(fromApi);
        merged.UnionWith(fromDb);
        Console.WriteLine(string.Join(", ", merged.Order()));

        var a = new HashSet<string> { "fail", "pass", "skip" };
        var b = new HashSet<string> { "pass", "warn" };
        Console.WriteLine("intersection: " + string.Join(", ", a.Intersect(b)));
    }
}
