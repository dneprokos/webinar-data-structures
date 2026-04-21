namespace DataStructuresQA.Lists;

/// <summary>
/// Practical QA automation examples using List&lt;T&gt;.
/// Scenarios: API response validation, dynamic test case collection, filtering test results.
/// </summary>
internal static class QaExample
{
    public static void Run()
    {
        ApiResponseValidation();
        CollectingTestResults();
        DynamicTestCaseGeneration();
    }

    private static void ApiResponseValidation()
    {
        Console.WriteLine("=== Validate API response row count ===");

        var apiRecords = new List<OrderRow>
        {
            new("A", 10.0m),
            new("B", 20.0m),
            new("C", 30.0m),
        };

        // Common QA assertion patterns.
        Console.WriteLine($"Count == 0?   {apiRecords.Count == 0}   (FAIL — expected at least 1)");
        Console.WriteLine($"Count >= 3?   {apiRecords.Count >= 3}   (PASS)");
        Console.WriteLine($"Any(>= 25)?   {apiRecords.Any(r => r.Amount >= 25)}");

        // Find specific row.
        var row = apiRecords.Find(r => r.Code == "B");
        Console.WriteLine($"Find code B:  {row}");

        // Verify all codes are unique.
        var allUnique = apiRecords.Count == apiRecords.Select(r => r.Code).Distinct().Count();
        Console.WriteLine($"All codes unique: {allUnique}");
    }

    private static void CollectingTestResults()
    {
        Console.WriteLine("\n=== Collect and analyze test results ===");

        var results = new List<TestResult>
        {
            new("Login happy path", "pass"),
            new("Login wrong password", "pass"),
            new("Checkout empty cart", "fail"),
            new("Search no results", "pass"),
            new("Profile update", "fail"),
        };

        var passed = results.Where(r => r.Status == "pass").ToList();
        var failed = results.Where(r => r.Status == "fail").ToList();

        Console.WriteLine($"Total: {results.Count}  Passed: {passed.Count}  Failed: {failed.Count}");
        Console.WriteLine("Failed tests:");
        failed.ForEach(r => Console.WriteLine($"  ✗ {r.Name}"));

        var passRate = (double)passed.Count / results.Count * 100;
        Console.WriteLine($"Pass rate: {passRate:F0}%");
    }

    private static void DynamicTestCaseGeneration()
    {
        Console.WriteLine("\n=== Build dynamic test case list ===");

        // Collect test cases based on environment config.
        var testCases = new List<string>();

        var features = new[] { "login", "checkout", "profile" };
        var envs = new[] { "staging" };

        foreach (var feature in features)
            foreach (var env in envs)
                testCases.Add($"{feature}@{env}");

        Console.WriteLine($"Generated {testCases.Count} test cases:");
        testCases.ForEach(tc => Console.WriteLine($"  {tc}"));
    }

    private sealed record OrderRow(string Code, decimal Amount);
    private sealed record TestResult(string Name, string Status);
}
