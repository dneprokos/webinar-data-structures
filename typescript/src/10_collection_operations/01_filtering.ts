/** Filtering sequences in TypeScript using .filter() and related methods. */

type Employee = { id: string; name: string; title: string; salary: number; department: string };

const employees: Employee[] = [
  { id: "e1", name: "Ann",   title: "SDET",   salary: 90_000, department: "QA" },
  { id: "e2", name: "Bob",   title: "QA",     salary: 70_000, department: "QA" },
  { id: "e3", name: "Carl",  title: "DevOps", salary: 85_000, department: "Ops" },
  { id: "e4", name: "Diana", title: "SDET",   salary: 95_000, department: "QA" },
  { id: "e5", name: "Eve",   title: "Dev",    salary: 80_000, department: "Dev" },
];

console.log("=== .filter() ===");
const qa = employees.filter((e) => e.department === "QA");
console.log("Department QA:    ", qa.map((e) => e.name));

const high = employees.filter((e) => e.salary > 85_000);
console.log("Salary > 85k:     ", high.map((e) => e.name));

const sdetQa = employees.filter((e) => e.title === "SDET" && e.department === "QA");
console.log("SDET in QA:       ", sdetQa.map((e) => e.name));

console.log("\n=== .find() / .some() / .every() ===");
console.log("first QA:         ", employees.find((e) => e.department === "QA")?.name);
console.log("some salary > 90k:", employees.some((e) => e.salary > 90_000));
console.log("all salary > 50k: ", employees.every((e) => e.salary > 50_000));

console.log("\n=== Distinct (via Set) ===");
const depts = [...new Set(employees.map((e) => e.department))].sort();
console.log("unique depts:     ", depts);
