/** Reading elements by index, iterating, and searching arrays in TypeScript. */

function run(): void {
  indexAccess();
  iteration();
  searching();
}

function indexAccess(): void {
  console.log("=== Index access (zero-based) ===");

  const letters = ["a", "b", "c", "d"];

  console.log("letters[0]             =", letters[0], " (first)");
  console.log("letters[2]             =", letters[2]);
  console.log("letters[letters.length-1]=", letters[letters.length - 1], "(last)");
  console.log("letters.at(-1)         =", letters.at(-1), " (last — ES2022)");
  console.log("letters.at(-2)         =", letters.at(-2), " (second-to-last)");

  // Slice — returns a new array, does not mutate.
  const middle = letters.slice(1, 3); // indices 1 and 2
  console.log("letters.slice(1,3)     =", middle);

  // Modify by index.
  const nums = [10, 20, 30];
  nums[1] = 99;
  console.log("After nums[1]=99       =", nums);
}

function iteration(): void {
  console.log("\n=== Iterating ===");

  const scores = [55, 92, 81];

  // for...of — most common.
  process.stdout.write("for...of:              ");
  for (const s of scores) process.stdout.write(`${s} `);
  console.log();

  // forEach — with index.
  process.stdout.write("forEach with index:    ");
  scores.forEach((s, i) => process.stdout.write(`[${i}]=${s} `));
  console.log();

  // for loop with index.
  process.stdout.write("classic for:           ");
  for (let i = 0; i < scores.length; i++) process.stdout.write(`${scores[i]} `);
  console.log();
}

function searching(): void {
  console.log("\n=== Searching ===");

  const fruits = ["apple", "banana", "cherry", "banana"];

  console.log('"banana" in array     =', fruits.includes("banana"));
  console.log("indexOf('banana')     =", fruits.indexOf("banana"), " (first)");
  console.log("lastIndexOf('banana') =", fruits.lastIndexOf("banana"), "(last)");

  const firstC = fruits.find((f) => f.startsWith("c"));
  console.log("find(starts 'c')      =", firstC);

  console.log("some(len > 5)         =", fruits.some((f) => f.length > 5));
  console.log("every(len > 3)        =", fruits.every((f) => f.length > 3));
}

run();
