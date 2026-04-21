/** Sorting and slicing in TypeScript: .sort(), .slice(), groupBy with reduce. */

const scores = [55, 92, 81, 40, 88];
const employees = [
  { name: "Ann",   dept: "QA",  salary: 90_000 },
  { name: "Bob",   dept: "Dev", salary: 80_000 },
  { name: "Carl",  dept: "QA",  salary: 70_000 },
  { name: "Diana", dept: "Dev", salary: 85_000 },
];

console.log("=== sort (always spread first!) ===");
console.log("sorted asc:         ", [...scores].sort((a, b) => a - b));
console.log("sorted desc:        ", [...scores].sort((a, b) => b - a));
console.log("original unchanged: ", scores);

console.log("\n=== Sort by key ===");
const bySalary = [...employees].sort((a, b) => b.salary - a.salary);
bySalary.forEach((e) => console.log(`  ${e.name.padEnd(8)} $${e.salary.toLocaleString()}`));

console.log("\n=== Multi-key sort ===");
const multi = [...employees].sort((a, b) => a.dept !== b.dept ? a.dept.localeCompare(b.dept) : b.salary - a.salary);
multi.forEach((e) => console.log(`  ${e.dept.padEnd(5)} ${e.name.padEnd(8)} $${e.salary.toLocaleString()}`));

console.log("\n=== .slice() (Skip/Take) ===");
const sorted = [...scores].sort((a, b) => a - b);
const pageSize = 2;
for (let p = 0; p * pageSize < sorted.length; p++) {
  console.log(`  Page ${p + 1}:`, sorted.slice(p * pageSize, (p + 1) * pageSize));
}

console.log("\n=== GroupBy (reduce to Map) ===");
const grouped = employees.reduce((m, e) => {
  m.set(e.dept, [...(m.get(e.dept) ?? []), e.name]);
  return m;
}, new Map<string, string[]>());
for (const [dept, names] of [...grouped].sort()) {
  console.log(`  ${dept}: ${names}`);
}
