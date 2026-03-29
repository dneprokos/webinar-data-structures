using System.Net;

namespace DataStructuresQA.Examples;

/// <summary>Fixed-size arrays: query params and parsing (see Medium: Data Structures for QA).</summary>
internal static class ArraysExample
{
    public static void Run()
    {
        var ids = new[] { 2, 5, 7 };
        Console.WriteLine(BuildQueryString(ids));

        var messy = "a1b2c3";
        Console.WriteLine(SumDigitCharacters(messy));
    }

    /// <summary>Builds ?ids=2,5,7 from a params-style array.</summary>
    public static string BuildQueryString(int[] ids) =>
        "?ids=" + string.Join(",", ids);

    /// <summary>Sums all digit characters in a string.</summary>
    public static int SumDigitCharacters(string text)
    {
        var sum = 0;
        foreach (var ch in text)
        {
            if (char.IsDigit(ch))
                sum += ch - '0';
        }

        return sum;
    }
}
