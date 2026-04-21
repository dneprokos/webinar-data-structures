namespace DataStructuresQA.Tuples;

/// <summary>Reading tuple fields, pattern matching, and switching on tuples.</summary>
internal static class AccessingElements
{
    public static void Run()
    {
        FieldAccess();
        Deconstruction();
        PatternMatching();
    }

    private static void FieldAccess()
    {
        Console.WriteLine("=== Field access ===");

        var result = (Status: 200, Body: "OK");

        // By name (preferred when fields are named).
        Console.WriteLine($"result.Status = {result.Status}");
        Console.WriteLine($"result.Body   = {result.Body}");

        // By position (fallback; less readable).
        Console.WriteLine($"Item1         = {result.Item1}");
    }

    private static void Deconstruction()
    {
        Console.WriteLine("\n=== Deconstruction ===");

        var (code, message) = (404, "Not Found");
        Console.WriteLine($"code={code}, message={message}");

        // Swap via tuple deconstruction.
        var a = 1;
        var b = 2;
        (a, b) = (b, a);
        Console.WriteLine($"After swap: a={a}, b={b}");

        // Deconstruct into existing variables.
        int x, y;
        (x, y) = GetCoords();
        Console.WriteLine($"Coords: x={x}, y={y}");
    }

    private static void PatternMatching()
    {
        Console.WriteLine("\n=== Tuple switch expression ===");

        var cases = new[] { (200, "GET"), (201, "POST"), (404, "GET"), (500, "POST") };

        foreach (var (status, method) in cases)
        {
            var label = (status, method) switch
            {
                (200, "GET") => "OK get",
                (201, "POST") => "Created",
                ( >= 400, _) => $"Error {status}",
                _ => "other",
            };
            Console.WriteLine($"  ({status},{method}) -> {label}");
        }
    }

    private static (int X, int Y) GetCoords() => (42, 99);
}
