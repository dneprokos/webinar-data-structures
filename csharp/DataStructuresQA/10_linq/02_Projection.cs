namespace DataStructuresQA.Linq;

/// <summary>LINQ projection: Select, SelectMany, anonymous types, new DTOs.</summary>
internal static class Projection
{
    private static readonly Order[] Orders =
    [
        new("o1", "e1", new[] { new Item("Laptop", 1200m), new Item("Mouse", 25m) }),
        new("o2", "e2", new[] { new Item("Keyboard", 75m) }),
        new("o3", "e1", new[] { new Item("Monitor", 400m), new Item("Desk", 200m), new Item("Chair", 300m) }),
    ];

    public static void Run()
    {
        SelectBasics();
        SelectToDto();
        SelectMany();
    }

    private static void SelectBasics()
    {
        Console.WriteLine("=== Select — transform each element ===");

        var ids = Orders.Select(o => o.Id).ToList();
        Console.WriteLine($"Select Id            = [{string.Join(", ", ids)}]");

        var totals = Orders.Select(o => (o.Id, Total: o.Items.Sum(i => i.Price))).ToList();
        foreach (var (id, total) in totals)
            Console.WriteLine($"  {id}: ${total:F0}");

        // Select with index.
        var indexed = Orders.Select((o, i) => $"[{i}] {o.Id}").ToList();
        Console.WriteLine($"Select with index    = [{string.Join(", ", indexed)}]");
    }

    private static void SelectToDto()
    {
        Console.WriteLine("\n=== Select to anonymous type or record ===");

        var summaries = Orders.Select(o => new
        {
            o.Id,
            ItemCount = o.Items.Length,
            Total = o.Items.Sum(i => i.Price),
        }).ToList();

        foreach (var s in summaries)
            Console.WriteLine($"  {s.Id}: {s.ItemCount} items, ${s.Total:F0}");
    }

    private static void SelectMany()
    {
        Console.WriteLine("\n=== SelectMany — flatten nested collections ===");

        // Flatten all items from all orders into one list.
        var allItems = Orders.SelectMany(o => o.Items).ToList();
        Console.WriteLine($"All items: [{string.Join(", ", allItems.Select(i => i.Name))}]");

        // SelectMany with result selector — keep parent info.
        var itemsWithOrder = Orders
            .SelectMany(o => o.Items, (order, item) => new { order.Id, item.Name, item.Price })
            .ToList();

        foreach (var x in itemsWithOrder)
            Console.WriteLine($"  {x.Id}: {x.Name,-10} ${x.Price:F0}");
    }

    private sealed record Order(string Id, string CustomerId, Item[] Items);
    private sealed record Item(string Name, decimal Price);
}
