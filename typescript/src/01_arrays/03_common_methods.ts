/** Add, remove, sort, filter, and map operations on TypeScript arrays. */

function run(): void {
  addingAndRemoving();
  sorting();
  filtering();
  projection();
}

function addingAndRemoving(): void {
  console.log("=== Adding & Removing ===");

  const items = ["a", "b", "c", "b"];

  items.push("d");
  console.log('push("d")              ->', items);

  items.splice(1, 0, "X"); // insert at index 1, delete 0, add "X"
  console.log('splice(1,0,"X")        ->', items);

  // Remove first occurrence of "b".
  const i = items.indexOf("b");
  if (i !== -1) items.splice(i, 1);
  console.log('remove first "b"       ->', items);

  // Remove all "b" — immutable (creates new array).
  const noB = items.filter((x) => x !== "b");
  console.log('filter !== "b"         ->', noB);

  // Clear.
  items.length = 0;
  console.log("items.length = 0       ->", items);
}

function sorting(): void {
  console.log("\n=== Sorting ===");

  const values = [3, 1, 4, 1, 5];

  // ALWAYS spread before sort — sort() mutates in-place.
  const asc = [...values].sort((a, b) => a - b);
  console.log("sorted asc (copy)      ->", asc, " original:", values);

  const desc = [...values].sort((a, b) => b - a);
  console.log("sorted desc (copy)     ->", desc);

  const names = ["zebra", "apple", "Mango"];
  const sortedNames = [...names].sort((a, b) => a.localeCompare(b, undefined, { sensitivity: "base" }));
  console.log("sorted names (locale)  ->", sortedNames);
}

function filtering(): void {
  console.log("\n=== Filtering ===");

  const scores = [55, 92, 81, 40, 88];

  console.log("filter(>= 80):         ", scores.filter((s) => s >= 80));
  console.log("filter(50 < s < 90):   ", scores.filter((s) => s > 50 && s < 90));

  const words = ["a", "", "bb", "ccc"];
  console.log("filter non-empty:      ", words.filter((w) => w.length > 0));
}

function projection(): void {
  console.log("\n=== Projection / Map ===");

  const scores = [55, 92, 81, 40, 88];

  console.log("map(s => s*2):         ", scores.map((s) => s * 2));
  console.log("map(to string):        ", scores.map((s) => `s=${s}`));

  const employees = [
    { name: "Ann", title: "SDET" },
    { name: "Bob", title: "QA" },
  ];
  console.log("map to names:          ", employees.map((e) => e.name));

  // flatMap — map then flatten one level.
  const nested = [[1, 2], [3, 4]];
  console.log("flatMap(x => x):       ", nested.flatMap((x) => x));
}

run();
