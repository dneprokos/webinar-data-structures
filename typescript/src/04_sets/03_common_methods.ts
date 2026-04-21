/** Set operations in TypeScript: union, intersection, difference. */

console.log("=== Add & Delete ===");
const s = new Set([1, 2, 3]);
s.add(4);
console.log("add(4)           ->", s);
s.add(2);
console.log("add(2) duplicate ->", s, "(no change)");
s.delete(1);
console.log("delete(1)        ->", s);

console.log("\n=== Set operations (manual — no built-ins until ES2025) ===");
const a = new Set([1, 2, 3, 4]);
const b = new Set([3, 4, 5, 6]);

const union = new Set([...a, ...b]);
console.log("union             ->", [...union].sort((x, y) => x - y));

const intersection = new Set([...a].filter((x) => b.has(x)));
console.log("intersection      ->", [...intersection].sort((x, y) => x - y));

const diff = new Set([...a].filter((x) => !b.has(x)));
console.log("difference a-b    ->", [...diff].sort((x, y) => x - y));

const symDiff = new Set([...[...a].filter((x) => !b.has(x)), ...[...b].filter((x) => !a.has(x))]);
console.log("symmetric diff    ->", [...symDiff].sort((x, y) => x - y));

console.log("\n=== Subset check ===");
const full = new Set(["fail", "pass", "skip", "warn"]);
const sub = new Set(["fail", "pass"]);
const isSubset = [...sub].every((x) => full.has(x));
console.log("sub is subset of full =", isSubset);
