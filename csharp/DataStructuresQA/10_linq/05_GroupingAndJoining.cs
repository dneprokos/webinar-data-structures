namespace DataStructuresQA.Linq;

/// <summary>LINQ grouping and joining: GroupBy, Join, Zip, Union, Intersect, Concat.</summary>
internal static class GroupingAndJoining
{
    public static void Run()
    {
        GroupBy();
        Join();
        ZipAndConcat();
        SetOperations();
    }

    private static void GroupBy()
    {
        Console.WriteLine("=== GroupBy ===");

        var employees = new[]
        {
            new Employee("e1", "Ann",   "QA",  90_000),
            new Employee("e2", "Bob",   "Dev", 80_000),
            new Employee("e3", "Carl",  "QA",  70_000),
            new Employee("e4", "Diana", "Dev", 85_000),
            new Employee("e5", "Eve",   "Ops", 75_000),
        };

        var byDept = employees.GroupBy(e => e.Department);
        foreach (var group in byDept.OrderBy(g => g.Key))
        {
            var names = string.Join(", ", group.Select(e => e.Name));
            var avgSalary = group.Average(e => e.Salary);
            Console.WriteLine($"  {group.Key,-5}: [{names}]  avg=${avgSalary:F0}");
        }

        // GroupBy → Dictionary.
        var dict = employees
            .GroupBy(e => e.Department)
            .ToDictionary(g => g.Key, g => g.Select(e => e.Name).ToList());
        Console.WriteLine($"\nQA team:  [{string.Join(", ", dict["QA"])}]");
    }

    private static void Join()
    {
        Console.WriteLine("\n=== Join (inner join) ===");

        var orders = new[]
        {
            new Order("o1", "e1", 200m),
            new Order("o2", "e2", 150m),
            new Order("o3", "e1", 300m),
        };

        var customers = new[]
        {
            new Customer("e1", "Ann"),
            new Customer("e2", "Bob"),
        };

        var joined = customers
            .Join(
                orders,
                c => c.Id,
                o => o.CustomerId,
                (c, o) => new { c.Name, o.Id, o.Amount })
            .ToList();

        foreach (var r in joined)
            Console.WriteLine($"  {r.Name}: order {r.Id} = ${r.Amount}");
    }

    private static void ZipAndConcat()
    {
        Console.WriteLine("\n=== Zip ===");

        var keys = new[] { "BASE_URL", "TIMEOUT", "RETRY" };
        var values = new[] { "https://api.example.com", "30", "3" };

        var config = keys.Zip(values, (k, v) => $"{k}={v}").ToList();
        config.ForEach(Console.WriteLine);

        Console.WriteLine("\n=== Concat ===");
        var stagingTests = new[] { "login", "checkout" };
        var prodTests = new[] { "smoke", "regression" };
        var all = stagingTests.Concat(prodTests).ToList();
        Console.WriteLine($"All tests: [{string.Join(", ", all)}]");
    }

    private static void SetOperations()
    {
        Console.WriteLine("\n=== Set operations ===");

        var setA = new[] { "login", "checkout", "profile" };
        var setB = new[] { "checkout", "profile", "search" };

        Console.WriteLine($"Union:        [{string.Join(", ", setA.Union(setB))}]");
        Console.WriteLine($"Intersect:    [{string.Join(", ", setA.Intersect(setB))}]");
        Console.WriteLine($"Except(A-B):  [{string.Join(", ", setA.Except(setB))}]");
    }

    private sealed record Employee(string Id, string Name, string Department, int Salary);
    private sealed record Order(string Id, string CustomerId, decimal Amount);
    private sealed record Customer(string Id, string Name);
}
