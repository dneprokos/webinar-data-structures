/**
 * Generic API response wrapper used in QA automation frameworks.
 * A single typed envelope works for any API endpoint — no casting needed.
 */

// ── Generic response envelope ─────────────────────────────────────────────────

type ApiResponse<TBody extends object> = {
  status: number;
  body: TBody;
  isOk: boolean;
};

function makeResponse<TBody extends object>(status: number, body: TBody): ApiResponse<TBody> {
  return { status, body, isOk: status >= 200 && status < 300 };
}

// ── Domain types ──────────────────────────────────────────────────────────────

type UserDto = { id: string; name: string; role: string };
type OrderDto = { id: string; total: number };

// ── Generic assertion helpers ─────────────────────────────────────────────────

function assertStatus<T extends object>(response: ApiResponse<T>, expected: number): void {
  if (response.status !== expected) {
    throw new Error(`Expected ${expected} but got ${response.status}`);
  }
}

function assertNotEmpty<T>(collection: T[], name = "collection"): void {
  if (collection.length === 0) {
    throw new Error(`${name} must not be empty`);
  }
}

function findFirst<T>(items: T[], predicate: (x: T) => boolean): T | undefined {
  return items.find(predicate);
}

// ── Generic test data factory ─────────────────────────────────────────────────

function createMany<T>(count: number, factory: (index: number) => T): T[] {
  return Array.from({ length: count }, (_, i) => factory(i + 1));
}

// ── Simulate HTTP calls ───────────────────────────────────────────────────────

function apiCall<TBody extends object>(endpoint: string, status: number, body: TBody): ApiResponse<TBody> {
  console.log(`  [HTTP] ${endpoint}`);
  return makeResponse(status, body);
}

// ── Run ───────────────────────────────────────────────────────────────────────

console.log("=== Typed API response wrapper ===");

const usersResp = apiCall<UserDto[]>("/api/users", 200, [
  { id: "u1", name: "Ann", role: "admin" },
  { id: "u2", name: "Bob", role: "viewer" },
]);
const orderResp = apiCall<OrderDto>("/api/orders/1", 200, { id: "o1", total: 199.99 });

console.log(`GET /api/users    -> ${usersResp.status}, ${usersResp.body.length} users`);
console.log(`GET /api/orders/1 -> ${orderResp.status}, order ${orderResp.body.id} = $${orderResp.body.total}`);

assertStatus(usersResp, 200);
assertStatus(orderResp, 200);
console.log("Both status assertions passed");

console.log("\n=== Generic assertion helpers ===");
assertNotEmpty(usersResp.body, "users list");
console.log("assertNotEmpty passed");

const found = findFirst(usersResp.body, (u) => u.role === "viewer");
console.log("findFirst(role=viewer) =", found);

console.log("\n=== Generic test data factory ===");
const testUsers = createMany<UserDto>(3, (i) => ({ id: `u${i}`, name: `User${i}`, role: "viewer" }));
testUsers.forEach((u) => console.log(`  ${u.id}: ${u.name} (${u.role})`));
