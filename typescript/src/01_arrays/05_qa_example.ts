/**
 * Practical QA automation examples using TypeScript arrays.
 *
 * Scenarios:
 * - Build URL query strings from parameter arrays
 * - Parse CSV test data into typed records
 * - Validate API response has no duplicate IDs
 * - Generate parameterized test inputs
 */

type TestUser = { email: string; role: string; status: string };
type TestCase = { environment: string; role: string };

export function buildQueryString(ids: readonly number[]): string {
  return `?ids=${ids.join(",")}`;
}

export function sumDigitCharacters(text: string): number {
  return Array.from(text)
    .filter((ch) => ch >= "0" && ch <= "9")
    .reduce((sum, ch) => sum + parseInt(ch, 10), 0);
}

function parseCsvTestData(csvLines: string[]): TestUser[] {
  return csvLines.map((line) => {
    const [email, role, status] = line.split(",");
    return { email, role, status };
  });
}

function hasDuplicateIds(ids: string[]): boolean {
  return ids.length !== new Set(ids).size;
}

function findDuplicatedIds(ids: string[]): string[] {
  const seen = new Set<string>();
  const duplicates: string[] = [];
  for (const id of ids) {
    if (seen.has(id) && !duplicates.includes(id)) duplicates.push(id);
    seen.add(id);
  }
  return duplicates;
}

function generateTestCombinations(environments: string[], roles: string[]): TestCase[] {
  return environments.flatMap((env) => roles.map((role) => ({ environment: env, role })));
}

// ── Run ──────────────────────────────────────────────────────────────────────

console.log("=== Build URL query string ===");
const ids = [2, 5, 7, 12];
console.log(`IDs: ${ids}`);
console.log(`URL: https://api.example.com/users${buildQueryString(ids)}`);

console.log("\n=== Sum digit characters ===");
console.log(`sumDigitCharacters("a1b2c3") = ${sumDigitCharacters("a1b2c3")}`);

console.log("\n=== Parse CSV test data ===");
const csvLines = [
  "alice@test.com,admin,active",
  "bob@test.com,viewer,inactive",
  "charlie@test.com,editor,active",
];
const users = parseCsvTestData(csvLines);
console.log(`Parsed ${users.length} users:`);
users.forEach((u) => console.log(`  ${u.email.padEnd(25)} role=${u.role.padEnd(8)} status=${u.status}`));

console.log("\n=== Validate no duplicate IDs ===");
const responseIds = ["u1", "u2", "u3", "u4"];
console.log(`Has duplicates: ${hasDuplicateIds(responseIds)}`);
console.log(hasDuplicateIds(responseIds) ? "FAIL" : "PASS: all IDs are unique");

const idsWithDup = ["u1", "u2", "u2", "u3"];
console.log(`Duplicated IDs: ${findDuplicatedIds(idsWithDup)}`);

console.log("\n=== Generate parameterized test combinations ===");
const testCases = generateTestCombinations(["staging", "production"], ["admin", "viewer"]);
console.log(`Generated ${testCases.length} combinations:`);
testCases.forEach((tc) => console.log(`  env=${tc.environment.padEnd(12)} role=${tc.role}`));
