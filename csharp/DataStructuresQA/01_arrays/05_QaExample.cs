namespace DataStructuresQA.Arrays;

/// <summary>
/// Practical QA automation examples using arrays and lists.
/// Scenarios: building query strings, parsing test data, validating API response IDs.
/// </summary>
internal static class QaExample
{
    public static void Run()
    {
        BuildQueryString();
        ParseCsvTestData();
        ValidateApiResponseIds();
        GenerateTestParameterSets();
    }

    private static void BuildQueryString()
    {
        Console.WriteLine("=== Build URL query string from parameter array ===");

        // Common in API testing: pass multiple IDs in a GET request.
        var ids = new[] { 2, 5, 7, 12 };
        var url = $"https://api.example.com/users?ids={string.Join(",", ids)}";
        Console.WriteLine($"Request URL: {url}");

        // With named helper.
        Console.WriteLine($"Helper result: {BuildQueryStringHelper(ids)}");
    }

    private static void ParseCsvTestData()
    {
        Console.WriteLine("\n=== Parse CSV test data into typed records ===");

        // Simulates reading a CSV fixture file line-by-line.
        var csvLines = new[]
        {
            "alice@test.com,admin,active",
            "bob@test.com,viewer,inactive",
            "charlie@test.com,editor,active",
        };

        var users = csvLines
            .Select(line => line.Split(','))
            .Select(parts => new TestUser(parts[0], parts[1], parts[2]))
            .ToList();

        Console.WriteLine($"Parsed {users.Count} users:");
        foreach (var u in users)
            Console.WriteLine($"  {u.Email,-25} role={u.Role,-8} status={u.Status}");
    }

    private static void ValidateApiResponseIds()
    {
        Console.WriteLine("\n=== Validate that API returned no duplicate IDs ===");

        // Simulate API response.
        var responseIds = new[] { "u1", "u2", "u3", "u4" };

        var hasDuplicates = responseIds.Length != responseIds.Distinct().Count();
        Console.WriteLine($"Response has duplicates: {hasDuplicates}");
        Console.WriteLine(hasDuplicates ? "FAIL: duplicate IDs detected" : "PASS: all IDs are unique");

        // Find which IDs are duplicated (for a failing case).
        var withDup = new[] { "u1", "u2", "u2", "u3" };
        var duplicated = withDup.GroupBy(id => id).Where(g => g.Count() > 1).Select(g => g.Key).ToArray();
        Console.WriteLine($"Duplicated IDs: [{string.Join(", ", duplicated)}]");
    }

    private static void GenerateTestParameterSets()
    {
        Console.WriteLine("\n=== Generate parameterized test inputs ===");

        // Build all combinations of environment × role for data-driven tests.
        var environments = new[] { "staging", "production" };
        var roles = new[] { "admin", "viewer" };

        var testCases = environments
            .SelectMany(env => roles, (env, role) => new { Environment = env, Role = role })
            .ToArray();

        Console.WriteLine($"Generated {testCases.Length} test case combinations:");
        foreach (var tc in testCases)
            Console.WriteLine($"  env={tc.Environment,-12} role={tc.Role}");
    }

    // ── Helpers ─────────────────────────────────────────────────────────────

    private static string BuildQueryStringHelper(int[] ids) =>
        "?ids=" + string.Join(",", ids);

    private sealed record TestUser(string Email, string Role, string Status);
}
