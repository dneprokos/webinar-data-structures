/** Queue using js-sdsl's generic Queue<T> (O(1) amortized push and pop). */
import { Queue } from 'js-sdsl';

console.log("=== Empty Queue ===");
const empty = new Queue<string>();
console.log("new Queue<string>()    -> length", empty.length);

console.log("\n=== Build by enqueueing ===");
const q = new Queue<string>();
q.push("sync-users"); q.push("purge-cache"); q.push("notify-slack");
console.log("after push 3 tasks     -> front =", q.front(), "  length =", q.length);

console.log("\n=== Dequeue all (FIFO order) ===");
const tmp = new Queue<string>(["sync-users", "purge-cache", "notify-slack"]);
while (tmp.length > 0) console.log("  pop() ->", tmp.pop());

console.log("\n=== Queue from iterable ===");
const fromArr = new Queue<number>([1, 2, 3]);
console.log("Queue([1,2,3])          -> front =", fromArr.front(), "  length =", fromArr.length);

console.log("\nNote: js-sdsl Queue<T>.pop() is O(1) amortized vs Array.shift() which is O(n).");
