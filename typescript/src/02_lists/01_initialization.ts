/** All the ways to create arrays (lists) in TypeScript. */

console.log("=== Empty list ===");
const empty: number[] = [];
console.log("[]                  -> length", empty.length);

console.log("\n=== List with values ===");
const tags = ["smoke", "api", "regression"];
console.log("inline literal      ->", tags);

const scores = Array.from({ length: 4 }, (_, i) => (i + 1) * 10);
console.log("Array.from(range)   ->", scores);

console.log("\n=== From existing collection ===");
const fromSet = Array.from(new Set([1, 2, 2, 3]));
console.log("Array.from(Set)     ->", fromSet, "(deduped)");

const evens = Array.from({ length: 5 }, (_, i) => i * 2);
console.log("evens 0..8          ->", evens);
