namespace DataStructuresQA.Tuples;

/// <summary>Creating tuples in C# — value tuples, named fields, and deconstruction.</summary>
internal static class Initialization
{
    public static void Run()
    {
        BasicTuples();
        NamedFields();
        FunctionReturns();
    }

    private static void BasicTuples()
    {
        Console.WriteLine("=== Basic value tuples ===");

        var pair = (1, "hello");
        Console.WriteLine($"(int, string):    Item1={pair.Item1}, Item2={pair.Item2}");

        var triple = (true, 3.14, 'x');
        Console.WriteLine($"(bool,double,char): {triple.Item1}, {triple.Item2}, {triple.Item3}");
    }

    private static void NamedFields()
    {
        Console.WriteLine("\n=== Named fields (strongly recommended) ===");

        var point = (X: 10, Y: 20);
        Console.WriteLine($"(X,Y) = ({point.X}, {point.Y})");

        var status = (Code: 200, Message: "OK", IsSuccess: true);
        Console.WriteLine($"HTTP: {status.Code} {status.Message} success={status.IsSuccess}");;
    }

    private static void FunctionReturns()
    {
        Console.WriteLine("\n=== Tuple from function ===");

        var (user, orders) = GetUserWithOrders("u1");
        Console.WriteLine($"{user.Name} has {orders.Count} orders");

        // Discard items you do not need with _.
        var (_, orderList) = GetUserWithOrders("u2");
        Console.WriteLine($"Orders only: [{string.Join(", ", orderList)}]");
    }

    public static (UserSummary User, List<string> Orders) GetUserWithOrders(string userId) =>
        (new UserSummary(userId, "Ann"), ["o1", "o2"]);

    public sealed record UserSummary(string Id, string Name);
}
