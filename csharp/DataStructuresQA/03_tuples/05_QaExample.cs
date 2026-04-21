namespace DataStructuresQA.Tuples;

/// <summary>
/// Practical QA automation examples using tuples.
/// Scenarios: page object methods returning status + element, validation results, config pairs.
/// </summary>
internal static class QaExample
{
    public static void Run()
    {
        PageObjectMultiReturn();
        ValidationResult();
        ConfigPairs();
    }

    private static void PageObjectMultiReturn()
    {
        Console.WriteLine("=== Page object method returning (element, isVisible) ===");

        // In Selenium/Playwright page objects, you often want the element AND its state.
        var (selector, isVisible) = GetLoginButton();
        Console.WriteLine($"Selector: '{selector}', Visible: {isVisible}");

        // Check and act.
        if (isVisible)
            Console.WriteLine("Proceeding to click login button");
        else
            Console.WriteLine("FAIL: login button not visible");
    }

    private static void ValidationResult()
    {
        Console.WriteLine("\n=== Validation returning (isValid, errorMessage) ===");

        var cases = new[] { "alice@test.com", "not-an-email", "bob@example.org" };

        foreach (var email in cases)
        {
            var (isValid, error) = ValidateEmail(email);
            Console.WriteLine($"  {email,-25} valid={isValid}  {(isValid ? "" : "error: " + error)}");
        }
    }

    private static void ConfigPairs()
    {
        Console.WriteLine("\n=== Environment config as list of (key, value) tuples ===");

        var config = GetTestConfig("staging");
        foreach (var (key, value) in config)
            Console.WriteLine($"  {key,-15} = {value}");
    }

    // ── Helpers ──────────────────────────────────────────────────────────────

    private static (string Selector, bool IsVisible) GetLoginButton() =>
        ("#login-btn", true);

    private static (bool IsValid, string Error) ValidateEmail(string email) =>
        email.Contains('@') && email.Contains('.')
            ? (true, string.Empty)
            : (false, "Invalid email format");

    private static List<(string Key, string Value)> GetTestConfig(string env) =>
    [
        ("BASE_URL", $"https://{env}.example.com"),
        ("TIMEOUT_SEC", "30"),
        ("HEADLESS", "true"),
    ];
}
