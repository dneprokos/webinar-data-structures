/** TypeScript generic constraints — T extends SomeType. */

// ── T extends { id: string } — structural constraint (like C# IHasId) ────────

function formatId<T extends { id: string }>(dto: T, label: string): string {
  return `${label} id=${dto.id}`;
}

type UserDto = { id: string; name: string };
type ProductDto = { id: string; title: string };

// ── T extends number | string — union constraint ──────────────────────────────

function maxComparable<T extends number | string>(a: T, b: T): T {
  if (typeof a === "number" && typeof b === "number") {
    return (a >= b ? a : b) as T;
  }
  return (String(a) >= String(b) ? a : b) as T;
}

// ── T extends { score: number } — compare by field ───────────────────────────

function pickHigher<T extends { score: number }>(a: T, b: T): T {
  return a.score >= b.score ? a : b;
}

// ── Constructor constraint: new () => T  (like C# where T : new()) ────────────

type Constructor<T> = new () => T;

function createMany<T>(Ctor: Constructor<T>, count: number): T[] {
  return Array.from({ length: count }, () => new Ctor());
}

class ApiError {
  code = 0;
}

// ── Keyof constraint — generic property accessor ──────────────────────────────

function getProperty<T, K extends keyof T>(obj: T, key: K): T[K] {
  return obj[key];
}

// ── Run ───────────────────────────────────────────────────────────────────────

console.log("=== T extends { id: string } ===");
console.log(formatId({ id: "u1", name: "Ann" } as UserDto, "UserDto"));
console.log(formatId({ id: "p99", title: "Mug" } as ProductDto, "ProductDto"));

console.log("\n=== T extends number | string ===");
console.log("max(10, 25)    =", maxComparable(10, 25));
console.log('max("b", "a") =', maxComparable("b", "a"));

console.log("\n=== T extends { score: number } ===");
console.log(pickHigher({ score: 80, name: "a" }, { score: 90, name: "b" }));

console.log("\n=== Constructor<T> + new () ===");
const errs = createMany(ApiError, 3);
console.log(`Created ${errs.length} ApiError, codes = ${errs.map((e) => e.code).join(", ")}`);

console.log("\n=== keyof constraint ===");
const user: UserDto = { id: "u1", name: "Ann" };
console.log('getProperty(user, "name") =', getProperty(user, "name"));
console.log('getProperty(user, "id")   =', getProperty(user, "id"));
