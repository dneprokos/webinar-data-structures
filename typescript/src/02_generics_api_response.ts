/** Generic API response shape — same idea as C# RestResponse<T>. */

export type RestResponse<T> = {
  status: number;
  body: T;
};

type UserDto = { id: string; name: string };

const users: RestResponse<UserDto[]> = {
  status: 200,
  body: [
    { id: "ann", name: "Ann" },
    { id: "bob", name: "Bob" },
  ],
};

console.log(`${users.status}: ${users.body.length} users`);
