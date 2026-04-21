/** Reading from a TypeScript array-based queue. */

const q = ["first", "second", "third"];

console.log("=== Peek front without removing ===");
console.log("q[0]               =", q[0]);
console.log("length after peek  =", q.length, " (unchanged)");

console.log("\n=== Contains ===");
console.log('"second" in queue  =', q.includes("second"));
console.log('"missing" in queue =', q.includes("missing"));

console.log("\n=== Iteration (front → back) ===");
q.forEach((item) => console.log(" ", item));
