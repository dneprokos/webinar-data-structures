/** Converting tuples to/from other types in TypeScript. */

console.log("=== Tuple → object ===");
const tuple: [string, string, string] = ["u1", "Ann", "admin"];
const [id, name, role] = tuple;
const user = { id, name, role };
console.log("destructure to object ->", user);

console.log("\n=== Array of tuples → Map ===");
const entries: [string, number][] = [["a", 1], ["b", 2], ["c", 3]];
const map = new Map(entries);
console.log("new Map(entries) ->", map);

console.log("\n=== Map entries → array of tuples ===");
const env = new Map([["BASE_URL", "https://api.example.com"], ["TIMEOUT", "30"]]);
const pairs = Array.from(env.entries());
console.log("Map.entries() ->", pairs);

console.log("\n=== zip two arrays → array of tuples ===");
const keys = ["name", "role"];
const values = ["Ann", "admin"];
const zipped = keys.map((k, i) => [k, values[i]] as [string, string]);
console.log("zipped ->", zipped);
