namespace DataStructuresQA.Dictionaries;

/// <summary>Reading values from Dictionary, safe access, and iteration.</summary>
internal static class AccessingElements
{
    public static void Run()
    {
        Console.WriteLine("=== Read by key ===");
        var config = new Dictionary<string, string>
        {
            ["base_url"] = "https://api.example.com",
            ["timeout"] = "30",
        };

        Console.WriteLine($"config[\"base_url\"]           = {config["base_url"]}");

        Console.WriteLine("\n=== Safe access ===");
        Console.WriteLine($"TryGetValue:               {(config.TryGetValue("missing", out var v) ? v : "not found")}");
        Console.WriteLine($"GetValueOrDefault:          {config.GetValueOrDefault("missing", "default")}");
        Console.WriteLine($"ContainsKey:                {config.ContainsKey("timeout")}");

        Console.WriteLine("\n=== Iterating ===");
        foreach (var (key, value) in config.OrderBy(kv => kv.Key))
            Console.WriteLine($"  {key,-10} = {value}");

        Console.WriteLine("\n=== Keys and Values collections ===");
        Console.WriteLine($"Keys:   [{string.Join(", ", config.Keys.OrderBy(k => k))}]");
        Console.WriteLine($"Values: [{string.Join(", ", config.Values.OrderBy(v => v))}]");
    }
}
