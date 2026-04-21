/** Collection operations applied to QA automation in TypeScript. */

type TestResult = { id: string; name: string; status: "pass" | "fail"; durationMs: number; category: string };

const RESULTS: TestResult[] = [
  { id: "TC001", name: "login_happy_path",     status: "pass", durationMs: 245, category: "Login" },
  { id: "TC002", name: "login_wrong_password", status: "pass", durationMs: 120, category: "Login" },
  { id: "TC003", name: "checkout_empty_cart",  status: "fail", durationMs: 380, category: "Checkout" },
  { id: "TC004", name: "checkout_valid",       status: "pass", durationMs:  95, category: "Checkout" },
  { id: "TC005", name: "search_no_results",    status: "fail", durationMs: 560, category: "Search" },
  { id: "TC006", name: "search_with_filter",   status: "pass", durationMs: 210, category: "Search" },
  { id: "TC007", name: "profile_update",       status: "fail", durationMs: 430, category: "Profile" },
  { id: "TC008", name: "api_auth",             status: "pass", durationMs: 180, category: "API" },
  { id: "TC009", name: "api_data",             status: "pass", durationMs: 200, category: "API" },
  { id: "TC010", name: "api_rate_limit",       status: "fail", durationMs: 670, category: "API" },
];

console.log("=== Filter failed tests ===");
const failed = RESULTS.filter((r) => r.status === "fail").sort((a, b) => a.category.localeCompare(b.category));
failed.forEach((r) => console.log(`  ✗ [${r.id}] ${r.name.padEnd(30)} (${r.category})`));

console.log("\n=== Pass rate by category ===");
const byCategory = RESULTS.reduce<Record<string, TestResult[]>>((acc, r) => {
  acc[r.category] = [...(acc[r.category] ?? []), r]; return acc;
}, {});
Object.entries(byCategory).sort().forEach(([cat, items]) => {
  const passed = items.filter((r) => r.status === "pass").length;
  const avg = items.reduce((s, r) => s + r.durationMs, 0) / items.length;
  console.log(`  ${cat.padEnd(10)} ${passed}/${items.length} (${Math.round(passed/items.length*100)}%)  avg=${avg.toFixed(0)}ms`);
});
const overall = Math.round(RESULTS.filter((r) => r.status === "pass").length / RESULTS.length * 100);
console.log(`  Overall: ${overall}%`);

console.log("\n=== Paginate results (page size = 3) ===");
const sorted = [...RESULTS].sort((a, b) => a.id.localeCompare(b.id));
const pageSize = 3;
for (let p = 0; p * pageSize < sorted.length; p++) {
  const page = sorted.slice(p * pageSize, (p + 1) * pageSize);
  console.log(`  Page ${p + 1}: [${page.map((r) => r.id).join(", ")}]`);
}

console.log("\n=== Slow tests (>= 400ms) ===");
const slow = RESULTS.filter((r) => r.durationMs >= 400).sort((a, b) => b.durationMs - a.durationMs);
slow.forEach((r) => console.log(`  [${r.id}] ${r.name.padEnd(30)} ${r.durationMs}ms  ${r.status}`));
