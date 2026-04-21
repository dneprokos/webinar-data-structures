/** Tuple operations: equality, sorting, and tuples in collections. */

console.log("=== Equality (structural comparison via JSON) ===");
const a: [number, string] = [1, "hello"];
const b: [number, string] = [1, "hello"];
console.log("a deep equal b:", JSON.stringify(a) === JSON.stringify(b));

console.log("\n=== Sorting list of tuples ===");
const scores: [string, number][] = [["Bob", 85], ["Ann", 92], ["Ann", 78]];
const sorted = [...scores].sort(([n1, s1], [n2, s2]) => n1 !== n2 ? n1.localeCompare(n2) : s2 - s1);
sorted.forEach(([name, score]) => console.log(`  ${name}: ${score}`));

console.log("\n=== Tuples in Map values ===");
const config = new Map<string, [string, boolean]>([
  ["db_host", ["localhost", false]],
  ["db_pass", ["s3cr3t", true]],
]);
for (const [key, [value, isSecret]] of config) {
  console.log(`  ${key} = ${isSecret ? "***" : value}`);
}
