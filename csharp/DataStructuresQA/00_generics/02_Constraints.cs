namespace DataStructuresQA.Generics;

/// <summary>
/// Type constraints — limit which types are allowed for T.
/// Constraints: class, struct, new(), interface, IComparable, combined.
/// </summary>
internal static class Constraints
{
    public static void Run()
    {
        ClassConstraint();
        StructAndComparableConstraint();
        NewConstraint();
        InterfaceConstraint();
        CombinedConstraints();
    }

    private static void ClassConstraint()
    {
        Console.WriteLine("=== where T : class (reference types only) ===");

        // Only reference types allowed — int, bool, etc. would not compile.
        var nullableUser = NullSafe<UserDto>(null);
        Console.WriteLine($"NullSafe<UserDto>(null) -> {nullableUser?.Name ?? "null"}");

        var validUser = NullSafe<UserDto>(new UserDto("u1", "Ann"));
        Console.WriteLine($"NullSafe(valid user)    -> {validUser?.Name}");
    }

    private static void StructAndComparableConstraint()
    {
        Console.WriteLine("\n=== where T : struct, IComparable<T> ===");

        Console.WriteLine($"Max(10, 25)             = {Max(10, 25)}");
        Console.WriteLine($"Max(3.14, 2.71)         = {Max(3.14, 2.71)}");

        var d1 = DateOnly.FromDateTime(DateTime.Today);
        var d2 = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        Console.WriteLine($"Max(today, tomorrow)    = {Max(d1, d2)}");
    }

    private static void NewConstraint()
    {
        Console.WriteLine("\n=== where T : class, new() (factory / pool) ===");

        var errors = CreateMany<ApiError>(3);
        Console.WriteLine($"Created {errors.Count} ApiError instances, codes: {string.Join(", ", errors.Select(e => e.Code))}");

        var users = CreateMany<MutableUserDto>(2);
        Console.WriteLine($"Created {users.Count} MutableUserDto instances");
    }

    private static void InterfaceConstraint()
    {
        Console.WriteLine("\n=== where T : IHasId ===");

        Console.WriteLine(FormatId(new UserDto("u1", "Ann")));
        Console.WriteLine(FormatId(new ProductDto("p99", "Mug")));
    }

    private static void CombinedConstraints()
    {
        Console.WriteLine("\n=== Combined: where T : class, IHasId, new() ===");

        var clone = CloneDefault<AuditedEntity>();
        Console.WriteLine($"CloneDefault Id={clone.Id}, Name={clone.Name}");
    }

    // ── Helpers & types ─────────────────────────────────────────────────────

    private static T? NullSafe<T>(T? value) where T : class => value;

    public static T Max<T>(T a, T b) where T : struct, IComparable<T> =>
        a.CompareTo(b) >= 0 ? a : b;

    public static List<T> CreateMany<T>(int count) where T : class, new() =>
        Enumerable.Range(0, count).Select(_ => new T()).ToList();

    public static string FormatId<T>(T dto) where T : IHasId =>
        $"{typeof(T).Name} id={dto.Id}";

    public static T CloneDefault<T>() where T : class, IHasId, new() => new();

    public interface IHasId { string Id { get; } }

    public sealed record UserDto(string Id, string Name) : IHasId;
    public sealed record ProductDto(string Id, string Title) : IHasId;

    public sealed class ApiError { public int Code { get; set; } = 0; }
    public sealed class MutableUserDto { public string Name { get; set; } = ""; }

    public sealed class AuditedEntity : IHasId
    {
        public string Id { get; set; } = "new";
        public string Name { get; set; } = "default";
    }
}
