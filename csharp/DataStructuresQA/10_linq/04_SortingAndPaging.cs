namespace DataStructuresQA.Linq;

/// <summary>LINQ ordering and paging: OrderBy, ThenBy, Skip, Take, Chunk.</summary>
internal static class SortingAndPaging
{
    private static readonly Product[] Products =
    [
        new("p1", "Laptop",   1200m, "Electronics"),
        new("p2", "Mouse",      25m, "Electronics"),
        new("p3", "Desk",      200m, "Furniture"),
        new("p4", "Chair",     300m, "Furniture"),
        new("p5", "Monitor",   400m, "Electronics"),
        new("p6", "Keyboard",   75m, "Electronics"),
    ];

    public static void Run()
    {
        OrderBy();
        MultiKeySort();
        SkipAndTake();
        Chunk();
    }

    private static void OrderBy()
    {
        Console.WriteLine("=== OrderBy / OrderByDescending ===");

        var byPrice = Products.OrderBy(p => p.Price).ToList();
        Console.WriteLine("By price asc:");
        byPrice.ForEach(p => Console.WriteLine($"  {p.Name,-12} ${p.Price:F0}"));

        var expensive = Products.OrderByDescending(p => p.Price).Take(3).ToList();
        Console.WriteLine("Top 3 most expensive:");
        expensive.ForEach(p => Console.WriteLine($"  {p.Name,-12} ${p.Price:F0}"));
    }

    private static void MultiKeySort()
    {
        Console.WriteLine("\n=== ThenBy (multi-key sort) ===");

        var multi = Products
            .OrderBy(p => p.Category)
            .ThenByDescending(p => p.Price)
            .ToList();

        Console.WriteLine("Category asc, Price desc:");
        multi.ForEach(p => Console.WriteLine($"  {p.Category,-12} {p.Name,-12} ${p.Price:F0}"));
    }

    private static void SkipAndTake()
    {
        Console.WriteLine("\n=== Skip / Take (pagination) ===");

        var sorted = Products.OrderBy(p => p.Price).ToList();
        int pageSize = 2;

        for (int page = 0; page * pageSize < sorted.Count; page++)
        {
            var slice = sorted.Skip(page * pageSize).Take(pageSize).ToList();
            Console.WriteLine($"Page {page + 1}: [{string.Join(", ", slice.Select(p => p.Name))}]");
        }
    }

    private static void Chunk()
    {
        Console.WriteLine("\n=== Chunk (split into fixed batches) ===");

        var chunks = Products.OrderBy(p => p.Name).Chunk(2).ToList();
        for (int i = 0; i < chunks.Count; i++)
            Console.WriteLine($"Chunk {i + 1}: [{string.Join(", ", chunks[i].Select(p => p.Name))}]");
    }

    private sealed record Product(string Id, string Name, decimal Price, string Category);
}
