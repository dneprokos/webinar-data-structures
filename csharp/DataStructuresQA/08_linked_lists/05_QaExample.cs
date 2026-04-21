namespace DataStructuresQA.LinkedLists;

/// <summary>
/// Practical QA automation examples using LinkedList.
/// Scenarios: browser navigation history, form-wizard undo, sequential test-step chain.
/// </summary>
internal static class QaExample
{
    public static void Run()
    {
        BrowserNavigationHistory();
        FormWizardUndo();
        TestStepChain();
    }

    // Simulates a QA bot navigating pages and using back/forward like a real browser.
    private static void BrowserNavigationHistory()
    {
        Console.WriteLine("=== Browser navigation history ===");

        var history = new LinkedList<string>();
        LinkedListNode<string>? current = null;

        void Navigate(string url)
        {
            // Drop forward history when navigating to a new page.
            while (current?.Next is not null)
                history.Remove(current.Next);

            current = history.AddLast(url);
            Console.WriteLine($"  Navigate -> {url}  (history length: {history.Count})");
        }

        void GoBack()
        {
            if (current?.Previous is null) { Console.WriteLine("  Back: already at start"); return; }
            current = current.Previous;
            Console.WriteLine($"  Back    <- {current.Value}");
        }

        void GoForward()
        {
            if (current?.Next is null) { Console.WriteLine("  Forward: already at end"); return; }
            current = current.Next;
            Console.WriteLine($"  Forward -> {current.Value}");
        }

        Navigate("/login");
        Navigate("/dashboard");
        Navigate("/orders");
        Navigate("/order/42");
        GoBack();
        GoBack();
        Console.WriteLine($"  Current page: {current?.Value}");
        Navigate("/profile");        // Clears /orders and /order/42 forward history.
        GoForward();                 // Should report already at end.
        GoBack();
        Console.WriteLine($"  Current page after back: {current?.Value}");
    }

    // Simulates a multi-step form wizard where the tester undoes steps one by one.
    private static void FormWizardUndo()
    {
        Console.WriteLine("\n=== Form wizard undo history ===");

        var steps = new LinkedList<string>();
        steps.AddLast("Filled: first name");
        steps.AddLast("Filled: last name");
        steps.AddLast("Filled: email");
        steps.AddLast("Filled: address");

        Console.WriteLine($"Completed steps ({steps.Count}):");
        foreach (var s in steps)
            Console.WriteLine($"  + {s}");

        Console.WriteLine("Undoing last 2 steps:");
        for (int i = 0; i < 2 && steps.Last is not null; i++)
        {
            Console.WriteLine($"  Undo: {steps.Last.Value}");
            steps.RemoveLast();
        }

        Console.WriteLine($"Remaining steps ({steps.Count}):");
        foreach (var s in steps)
            Console.WriteLine($"  + {s}");
    }

    // Walks a linked list of test steps and executes each in order.
    private static void TestStepChain()
    {
        Console.WriteLine("\n=== Sequential test-step chain ===");

        var testSteps = new LinkedList<(string Name, Func<bool> Execute)>();
        testSteps.AddLast(("Open login page",   () => true));
        testSteps.AddLast(("Enter credentials", () => true));
        testSteps.AddLast(("Click login",       () => true));
        testSteps.AddLast(("Assert dashboard",  () => true));
        testSteps.AddLast(("Assert user name",  () => false)); // Simulates a failing assertion.

        int passed = 0, failed = 0;
        var node = testSteps.First;
        while (node is not null)
        {
            var (name, execute) = node.Value;
            bool ok = execute();
            Console.WriteLine($"  [{(ok ? "PASS" : "FAIL")}] {name}");
            if (ok) passed++; else { failed++; break; } // Stop on first failure (fail-fast).
            node = node.Next;
        }

        Console.WriteLine($"Result: {passed} passed, {failed} failed out of {testSteps.Count} steps");
    }
}
