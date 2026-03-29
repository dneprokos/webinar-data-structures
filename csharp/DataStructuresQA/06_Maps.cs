namespace DataStructuresQA.Examples;

/// <summary>Dictionary: SQL operator mapping and in-run lookup tables.</summary>
internal static class MapsExample
{
    public static void Run()
    {
        var sqlByOp = new Dictionary<SqlOperator, string>
        {
            [SqlOperator.Equals] = "=",
            [SqlOperator.Like] = "LIKE",
            [SqlOperator.In] = "IN",
        };
        Console.WriteLine(BuildPredicate("email", SqlOperator.Like, "%@test.com", sqlByOp));

        var bookPrices = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase)
        {
            ["Clean Code"] = 42.5m,
            ["Refactoring"] = 39m,
        };
        Console.WriteLine(bookPrices.GetValueOrDefault("clean code", 0));
    }

    public enum SqlOperator
    {
        Equals,
        Like,
        In,
    }

    public static string BuildPredicate(string column, SqlOperator op, string value, IReadOnlyDictionary<SqlOperator, string> map) =>
        $"{column} {map[op]} {value}";
}
