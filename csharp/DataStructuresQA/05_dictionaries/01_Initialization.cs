namespace DataStructuresQA.Dictionaries;

/// <summary>Creating Dictionary instances in C#.</summary>
internal static class Initialization
{
    public static void Run()
    {
        Console.WriteLine("=== Basic dictionary ===");
        var scores = new Dictionary<string, int>
        {
            ["Alice"] = 92,
            ["Bob"] = 85,
            ["Charlie"] = 78,
        };
        Console.WriteLine($"inline initializer     -> Count={scores.Count}");

        Console.WriteLine("\n=== Enum key dictionary ===");
        var sqlByOp = new Dictionary<SqlOperator, string>
        {
            [SqlOperator.Equals] = "=",
            [SqlOperator.Like] = "LIKE",
            [SqlOperator.In] = "IN",
        };
        Console.WriteLine($"enum key dict          -> Count={sqlByOp.Count}");

        Console.WriteLine("\n=== Case-insensitive key ===");
        var bookPrices = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase)
        {
            ["Clean Code"] = 42.5m,
            ["Refactoring"] = 39m,
        };
        Console.WriteLine($"OrdinalIgnoreCase      -> Count={bookPrices.Count}");
        Console.WriteLine($"lookup 'clean code'    = {bookPrices.GetValueOrDefault("clean code", 0)}");

        Console.WriteLine("\n=== Nested dictionary ===");
        var nested = new Dictionary<string, Dictionary<string, int>>
        {
            ["env1"] = new() { ["pass"] = 10, ["fail"] = 2 },
            ["env2"] = new() { ["pass"] = 8, ["fail"] = 5 },
        };
        Console.WriteLine($"nested dict            -> env1.pass={nested["env1"]["pass"]}");
    }

    public enum SqlOperator { Equals, Like, In }
}
