/** Creating dictionaries (Record and Map) in TypeScript. */

const SqlOperator = { Equals: "Equals", Like: "Like", In: "In" } as const;
type SqlOperator = (typeof SqlOperator)[keyof typeof SqlOperator];

console.log("=== Record<K,V> — plain object as map ===");
const scores: Record<string, number> = { Alice: 92, Bob: 85, Charlie: 78 };
console.log("inline Record        ->", scores);

console.log("\n=== Map<K,V> — true map, preserves insertion order ===");
const bookPrices = new Map<string, number>([
  ["Clean Code", 42.5],
  ["Refactoring", 39],
]);
console.log("Map from entries     ->", bookPrices);

console.log("\n=== Const-enum-like object as key ===");
const sqlByOp: Record<SqlOperator, string> = {
  [SqlOperator.Equals]: "=",
  [SqlOperator.Like]: "LIKE",
  [SqlOperator.In]: "IN",
};
console.log("sqlByOp              ->", sqlByOp);

console.log("\n=== Nested object ===");
const nested: Record<string, Record<string, number>> = {
  env1: { pass: 10, fail: 2 },
  env2: { pass: 8, fail: 5 },
};
console.log("nested env1.pass     =", nested["env1"]["pass"]);
