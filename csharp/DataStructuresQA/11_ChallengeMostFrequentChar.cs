namespace DataStructuresQA.Examples;

/// <summary>Combine dict + ordering: most frequent character (Python article challenge).</summary>
internal static class MostFrequentCharExample
{
    public static void Run()
    {
        const string text = "Beware the whispering winds of the Wandering Wastes";
        var (ch, count) = GetMostFrequentChar(text);
        Console.WriteLine($"'{ch}' x {count}");
    }

    public static (char Character, int Count) GetMostFrequentChar(string text)
    {
        var freq = new Dictionary<char, int>();
        foreach (var ch in text)
            freq[ch] = freq.GetValueOrDefault(ch) + 1;

        var best = freq.MaxBy(kv => kv.Value);
        return (best.Key, best.Value);
    }
}
