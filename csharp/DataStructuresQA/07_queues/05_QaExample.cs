namespace DataStructuresQA.Queues;

/// <summary>
/// Practical QA automation examples using Queue.
/// Scenarios: test execution queue, request rate limiter simulation, event processing.
/// </summary>
internal static class QaExample
{
    public static void Run()
    {
        TestExecutionQueue();
        RateLimiterSimulation();
        EventProcessing();
    }

    private static void TestExecutionQueue()
    {
        Console.WriteLine("=== Test execution queue (FIFO scheduling) ===");

        var testQueue = new Queue<string>();
        testQueue.Enqueue("login_happy_path");
        testQueue.Enqueue("login_wrong_password");
        testQueue.Enqueue("checkout_empty_cart");
        testQueue.Enqueue("search_no_results");

        Console.WriteLine($"Scheduled {testQueue.Count} tests:");

        var results = new List<(string Name, string Status)>();
        int runNumber = 1;

        while (testQueue.Count > 0)
        {
            var testName = testQueue.Dequeue();
            // Simulate test run: even tests pass.
            var status = runNumber % 2 == 0 ? "fail" : "pass";
            results.Add((testName, status));
            Console.WriteLine($"  [{runNumber++}] {testName,-30} -> {status}");
        }

        var passed = results.Count(r => r.Status == "pass");
        Console.WriteLine($"Result: {passed}/{results.Count} passed");
    }

    private static void RateLimiterSimulation()
    {
        Console.WriteLine("\n=== Rate limiter: process max N requests per batch ===");

        const int batchSize = 2;

        var requests = new Queue<string>(new[]
        {
            "GET /api/users", "POST /api/orders", "GET /api/products",
            "DELETE /api/sessions", "GET /api/reports",
        });

        int batch = 1;
        while (requests.Count > 0)
        {
            Console.WriteLine($"  Batch {batch++}:");
            for (int i = 0; i < batchSize && requests.Count > 0; i++)
                Console.WriteLine($"    processed: {requests.Dequeue()}");
        }
    }

    private static void EventProcessing()
    {
        Console.WriteLine("\n=== Event bus: process UI events in order ===");

        var events = new Queue<string>();
        events.Enqueue("page_load");
        events.Enqueue("user_click_login");
        events.Enqueue("api_request_sent");
        events.Enqueue("api_response_received");
        events.Enqueue("page_redirect");

        Console.WriteLine("Processing events in arrival order:");
        while (events.Count > 0)
            Console.WriteLine($"  [event] {events.Dequeue()}");
    }
}
