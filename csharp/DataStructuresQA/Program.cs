using DataStructuresQA.Examples;

var demos = new (string Key, string Title, Action Run)[]
{
    ("arrays", "01 — Arrays (query string, digit sum)", ArraysExample.Run),
    ("generics", "02 — Generics (API response model)", GenericsApiExample.Run),
    ("lists", "03 — Lists (QA-style scenarios)", ListsQaExample.Run),
    ("tuples", "04 — Tuples (multiple return values)", TuplesExample.Run),
    ("sets", "05 — Sets (dedupe, merge sources)", SetsExample.Run),
    ("maps", "06 — Maps (dictionary, SQL operator map)", MapsExample.Run),
    ("stack", "07 — Stack (LIFO resource pool)", StackExample.Run),
    ("queue", "08 — Queue (FIFO tasks)", QueueExample.Run),
    ("tree", "09 — Binary search tree (basics)", TreeBstExample.Run),
    ("transforms", "10 — LINQ / collection transforms", CollectionTransformsExample.Run),
    ("challenge", "11 — Challenge: most frequent character", MostFrequentCharExample.Run),
};

var key = args.Length > 0 ? args[0].Trim() : "all";
if (key.Equals("help", StringComparison.OrdinalIgnoreCase) || key.Equals("-h", StringComparison.OrdinalIgnoreCase))
{
    Console.WriteLine("Usage: dotnet run -- [key|all]");
    Console.WriteLine("Keys: " + string.Join(", ", demos.Select(d => d.Key)));
    return;
}

if (key.Equals("all", StringComparison.OrdinalIgnoreCase))
{
    foreach (var (_, title, run) in demos)
    {
        Console.WriteLine();
        Console.WriteLine(new string('=', 60));
        Console.WriteLine(title);
        Console.WriteLine(new string('=', 60));
        run();
    }
}
else
{
    var found = demos.FirstOrDefault(d => d.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
    if (found.Key is null)
    {
        Console.WriteLine($"Unknown key '{key}'. Use: dotnet run -- help");
        return;
    }

    found.Run();
}
