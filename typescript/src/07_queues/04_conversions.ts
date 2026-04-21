/** Converting queues to/from other types in TypeScript. */

console.log("=== Queue → snapshot array ===");
const q = ["a", "b", "c"];
const snapshot = [...q];
console.log("[...queue]         ->", snapshot);

console.log("\n=== Process all and collect results ===");
const jobs = ["job1", "job2", "job3"];
const results: string[] = [];
while (jobs.length > 0) results.push(`done:${jobs.shift()!}`);
console.log("results            ->", results);

console.log("\n=== Queue from Set (deduped enqueue order) ===");
const tags = new Set(["smoke", "api", "smoke", "regression"]);
const tagQueue = Array.from(tags);
console.log("Array.from(Set)    ->", tagQueue);
