using System.Net;

namespace DataStructuresQA.Generics;

/// <summary>Generic classes and methods — the basics: type parameters, typed containers, reuse.</summary>
internal static class BasicGenerics
{
    public static void Run()
    {
        GenericClass();
        GenericMethod();
        GenericInterface();
    }

    private static void GenericClass()
    {
        Console.WriteLine("=== Generic class: RestResponse<TBody> ===");

        // TBody is resolved at compile time — full IntelliSense and type safety.
        var usersResponse = new RestResponse<List<UserDto>>(
            HttpStatusCode.OK,
            [new("ann", "Ann"), new("bob", "Bob")]);

        Console.WriteLine($"Status: {usersResponse.StatusCode}");
        Console.WriteLine($"Body:   {usersResponse.Body.Count} users");

        // A completely different body type — same class, different T.
        var errorResponse = new RestResponse<string>(HttpStatusCode.BadRequest, "Not found");
        Console.WriteLine($"Error:  {errorResponse.StatusCode} — {errorResponse.Body}");
    }

    private static void GenericMethod()
    {
        Console.WriteLine("\n=== Generic method: Swap<T> ===");

        int a = 1, b = 2;
        Swap(ref a, ref b);
        Console.WriteLine($"After Swap: a={a}, b={b}");

        string x = "hello", y = "world";
        Swap(ref x, ref y);
        Console.WriteLine($"After Swap: x={x}, y={y}");
    }

    private static void GenericInterface()
    {
        Console.WriteLine("\n=== Generic interface: IRepository<T> ===");

        var repo = new InMemoryRepository<UserDto>();
        repo.Add(new UserDto("u1", "Ann"));
        repo.Add(new UserDto("u2", "Bob"));

        Console.WriteLine($"Count: {repo.Count}");
        var found = repo.FindById("u1");
        Console.WriteLine($"FindById(u1): {found?.Name}");
    }

    // ── Types ────────────────────────────────────────────────────────────────

    public sealed record RestResponse<TBody>(HttpStatusCode StatusCode, TBody Body);

    public record UserDto(string Id, string Name);

    private static void Swap<T>(ref T a, ref T b) => (a, b) = (b, a);

    public interface IRepository<T>
    {
        void Add(T item);
        int Count { get; }
    }

    public sealed class InMemoryRepository<T> : IRepository<T> where T : UserDto
    {
        private readonly List<T> _items = new();

        public void Add(T item) => _items.Add(item);
        public int Count => _items.Count;
        public T? FindById(string id) => _items.FirstOrDefault(x => x.Id == id);
    }
}
