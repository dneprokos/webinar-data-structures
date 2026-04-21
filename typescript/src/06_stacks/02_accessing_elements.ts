/** Reading from a TypeScript array-based stack. */

const stack = ["first", "second", "third"];

console.log("=== Peek (read top without removing) ===");
console.log("stack.at(-1)           =", stack.at(-1));
console.log("stack[stack.length-1]  =", stack[stack.length - 1]);
console.log("length after peek      =", stack.length, " (unchanged)");

console.log("\n=== Contains ===");
console.log('"second" in stack      =', stack.includes("second"));
console.log('"missing" in stack     =', stack.includes("missing"));

console.log("\n=== Iteration (top → bottom) ===");
[...stack].reverse().forEach((item) => console.log(" ", item));

console.log("\n=== No dedicated indexer ===");
console.log("(Array supports stack.at(-1) for peek; use only push/pop for stack semantics)");
