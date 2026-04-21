/** Add, update, remove, merge, and frequency map operations. */

console.log("=== Add & Update (Record) ===");
const d: Record<string, number> = {};
d["a"] = 1; d["b"] = 2;
console.log("after add a,b     ->", d);
d["a"] = 99;
console.log("update a=99       -> d.a =", d["a"]);

console.log("\n=== Delete ===");
const d2 = { x: 1, y: 2, z: 3 };
delete d2["y" as keyof typeof d2];
console.log("delete d.y        ->", d2);

console.log("\n=== Map add/update/delete ===");
const m = new Map([["a", 1], ["b", 2]]);
m.set("c", 3);
console.log("map.set(c,3)      ->", m);
m.delete("b");
console.log("map.delete(b)     ->", m);
m.clear();
console.log("map.clear()       -> size", m.size);

console.log("\n=== Merge Records ===");
const r1 = { a: 1, b: 2 };
const r2 = { b: 99, c: 3 };
const merged = { ...r1, ...r2 };
console.log("{...r1, ...r2}    ->", merged, " (r2 wins on conflict)");

console.log("\n=== Frequency map ===");
const words = ["api", "smoke", "api", "regression", "smoke", "api"];
const freq = words.reduce((map, w) => map.set(w, (map.get(w) ?? 0) + 1), new Map<string, number>());
[...freq.entries()].sort(([, a], [, b]) => b - a).forEach(([w, c]) => console.log(`  ${w.padEnd(12)} x${c}`));
