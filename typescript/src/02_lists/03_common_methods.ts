/** Add, remove, sort, and other common array operations in TypeScript. */

console.log("=== Add & Remove ===");
const lst = ["a", "b", "c"];
lst.push("d");
console.log('push("d")        ->', lst);
lst.push("e", "f");
console.log('push("e","f")    ->', lst);
lst.splice(1, 0, "X");
console.log('splice(1,0,"X")  ->', lst);
const i = lst.indexOf("X");
if (i !== -1) lst.splice(i, 1);
console.log('remove "X"       ->', lst);
const noB = lst.filter((x) => x !== "b");
console.log('filter !== "b"   ->', noB);
lst.length = 0;
console.log("length = 0       ->", lst);

console.log("\n=== Sort ===");
const nums = [3, 1, 4, 1, 5];
const asc = [...nums].sort((a, b) => a - b);
console.log("sorted asc       ->", asc, " original:", nums);
const names = ["Zebra", "apple", "Mango"];
console.log("sorted locale    ->", [...names].sort((a, b) => a.localeCompare(b, undefined, { sensitivity: "base" })));

console.log("\n=== Aggregates & checks ===");
const scores = [55, 92, 81, 40, 88];
console.log("length           =", scores.length);
console.log("sum              =", scores.reduce((a, b) => a + b, 0));
console.log("min / max        =", Math.min(...scores), "/", Math.max(...scores));
console.log("some(> 90)       =", scores.some((s) => s > 90));
console.log("every(> 0)       =", scores.every((s) => s > 0));
