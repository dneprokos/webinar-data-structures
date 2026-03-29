namespace DataStructuresQA.Examples;

/// <summary>List scenarios: element collection counts (UI/API QA patterns).</summary>
internal static class ListsQaExample
{
    public static void Run()
    {
        var foundRows = new List<string> { "row-a", "row-b" };
        Console.WriteLine($"Count == 0? {foundRows.Count == 0}");
        Console.WriteLine($"Count >= 2? {foundRows.Count >= 2}");

        var apiRecords = new List<OrderRow>
        {
            new("A", 10),
            new("B", 20),
        };
        Console.WriteLine($"API returned {apiRecords.Count} records (unknown upfront).");
    }

    public sealed record OrderRow(string Code, decimal Amount);
}
