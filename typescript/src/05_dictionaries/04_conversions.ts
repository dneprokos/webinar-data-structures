/** Converting Maps/Records to/from other types in TypeScript. */

console.log("=== Array of pairs → Map ===");
const pairs: [string, number][] = [["a", 1], ["b", 2]];
const map = new Map(pairs);
console.log("new Map(pairs)    ->", map);

console.log("\n=== Map → plain object ===");
const obj = Object.fromEntries(map);
console.log("Object.fromEntries->", obj);

console.log("\n=== Object → Map ===");
const record = { x: 10, y: 20 };
const fromObj = new Map(Object.entries(record));
console.log("new Map(entries)  ->", fromObj);

console.log("\n=== GroupBy → Map of arrays ===");
const results: [string, string][] = [["Ann","pass"],["Bob","fail"],["Carl","pass"],["Dan","fail"]];
const byStatus = results.reduce((m, [name, status]) => {
  m.set(status, [...(m.get(status) ?? []), name]);
  return m;
}, new Map<string, string[]>());
for (const [status, names] of [...byStatus].sort()) {
  console.log(`  ${status}: [${names}]`);
}
