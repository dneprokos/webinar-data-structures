/** Stack using js-sdsl's generic Stack<T> (linked-list backed, true O(1) push/pop). */
import { Stack } from 'js-sdsl';

console.log("=== Empty Stack ===");
const empty = new Stack<number>();
console.log("new Stack<number>()    -> length", empty.length);

console.log("\n=== Build by pushing ===");
const stack = new Stack<number>();
for (const v of [101, 102, 103]) stack.push(v);
console.log("after push 101,102,103 -> top =", stack.top(), "  length =", stack.length);

console.log("\n=== Pop all (LIFO order) ===");
const tmp = new Stack<number>([101, 102, 103]);
while (tmp.length > 0) console.log("  pop() ->", tmp.pop());

console.log("\n=== Stack from iterable ===");
const s2 = new Stack<string>(["a", "b", "c"]);
console.log("Stack(['a','b','c'])    -> top =", s2.top(), "  length =", s2.length);

console.log("\nNote: js-sdsl Stack<T> has explicit .top() peek vs array's arr[arr.length-1].");
