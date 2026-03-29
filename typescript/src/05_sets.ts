/** Set: uniqueness when merging several sources. */

const fromApi = [1, 2, 3, 3];
const fromDb = [3, 4, 5];
const merged = new Set<number>([...fromApi, ...fromDb]);
console.log([...merged].sort((a, b) => a - b).join(", "));

const a = new Set(["fail", "pass", "skip"]);
const b = new Set(["pass", "warn"]);
const intersection = [...a].filter((x) => b.has(x));
console.log("intersection:", intersection.join(", "));
