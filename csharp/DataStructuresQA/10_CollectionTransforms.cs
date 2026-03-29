namespace DataStructuresQA.Examples;

/// <summary>LINQ-style transforms (Sum, Where, Select — old presentation topic).</summary>
internal static class CollectionTransformsExample
{
    public static void Run()
    {
        var scores = new[] { 55, 92, 81, 40, 88 };
        Console.WriteLine("sum (>80): " + scores.Where(s => s > 80).Sum());
        Console.WriteLine("names: " + string.Join(", ", Employees.Select(e => e.Name)));

        var page = scores.OrderByDescending(x => x).Skip(1).Take(2);
        Console.WriteLine("page: " + string.Join(", ", page));
    }

    private static readonly Employee[] Employees =
    {
        new("Ann", "SDET", 90000),
        new("Bob", "QA", 70000),
    };

    private sealed record Employee(string Name, string Title, int Salary);
}
