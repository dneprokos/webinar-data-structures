using System.Net;

namespace DataStructuresQA.Examples;

/// <summary>Generic wrapper for API responses (see Medium: RestResponse&lt;T&gt;).</summary>
internal static class GenericsApiExample
{
    public static void Run()
    {
        var users = new RestResponse<List<UserDto>>(
            HttpStatusCode.OK,
            new List<UserDto> { new("ann", "Ann"), new("bob", "Bob") });

        Console.WriteLine($"{users.StatusCode}: {users.Body.Count} users");
    }

    public sealed record RestResponse<T>(HttpStatusCode StatusCode, T Body);

    public sealed record UserDto(string Id, string Name);
}
