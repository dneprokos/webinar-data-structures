using System.Net;

namespace DataStructuresQA.Generics;

/// <summary>
/// Generic API response wrapper pattern used in real QA automation frameworks.
/// A single typed envelope works for any API endpoint, gives full IntelliSense,
/// and avoids casting `object` at every call site.
/// </summary>
internal static class QaExample
{
    public static void Run()
    {
        TypedApiResponse();
        GenericAssertionHelper();
        GenericTestDataBuilder();
    }

    private static void TypedApiResponse()
    {
        Console.WriteLine("=== Typed API response wrapper ===");

        // Same envelope type works for any endpoint — no casting needed.
        var usersResp = ApiCall<List<UserDto>>("/api/users", HttpStatusCode.OK,
            [new("u1", "Ann", "admin"), new("u2", "Bob", "viewer")]);

        var orderResp = ApiCall<OrderDto>("/api/orders/1", HttpStatusCode.OK,
            new OrderDto("o1", 199.99m));

        Console.WriteLine($"GET /api/users        -> {usersResp.StatusCode}, {usersResp.Body.Count} users");
        Console.WriteLine($"GET /api/orders/1     -> {orderResp.StatusCode}, order {orderResp.Body.Id} = ${orderResp.Body.Total}");

        // Verify status with a generic helper.
        AssertStatus(usersResp, HttpStatusCode.OK);
        AssertStatus(orderResp, HttpStatusCode.OK);
        Console.WriteLine("Both status assertions passed");
    }

    private static void GenericAssertionHelper()
    {
        Console.WriteLine("\n=== Generic assertion helpers ===");

        var items = new List<int> { 1, 2, 3 };

        AssertNotEmpty(items, "items list");
        Console.WriteLine("AssertNotEmpty passed");

        var found = FindFirst<int>(items, x => x > 1);
        Console.WriteLine($"FindFirst(> 1)       = {found}");
    }

    private static void GenericTestDataBuilder()
    {
        Console.WriteLine("\n=== Generic test data factory ===");

        // Create many default instances for data-driven tests.
        var users = TestDataFactory.CreateMany<UserDto>(3, i => new UserDto($"u{i}", $"User{i}", "viewer"));
        foreach (var u in users)
            Console.WriteLine($"  {u.Id}: {u.Name} ({u.Role})");
    }

    // ── Helpers ──────────────────────────────────────────────────────────────

    private static ApiResponse<T> ApiCall<T>(string endpoint, HttpStatusCode status, T body) where T : class
    {
        Console.WriteLine($"  [HTTP] {endpoint}");
        return new ApiResponse<T>(status, body);
    }

    private static void AssertStatus<T>(ApiResponse<T> response, HttpStatusCode expected) where T : class
    {
        if (response.StatusCode != expected)
            throw new Exception($"Expected {expected} but got {response.StatusCode}");
    }

    private static void AssertNotEmpty<T>(ICollection<T> collection, string name)
    {
        if (collection.Count == 0)
            throw new Exception($"{name} must not be empty");
    }

    private static T? FindFirst<T>(IEnumerable<T> source, Func<T, bool> predicate) =>
        source.FirstOrDefault(predicate);

    // ── Types ────────────────────────────────────────────────────────────────

    public sealed record ApiResponse<TBody>(HttpStatusCode StatusCode, TBody Body) where TBody : class;

    public sealed record UserDto(string Id, string Name, string Role);

    public sealed record OrderDto(string Id, decimal Total);

    public static class TestDataFactory
    {
        public static List<T> CreateMany<T>(int count, Func<int, T> factory) =>
            Enumerable.Range(1, count).Select(factory).ToList();
    }
}
