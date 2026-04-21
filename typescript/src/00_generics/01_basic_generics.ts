/** Generic classes and functions in TypeScript — type parameters, reuse, safety. */

// ── Generic type alias ───────────────────────────────────────────────────────

type RestResponse<TBody extends object> = {
  status: number;
  body: TBody;
};

type UserDto = { id: string; name: string };
type OrderDto = { id: string; total: number };

// ── Generic function ─────────────────────────────────────────────────────────

function swap<T>(a: T, b: T): [T, T] {
  return [b, a];
}

function firstOrDefault<T>(items: T[], defaultValue: T): T {
  return items.length > 0 ? items[0] : defaultValue;
}

function identity<T>(value: T): T {
  return value;
}

// ── Generic class ─────────────────────────────────────────────────────────────

class Repository<T extends { id: string }> {
  private items: T[] = [];

  add(item: T): void {
    this.items.push(item);
  }

  findById(id: string): T | undefined {
    return this.items.find((x) => x.id === id);
  }

  get count(): number {
    return this.items.length;
  }
}

// ── Run ───────────────────────────────────────────────────────────────────────

console.log("=== Generic type: RestResponse<TBody> ===");

const usersResp: RestResponse<UserDto[]> = {
  status: 200,
  body: [{ id: "ann", name: "Ann" }, { id: "bob", name: "Bob" }],
};
console.log(`Status: ${usersResp.status}`);
console.log(`Body:   ${usersResp.body.length} users`);

const errorResp: RestResponse<{ message: string }> = {
  status: 400,
  body: { message: "Not found" },
};
console.log(`Error:  ${errorResp.status} — ${errorResp.body.message}`);

console.log("\n=== Generic function: swap ===");
const [a, b] = swap(1, 2);
console.log(`swap(1, 2) -> a=${a}, b=${b}`);

const [x, y] = swap("hello", "world");
console.log(`swap(str)  -> x=${x}, y=${y}`);

console.log("\n=== Generic function: firstOrDefault ===");
console.log("first([1,2,3], 0) =", firstOrDefault([1, 2, 3], 0));
console.log("first([], 99)     =", firstOrDefault([], 99));

console.log("\n=== Generic class: Repository<T> ===");
const repo = new Repository<UserDto>();
repo.add({ id: "u1", name: "Ann" });
repo.add({ id: "u2", name: "Bob" });
console.log(`Count: ${repo.count}`);
console.log(`findById("u1"):`, repo.findById("u1"));
