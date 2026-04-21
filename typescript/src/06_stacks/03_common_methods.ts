/** Push, pop, peek, and LIFO demonstration for TypeScript stacks. */

console.log("=== Push, Pop, Peek ===");
const s: number[] = [];
s.push(1); s.push(2); s.push(3);
console.log("after push 1,2,3  -> top =", s.at(-1), " length =", s.length);
const popped = s.pop();
console.log("pop()              =", popped, " length =", s.length);

console.log("\n=== Safe peek ===");
const top = s.length > 0 ? s[s.length - 1] : undefined;
console.log("top =", top);

console.log("\n=== Clear ===");
s.length = 0;
console.log("length = 0        ->", s);

console.log("\n=== LIFO demonstration ===");
const lifo: string[] = [];
for (const item of ["first", "second", "third"]) lifo.push(item);
process.stdout.write("Pop order (LIFO):  ");
while (lifo.length > 0) process.stdout.write(lifo.pop()! + " ");
console.log();
