/** Creating Set instances in TypeScript. */

console.log("=== Empty set ===");
const empty = new Set<number>();
console.log("new Set<number>()    -> size", empty.size);

console.log("\n=== Set with values ===");
const tags = new Set(["smoke", "api", "regression"]);
console.log("inline values        ->", tags);

console.log("\n=== From array (dedup) ===");
const withDups = [1, 2, 2, 3, 3, 3];
const unique = new Set(withDups);
console.log("new Set([1,2,2,3])   ->", unique, " size", unique.size);

console.log("\n=== Case-insensitive (manual) ===");
const urls = new Set(["https://A.com", "https://a.com"].map((u) => u.toLowerCase()));
console.log("lowercased set       -> size", urls.size, "(treated as duplicate)");
