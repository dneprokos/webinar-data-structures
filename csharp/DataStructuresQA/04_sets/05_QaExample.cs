namespace DataStructuresQA.Sets;

/// <summary>
/// Practical QA automation examples using HashSet.
/// Scenarios: deduplicate test environments, verify unique API IDs, find uncovered test paths.
/// </summary>
internal static class QaExample
{
    public static void Run()
    {
        DeduplicateTestEnvironments();
        VerifyNoMissingPermissions();
        FindUntestedEndpoints();
    }

    private static void DeduplicateTestEnvironments()
    {
        Console.WriteLine("=== Deduplicate test environment URLs ===");

        // Multiple test configs may reference the same environment.
        var envUrls = new[]
        {
            "https://staging.example.com",
            "https://prod.example.com",
            "https://staging.example.com",   // duplicate
            "HTTPS://STAGING.EXAMPLE.COM",   // duplicate (different case)
        };

        var unique = new HashSet<string>(envUrls, StringComparer.OrdinalIgnoreCase);
        Console.WriteLine($"Input:  {envUrls.Length} URLs");
        Console.WriteLine($"Unique: {unique.Count} URLs");
        foreach (var url in unique.OrderBy(u => u))
            Console.WriteLine($"  {url}");
    }

    private static void VerifyNoMissingPermissions()
    {
        Console.WriteLine("\n=== Verify API response has all required fields ===");

        var required = new HashSet<string> { "id", "name", "email", "role", "createdAt" };
        var returned = new HashSet<string> { "id", "name", "email", "createdAt" };

        var missing = required.Except(returned).ToHashSet();
        var extra = returned.Except(required).ToHashSet();

        Console.WriteLine($"Missing fields: [{string.Join(", ", missing)}]");
        Console.WriteLine($"Extra fields:   [{string.Join(", ", extra)}]");
        Console.WriteLine(missing.Count == 0 ? "PASS: all required fields present" : "FAIL: missing fields detected");
    }

    private static void FindUntestedEndpoints()
    {
        Console.WriteLine("\n=== Find endpoints not yet covered by tests ===");

        var allEndpoints = new HashSet<string>
        {
            "GET /users", "POST /users", "GET /users/{id}",
            "PUT /users/{id}", "DELETE /users/{id}", "GET /orders",
        };

        var testedEndpoints = new HashSet<string>
        {
            "GET /users", "POST /users", "GET /users/{id}",
        };

        var untested = allEndpoints.Except(testedEndpoints).OrderBy(e => e).ToList();
        Console.WriteLine($"Total: {allEndpoints.Count}  Tested: {testedEndpoints.Count}  Untested: {untested.Count}");
        Console.WriteLine("Untested endpoints:");
        untested.ForEach(e => Console.WriteLine($"  ○ {e}"));
    }
}
