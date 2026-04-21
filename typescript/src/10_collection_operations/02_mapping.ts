/** Mapping/projection in TypeScript using .map() and .flatMap(). */

type Order = { id: string; customerId: string; items: [string, number][] };

const orders: Order[] = [
  { id: "o1", customerId: "c1", items: [["Laptop", 1200], ["Mouse", 25]] },
  { id: "o2", customerId: "c2", items: [["Keyboard", 75]] },
  { id: "o3", customerId: "c1", items: [["Monitor", 400], ["Desk", 200]] },
];

const scores = [55, 92, 81, 40, 88];

console.log("=== .map() ===");
console.log("doubled:      ", scores.map((s) => s * 2));
console.log("to strings:   ", scores.map((s) => `s=${s}`));

console.log("\n=== Project to objects ===");
const summaries = orders.map((o) => ({
  id: o.id,
  total: o.items.reduce((sum, [, price]) => sum + price, 0),
}));
summaries.forEach((s) => console.log(`  ${s.id}: $${s.total}`));

console.log("\n=== .flatMap() (SelectMany) ===");
const allItems = orders.flatMap((o) => o.items.map(([name]) => name));
console.log("all item names:", allItems);

console.log("\n=== map with index ===");
scores.map((s, i) => console.log(`  [${i}] = ${s}`));
