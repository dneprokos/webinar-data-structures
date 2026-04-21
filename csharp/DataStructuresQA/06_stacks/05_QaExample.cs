namespace DataStructuresQA.Stacks;

/// <summary>
/// Practical QA automation examples using Stack.
/// Scenarios: browser navigation history, client resource pool, undo-redo simulation.
/// </summary>
internal static class QaExample
{
    public static void Run()
    {
        BrowserNavigationHistory();
        ClientResourcePool();
        UndoRedoSimulation();
    }

    private static void BrowserNavigationHistory()
    {
        Console.WriteLine("=== Browser navigation history (back button) ===");

        var history = new Stack<string>();

        // User navigates through pages.
        history.Push("https://example.com");
        history.Push("https://example.com/products");
        history.Push("https://example.com/products/42");
        Console.WriteLine($"Current page: {history.Peek()}");

        // User clicks Back.
        history.Pop();
        Console.WriteLine($"After Back:   {history.Peek()}");

        history.Pop();
        Console.WriteLine($"After Back:   {history.Peek()}");

        Console.WriteLine($"History depth: {history.Count}");
    }

    private static void ClientResourcePool()
    {
        Console.WriteLine("\n=== Parallel test client pool ===");

        // Push available client IDs into the pool.
        var pool = new Stack<int>();
        foreach (var id in new[] { 101, 102, 103 })
            pool.Push(id);

        Console.WriteLine($"Pool size: {pool.Count}");

        // Test 1 acquires a client.
        var client1 = pool.Pop();
        Console.WriteLine($"Test 1 acquired client {client1}, pool remaining: {pool.Count}");

        // Test 2 acquires a client.
        var client2 = pool.Pop();
        Console.WriteLine($"Test 2 acquired client {client2}, pool remaining: {pool.Count}");

        // Tests finish — return clients.
        pool.Push(client1);
        pool.Push(client2);
        Console.WriteLine($"Clients returned. Pool size: {pool.Count}");
    }

    private static void UndoRedoSimulation()
    {
        Console.WriteLine("\n=== Undo-redo for form fill actions ===");

        var undoStack = new Stack<string>();
        var redoStack = new Stack<string>();

        void DoAction(string action)
        {
            Console.WriteLine($"  Do: {action}");
            undoStack.Push(action);
            redoStack.Clear();
        }

        void Undo()
        {
            if (undoStack.Count == 0) return;
            var action = undoStack.Pop();
            redoStack.Push(action);
            Console.WriteLine($"  Undo: {action}");
        }

        void Redo()
        {
            if (redoStack.Count == 0) return;
            var action = redoStack.Pop();
            undoStack.Push(action);
            Console.WriteLine($"  Redo: {action}");
        }

        DoAction("type 'admin' in username");
        DoAction("type 'pass' in password");
        DoAction("click login");

        Undo(); // undo click login
        Undo(); // undo type password
        Redo(); // redo type password

        Console.WriteLine($"Undo stack: {undoStack.Count}, Redo stack: {redoStack.Count}");
    }
}
