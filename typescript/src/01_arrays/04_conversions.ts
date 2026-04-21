/** Converting arrays to/from other collection types in TypeScript. */

function run(): void {
  arrayToSet();
  arrayToMap();
  arrayToObject();
  arrayToString();
  stringToArray();
}

function arrayToSet(): void {
  console.log("=== Array → Set (dedup) ===");

  const withDups = [1, 2, 2, 3, 3, 3];
  const unique = new Set(withDups);
  console.log("new Set([1,2,2,3])     ->", unique);

  // Back to sorted array.
  const back = [...unique].sort((a, b) => a - b);
  console.log("back to sorted array   ->", back);
}

function arrayToMap(): void {
  console.log("\n=== Array → Map ===");

  const employees = [
    { id: "e1", name: "Ann" },
    { id: "e2", name: "Bob" },
  ];

  const byId = new Map(employees.map((e) => [e.id, e.name]));
  console.log("Map from array         ->", byId);
  console.log('byId.get("e1")         ->', byId.get("e1"));
}

function arrayToObject(): void {
  console.log("\n=== Array → plain object (Record) ===");

  const pairs: [string, number][] = [["a", 1], ["b", 2], ["c", 3]];
  const obj = Object.fromEntries(pairs);
  console.log("Object.fromEntries     ->", obj);

  // Array of objects → lookup object by key.
  const users = [{ id: "u1", name: "Ann" }, { id: "u2", name: "Bob" }];
  const lookup = Object.fromEntries(users.map((u) => [u.id, u.name]));
  console.log("lookup by id           ->", lookup);
}

function arrayToString(): void {
  console.log("\n=== Array → string ===");

  const ids = [2, 5, 7];
  console.log("join(',')              ->", ids.join(","));
  console.log("query string           ->", `?ids=${ids.join(",")}`);

  const words = ["Hello", "World"];
  console.log("join(' ')              ->", words.join(" "));
}

function stringToArray(): void {
  console.log("\n=== String → Array ===");

  const csv = "alice,bob,charlie";
  const parts = csv.split(",");
  console.log("split(',')             ->", parts);

  const chars = Array.from("hello");
  console.log("Array.from('hello')    ->", chars);
}

run();
