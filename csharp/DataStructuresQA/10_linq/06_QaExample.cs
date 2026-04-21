namespace DataStructuresQA.Linq;

/// <summary>
/// LINQ for QA automation: filter failures, aggregate pass rates,
/// page through results, find regressions.
/// </summary>
internal static class QaExample
{
    private static readonly TestResult[] Results =
    [
        new("TC001", "login_happy_path",       "pass", 245, "Login"),
        new("TC002", "login_wrong_password",   "pass", 120, "Login"),
        new("TC003", "checkout_empty_cart",    "fail", 380, "Checkout"),
        new("TC004", "checkout_valid",         "pass",  95, "Checkout"),
        new("TC005", "search_no_results",      "fail", 560, "Search"),
        new("TC006", "search_with_filter",     "pass", 210, "Search"),
        new("TC007", "profile_update",         "fail", 430, "Profile"),
        new("TC008", "api_auth",               "pass", 180, "API"),
        new("TC009", "api_data",               "pass", 200, "API"),
        new("TC010", "api_rate_limit",         "fail", 670, "API"),
    ];

    public static void Run()
    {
        FilterAndReport();
        AggregateByCategory();
        PaginateResults();
        FindSlowTests();
    }

    private static void FilterAndReport()
    {
        Console.WriteLine("=== Filter failed tests and generate report ===");

        var failed = Results.Where(r => r.Status == "fail").OrderBy(r => r.Category).ToList();
        Console.WriteLine($"Failed tests ({failed.Count}/{Results.Length}):");
        failed.ForEach(r => Console.WriteLine($"  ✗ [{r.Id}] {r.Name,-30} ({r.Category})"));
    }

    private static void AggregateByCategory()
    {
        Console.WriteLine("\n=== Pass rate by category ===");

        var stats = Results
            .GroupBy(r => r.Category)
            .Select(g => new
            {
                Category = g.Key,
                Total = g.Count(),
                Passed = g.Count(r => r.Status == "pass"),
                AvgMs = g.Average(r => r.DurationMs),
            })
            .OrderBy(s => s.Category)
            .ToList();

        foreach (var s in stats)
        {
            var pct = (double)s.Passed / s.Total * 100;
            Console.WriteLine($"  {s.Category,-10} {s.Passed}/{s.Total} ({pct:F0}%)  avg={s.AvgMs:F0}ms");
        }

        var overall = (double)Results.Count(r => r.Status == "pass") / Results.Length * 100;
        Console.WriteLine($"  Overall: {overall:F0}%");
    }

    private static void PaginateResults()
    {
        Console.WriteLine("\n=== Paginate test results (page size = 3) ===");

        const int pageSize = 3;
        var sorted = Results.OrderBy(r => r.Id).ToList();
        var pageCount = (int)Math.Ceiling((double)sorted.Count / pageSize);

        for (int p = 0; p < pageCount; p++)
        {
            var page = sorted.Skip(p * pageSize).Take(pageSize).ToList();
            Console.WriteLine($"Page {p + 1}: [{string.Join(", ", page.Select(r => r.Id))}]");
        }
    }

    private static void FindSlowTests()
    {
        Console.WriteLine("\n=== Find slow tests (>= 400ms) ===");

        var slow = Results
            .Where(r => r.DurationMs >= 400)
            .OrderByDescending(r => r.DurationMs)
            .ToList();

        slow.ForEach(r => Console.WriteLine($"  [{r.Id}] {r.Name,-30} {r.DurationMs}ms  {r.Status}"));
    }

    private sealed record TestResult(string Id, string Name, string Status, int DurationMs, string Category);
}
