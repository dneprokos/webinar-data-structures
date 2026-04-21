/** Practical QA automation examples using TypeScript arrays as lists. */

type OrderRow = { code: string; amount: number };
type TestResult = { name: string; status: "pass" | "fail" };

console.log("=== Validate API response row count ===");
const apiRecords: OrderRow[] = [
  { code: "A", amount: 10 },
  { code: "B", amount: 20 },
  { code: "C", amount: 30 },
];
console.log(`Count == 0?  ${apiRecords.length === 0}`);
console.log(`Count >= 3?  ${apiRecords.length >= 3}`);
console.log(`Any >= 25?   ${apiRecords.some((r) => r.amount >= 25)}`);
const found = apiRecords.find((r) => r.code === "B");
console.log(`Find code B: ${JSON.stringify(found)}`);
const allUnique = apiRecords.length === new Set(apiRecords.map((r) => r.code)).size;
console.log(`All codes unique: ${allUnique}`);

console.log("\n=== Collect and analyze test results ===");
const results: TestResult[] = [
  { name: "Login happy path", status: "pass" },
  { name: "Login wrong password", status: "pass" },
  { name: "Checkout empty cart", status: "fail" },
  { name: "Search no results", status: "pass" },
  { name: "Profile update", status: "fail" },
];
const passed = results.filter((r) => r.status === "pass");
const failed = results.filter((r) => r.status === "fail");
console.log(`Total: ${results.length}  Passed: ${passed.length}  Failed: ${failed.length}`);
console.log("Failed tests:");
failed.forEach((r) => console.log(`  ✗ ${r.name}`));
console.log(`Pass rate: ${Math.round((passed.length / results.length) * 100)}%`);

console.log("\n=== Build dynamic test case list ===");
const features = ["login", "checkout", "profile"];
const envs = ["staging"];
const testCases = features.flatMap((f) => envs.map((e) => `${f}@${e}`));
console.log(`Generated ${testCases.length} test cases:`);
testCases.forEach((tc) => console.log(`  ${tc}`));
