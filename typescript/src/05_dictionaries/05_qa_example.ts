/** Practical QA automation examples using TypeScript Maps and Records. */

const SqlOperator = { Equals: "Equals", Like: "Like", In: "In", GreaterThan: "GreaterThan" } as const;
type SqlOperator = (typeof SqlOperator)[keyof typeof SqlOperator];

const sqlByOp: Record<SqlOperator, string> = {
  [SqlOperator.Equals]: "=",
  [SqlOperator.Like]: "LIKE",
  [SqlOperator.In]: "IN",
  [SqlOperator.GreaterThan]: ">",
};

function buildPredicate(column: string, op: SqlOperator, value: string): string {
  return `${column} ${sqlByOp[op]} ${value}`;
}

console.log("=== SQL operator map ===");
[
  buildPredicate("email", SqlOperator.Like, "%@test.com"),
  buildPredicate("status", SqlOperator.Equals, "'active'"),
  buildPredicate("age", SqlOperator.GreaterThan, "18"),
].forEach((p) => console.log(`  WHERE ${p}`));

console.log("\n=== Config-driven test parameters ===");
const testConfig: Record<string, string> = {
  BASE_URL: "https://staging.example.com",
  API_KEY: "test-key-abc123",
  TIMEOUT_SEC: "30",
  RETRY_COUNT: "3",
};
Object.entries(testConfig).sort().forEach(([k, v]) => console.log(`  ${k.padEnd(15)} = ${v}`));
const timeout = parseInt(testConfig["TIMEOUT_SEC"] ?? "10", 10);
console.log(`Parsed timeout: ${timeout}s`);

console.log("\n=== Aggregate test results ===");
const results: [string, string][] = [
  ["Login test", "pass"], ["Checkout test", "fail"],
  ["Search test", "pass"], ["Profile test", "fail"],
  ["API auth test", "pass"], ["API data test", "pass"],
];
const byStatus = results.reduce<Record<string, number>>((acc, [, s]) => {
  acc[s] = (acc[s] ?? 0) + 1; return acc;
}, {});
Object.entries(byStatus).sort().forEach(([s, c]) => console.log(`  ${s.padEnd(6)} = ${c}`));
const passRate = Math.round(((byStatus["pass"] ?? 0) / results.length) * 100);
console.log(`Pass rate: ${passRate}%`);
