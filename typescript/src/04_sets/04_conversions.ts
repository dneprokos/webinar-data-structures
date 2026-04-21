/** Converting Sets to/from other types in TypeScript. */

console.log("=== Array → Set (dedup) ===");
const withDups = [1, 2, 2, 3, 3, 3];
const unique = new Set(withDups);
console.log("new Set([1,2,2,3]) ->", unique, " size", unique.size);

console.log("\n=== Set → sorted array ===");
const roles = new Set(["viewer", "admin", "editor"]);
console.log("[...roles].sort()  ->", [...roles].sort());

console.log("\n=== Deduplicate array ===");
const lst = ["a", "b", "a", "c", "b"];
const deduped = [...new Set(lst)];
console.log("[...new Set(lst)]  ->", deduped);

console.log("\n=== Set → Map (with count) ===");
const tags = ["smoke", "api", "smoke", "regression", "smoke"];
const freq = tags.reduce((map, tag) => map.set(tag, (map.get(tag) ?? 0) + 1), new Map<string, number>());
console.log("frequency map      ->", freq);
