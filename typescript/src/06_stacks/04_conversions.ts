/** Converting stacks to/from other types in TypeScript. */

console.log("=== Stack → reversed array (top first) ===");
const stack = [1, 2, 3];
const reversed = [...stack].reverse();
console.log("[...stack].reverse()  ->", reversed);

console.log("\n=== Reverse sequence using stack ===");
const original = [1, 2, 3, 4, 5];
const temp = [...original];
const result: number[] = [];
while (temp.length > 0) result.push(temp.pop()!);
console.log("Original:              ", original);
console.log("Reversed via stack:    ", result);

console.log("\n=== Stack → snapshot array ===");
const snapshot = [...stack];
console.log("snapshot (copy):       ", snapshot);
