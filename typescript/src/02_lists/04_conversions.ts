/** Converting arrays to/from other collection types in TypeScript. */

console.log("=== Array → Set (dedup) ===");
const withDups = [1, 2, 2, 3, 3, 3];
const unique = [...new Set(withDups)].sort((a, b) => a - b);
console.log("[...new Set(...)].sort ->", unique);

console.log("\n=== Array → Map ===");
const employees = [{ id: "e1", name: "Ann" }, { id: "e2", name: "Bob" }];
const byId = new Map(employees.map((e) => [e.id, e.name]));
console.log("Map from array         ->", byId);
console.log('byId.get("e1")         ->', byId.get("e1"));

console.log("\n=== Array → plain object ===");
const pairs: [string, number][] = [["a", 1], ["b", 2]];
const obj = Object.fromEntries(pairs);
console.log("Object.fromEntries     ->", obj);

console.log("\n=== Array → string ===");
const words = ["Hello", "World"];
console.log("join(' ')              ->", words.join(" "));
const ids = [2, 5, 7];
console.log("query string           ->", `?ids=${ids.join(",")}`);
