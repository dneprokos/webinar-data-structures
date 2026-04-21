/** Reading, iterating, and searching arrays in TypeScript. */

console.log("=== Index access ===");
const items = ["apple", "banana", "cherry"];
console.log("items[0]         =", items[0]);
console.log("items.at(-1)     =", items.at(-1), "(last)");
console.log("items.length     =", items.length);

items[1] = "blueberry";
console.log("items[1]='blueberry':", items);

console.log("\n=== Iterating ===");
const scores = [55, 92, 81];
process.stdout.write("for...of:        ");
for (const s of scores) process.stdout.write(`${s} `);
console.log();

scores.forEach((s, i) => process.stdout.write(`[${i}]=${s} `));
console.log(" <- forEach");

console.log("\n=== Searching ===");
const fruits = ["apple", "banana", "cherry"];
console.log('"banana" in array =', fruits.includes("banana"));
console.log("indexOf('banana') =", fruits.indexOf("banana"));
console.log("find(starts 'c')  =", fruits.find((f) => f.startsWith("c")));
console.log("some(len > 5)     =", fruits.some((f) => f.length > 5));
console.log("every(len > 3)    =", fruits.every((f) => f.length > 3));
