/** Aggregation in TypeScript using .reduce(), Math.min/max, and helpers. */

const scores = [55, 92, 81, 40, 88];
const employees = [
  { name: "Ann",  salary: 90_000 },
  { name: "Bob",  salary: 70_000 },
  { name: "Carl", salary: 85_000 },
];

console.log("=== Basic aggregates ===");
console.log("length:          ", scores.length);
console.log("sum:             ", scores.reduce((a, b) => a + b, 0));
console.log("min:             ", Math.min(...scores));
console.log("max:             ", Math.max(...scores));
console.log("average:         ", scores.reduce((a, b) => a + b, 0) / scores.length);

console.log("\n=== Conditional aggregates ===");
console.log("count >= 80:     ", scores.filter((s) => s >= 80).length);
console.log("sum >= 80:       ", scores.filter((s) => s >= 80).reduce((a, b) => a + b, 0));

console.log("\n=== Min/Max by key ===");
const topEarner = employees.reduce((best, e) => e.salary > best.salary ? e : best);
const lowest = employees.reduce((best, e) => e.salary < best.salary ? e : best);
console.log("max salary:      ", topEarner.name, `$${topEarner.salary.toLocaleString()}`);
console.log("min salary:      ", lowest.name, `$${lowest.salary.toLocaleString()}`);

console.log("\n=== reduce (fold) ===");
const product = scores.reduce((acc, s) => acc * s, 1);
console.log("product of all:  ", product);
const csv = employees.map((e) => e.name).reduce((acc, n) => acc ? `${acc},${n}` : n, "");
console.log("names as CSV:    ", csv);
