/** Enqueue (push), dequeue (shift), and FIFO demonstration. */

console.log("=== Enqueue (push), Dequeue (shift) ===");
const q: string[] = [];
q.push("a", "b", "c");
console.log("after push a,b,c   -> front =", q[0], "  length =", q.length);
const first = q.shift();
console.log("shift()             =", first, "  length =", q.length);

console.log("\n=== Clear ===");
q.length = 0;
console.log("length = 0         ->", q);

console.log("\n=== FIFO demonstration ===");
const fifo = ["first", "second", "third"];
process.stdout.write("Dequeue order (FIFO): ");
while (fifo.length > 0) process.stdout.write(fifo.shift()! + " ");
console.log();
