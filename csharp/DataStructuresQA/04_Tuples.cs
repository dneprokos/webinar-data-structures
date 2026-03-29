namespace DataStructuresQA.Examples;

/// <summary>Returning multiple values without a dedicated DTO (tuple / ValueTuple).</summary>
internal static class TuplesExample
{
    public static void Run()
    {
        var (user, orders) = GetUserWithOrders("u1");
        Console.WriteLine($"{user.Name} has {orders.Count} orders");
    }

    public static (UserSummary User, List<string> Orders) GetUserWithOrders(string userId) =>
        (new UserSummary(userId, "Ann"), new List<string> { "o1", "o2" });

    public sealed record UserSummary(string Id, string Name);
}
