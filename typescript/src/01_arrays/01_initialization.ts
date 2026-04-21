/** All the ways to create arrays in TypeScript/JavaScript. */

function run(): void {
  emptyAndPreFilled();
  arrayWithValues();
  arrayFromCollection();
}

function emptyAndPreFilled(): void {
  console.log("=== Empty / pre-filled array ===");

  const empty: number[] = [];
  console.log("[]                    -> length", empty.length);

  const zeros = new Array(4).fill(0);
  console.log("new Array(4).fill(0)  ->", zeros);

  const ones = Array.from({ length: 5 }, () => 1);
  console.log("Array.from({length:5})->", ones);
}

function arrayWithValues(): void {
  console.log("\n=== Array with initial values ===");

  const scores = [10, 20, 30];
  console.log("[10, 20, 30]          ->", scores);

  const tags = ["smoke", "api"];
  tags.push("regression");
  console.log("after push            ->", tags);

  // Array.from with mapping — like Enumerable.Range + Select.
  const squares = Array.from({ length: 5 }, (_, i) => (i + 1) ** 2);
  console.log("squares 1..5          ->", squares);
}

function arrayFromCollection(): void {
  console.log("\n=== Array from another iterable ===");

  const fromSet = Array.from(new Set([1, 2, 2, 3]));
  console.log("Array.from(Set)       ->", fromSet, "(deduped)");

  const fromMap = Array.from(new Map([["a", 1], ["b", 2]]).values());
  console.log("Array.from(Map values)->", fromMap);

  // Spread operator.
  const original = [1, 2, 3];
  const copy = [...original];
  console.log("[...original]         ->", copy, "(shallow copy)");

  // Filter during creation.
  const evens = Array.from({ length: 10 }, (_, i) => i).filter((x) => x % 2 === 0);
  console.log("evens 0..9            ->", evens);
}

run();
