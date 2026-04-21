namespace DataStructuresQA.Linq;

/// <summary>LINQ filtering: Where, First, Single, Any, All, OfType, Distinct.</summary>
internal static class Filtering
{
    private static readonly Employee[] Employees =
    [
        new("e1", "Ann",     "SDET",   90_000, "QA"),
        new("e2", "Bob",     "QA",     70_000, "QA"),
        new("e3", "Carl",    "DevOps", 85_000, "Ops"),
        new("e4", "Diana",   "SDET",   95_000, "QA"),
        new("e5", "Eve",     "Dev",    80_000, "Dev"),
    ];

    public static void Run()
    {
        WhereExamples();
        FirstAndSingle();
        AnyAndAll();
        DistinctAndOfType();
    }

    private static void WhereExamples()
    {
        Console.WriteLine("=== Where ===");

        var qa = Employees.Where(e => e.Department == "QA").ToList();
        Console.WriteLine($"Department == 'QA'   -> [{string.Join(", ", qa.Select(e => e.Name))}]");

        var highEarners = Employees.Where(e => e.Salary > 85_000).ToList();
        Console.WriteLine($"Salary > 85k         -> [{string.Join(", ", highEarners.Select(e => e.Name))}]");

        var sdetQa = Employees.Where(e => e.Title == "SDET" && e.Department == "QA").ToList();
        Console.WriteLine($"SDET in QA           -> [{string.Join(", ", sdetQa.Select(e => e.Name))}]");
    }

    private static void FirstAndSingle()
    {
        Console.WriteLine("\n=== First / FirstOrDefault / Single ===");

        var first = Employees.First(e => e.Department == "QA");
        Console.WriteLine($"First QA             = {first.Name}");

        var missing = Employees.FirstOrDefault(e => e.Title == "Manager");
        Console.WriteLine($"FirstOrDefault(Mgr)  = {missing?.Name ?? "null"}");

        var ann = Employees.Single(e => e.Id == "e1");
        Console.WriteLine($"Single(id=e1)        = {ann.Name}");

        var lastQa = Employees.Last(e => e.Department == "QA");
        Console.WriteLine($"Last QA              = {lastQa.Name}");
    }

    private static void AnyAndAll()
    {
        Console.WriteLine("\n=== Any / All ===");

        Console.WriteLine($"Any salary > 90k     = {Employees.Any(e => e.Salary > 90_000)}");
        Console.WriteLine($"All salary > 50k     = {Employees.All(e => e.Salary > 50_000)}");
        Console.WriteLine($"All QA               = {Employees.All(e => e.Department == "QA")}");
    }

    private static void DistinctAndOfType()
    {
        Console.WriteLine("\n=== Distinct / DistinctBy ===");

        var deps = Employees.Select(e => e.Department).Distinct().OrderBy(d => d).ToList();
        Console.WriteLine($"Distinct depts       = [{string.Join(", ", deps)}]");

        var byDept = Employees.DistinctBy(e => e.Department).Select(e => e.Department).OrderBy(d => d).ToList();
        Console.WriteLine($"DistinctBy(dept)     = [{string.Join(", ", byDept)}]");

        Console.WriteLine("\n=== OfType (filter by type) ===");
        object[] mixed = { 1, "hello", 2.5, "world", 42 };
        var strings = mixed.OfType<string>().ToList();
        Console.WriteLine($"OfType<string>       = [{string.Join(", ", strings)}]");
    }

    private sealed record Employee(string Id, string Name, string Title, int Salary, string Department);
}
