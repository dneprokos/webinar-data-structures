/** Creating queues in TypeScript using arrays (push/shift). */

console.log("=== Empty queue ===");
const empty: string[] = [];
console.log("[]                     -> length", empty.length);

console.log("\n=== Build by enqueueing ===");
const q: string[] = [];
q.push("sync-users", "purge-cache", "notify-slack");
console.log("after push 3 items     -> front =", q[0], "  length =", q.length);

console.log("\n=== Queue from array ===");
const fromArr = ["a", "b", "c"];
console.log("['a','b','c']          -> front =", fromArr[0]);

console.log("\nNote: For high-throughput queues, shift() is O(n).");
console.log("Consider a linked-list or deque library for performance-critical code.");
