namespace DataStructuresQA.Challenges;

/// <summary>
/// Challenge: Find the most frequent character in a string.
/// Uses a Dictionary frequency map, then MaxBy to find the winner.
///
/// QA relevance: Same pattern finds the most common error message in test logs,
/// the most-hit API endpoint in access logs, or the most-failing test in CI history.
/// </summary>
internal static class MostFrequentChar
{
    public static void Run()
    {
        BasicChallenge();
        QaLogAnalysis();
    }

    private static void BasicChallenge()
    {
        Console.WriteLine("=== Most frequent character ===");

        const string text = "Beware the whispering winds of the Wandering Wastes";
        var (ch, count) = GetMostFrequentChar(text);
        Console.WriteLine($"Input: \"{text}\"");
        Console.WriteLine($"Most frequent: '{ch}' x {count}");
    }

    private static void QaLogAnalysis()
    {
        Console.WriteLine("\n=== QA: Most frequent error in test log ===");

        var logLines = new[]
        {
            "TimeoutException: element not found",
            "AssertionError: expected 200 got 404",
            "TimeoutException: element not found",
            "NullReferenceException: object not set",
            "AssertionError: expected 200 got 404",
            "TimeoutException: element not found",
            "AssertionError: expected 200 got 404",
            "StaleElementException: element stale",
        };

        // Extract just the exception type (before the colon).
        var errorTypes = logLines
            .Select(l => l.Split(':')[0].Trim())
            .ToArray();

        var freq = new Dictionary<string, int>();
        foreach (var e in errorTypes)
            freq[e] = freq.GetValueOrDefault(e) + 1;

        Console.WriteLine("Error frequency:");
        foreach (var (error, n) in freq.OrderByDescending(kv => kv.Value))
            Console.WriteLine($"  {error,-35} x{n}");

        var topError = freq.MaxBy(kv => kv.Value);
        Console.WriteLine($"\nMost common error: {topError.Key} ({topError.Value} occurrences)");
    }

    // ── Core algorithm ───────────────────────────────────────────────────────

    public static (char Character, int Count) GetMostFrequentChar(string text)
    {
        var freq = new Dictionary<char, int>();
        foreach (var ch in text)
            freq[ch] = freq.GetValueOrDefault(ch) + 1;

        var best = freq.MaxBy(kv => kv.Value);
        return (best.Key, best.Value);
    }
}
