namespace DataStructuresQA.Dictionaries;

/// <summary>
/// Practical QA automation examples using Dictionary.
/// Scenarios: SQL operator mapping, config-driven test data, test result aggregation.
/// </summary>
internal static class QaExample
{
    public static void Run()
    {
        SqlOperatorMapping();
        ConfigDrivenTestData();
        AggregateTestResults();
    }

    private static void SqlOperatorMapping()
    {
        Console.WriteLine("=== SQL operator map for dynamic query building ===");

        var sqlByOp = new Dictionary<SqlOperator, string>
        {
            [SqlOperator.Equals] = "=",
            [SqlOperator.Like] = "LIKE",
            [SqlOperator.In] = "IN",
            [SqlOperator.GreaterThan] = ">",
        };

        var predicates = new[]
        {
            BuildPredicate("email", SqlOperator.Like, "%@test.com", sqlByOp),
            BuildPredicate("status", SqlOperator.Equals, "'active'", sqlByOp),
            BuildPredicate("age", SqlOperator.GreaterThan, "18", sqlByOp),
        };

        foreach (var p in predicates)
            Console.WriteLine($"  WHERE {p}");
    }

    private static void ConfigDrivenTestData()
    {
        Console.WriteLine("\n=== Config-driven test parameters ===");

        var testConfig = new Dictionary<string, string>
        {
            ["BASE_URL"] = "https://staging.example.com",
            ["API_KEY"] = "test-key-abc123",
            ["TIMEOUT_SEC"] = "30",
            ["RETRY_COUNT"] = "3",
        };

        Console.WriteLine("Test configuration:");
        foreach (var (key, value) in testConfig.OrderBy(kv => kv.Key))
            Console.WriteLine($"  {key,-15} = {value}");

        var timeout = int.Parse(testConfig.GetValueOrDefault("TIMEOUT_SEC", "10"));
        Console.WriteLine($"Parsed timeout: {timeout}s");
    }

    private static void AggregateTestResults()
    {
        Console.WriteLine("\n=== Aggregate test run results ===");

        var results = new[]
        {
            ("Login test", "pass"), ("Checkout test", "fail"),
            ("Search test", "pass"), ("Profile test", "fail"),
            ("API auth test", "pass"), ("API data test", "pass"),
        };

        // Count by status.
        var byStatus = new Dictionary<string, int>();
        foreach (var (_, status) in results)
            byStatus[status] = byStatus.GetValueOrDefault(status) + 1;

        Console.WriteLine("Results by status:");
        foreach (var (status, count) in byStatus.OrderBy(kv => kv.Key))
            Console.WriteLine($"  {status,-6} = {count}");

        var passRate = (double)byStatus.GetValueOrDefault("pass") / results.Length * 100;
        Console.WriteLine($"Pass rate: {passRate:F0}%");
    }

    private static string BuildPredicate(
        string column, SqlOperator op, string value,
        IReadOnlyDictionary<SqlOperator, string> map) =>
        $"{column} {map[op]} {value}";

    public enum SqlOperator { Equals, Like, In, GreaterThan }
}
