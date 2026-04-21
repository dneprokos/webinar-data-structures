/** Creating stacks in TypeScript using arrays (push/pop). */

console.log("=== Empty stack ===");
const empty: number[] = [];
console.log("[]                     -> length", empty.length);

console.log("\n=== Build by pushing ===");
const stack: number[] = [];
for (const v of [101, 102, 103]) stack.push(v);
console.log("after push 101,102,103 -> top =", stack[stack.length - 1], "  length =", stack.length);

console.log("\n=== Stack from array (copy) ===");
const s2 = [...["a", "b", "c"]];
console.log("[...['a','b','c']]     -> top =", s2[s2.length - 1]);
