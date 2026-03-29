/** map / filter / reduce — parallel to LINQ / Python comprehensions. */

const scores = [55, 92, 81, 40, 88];
const sumOver80 = scores.filter((s) => s > 80).reduce((a, b) => a + b, 0);
console.log("sum (>80):", sumOver80);

const employees = [
  { name: "Ann", title: "SDET", salary: 90000 },
  { name: "Bob", title: "QA", salary: 70000 },
];
console.log("names:", employees.map((e) => e.name).join(", "));

const page = [...scores].sort((a, b) => b - a).slice(1, 3);
console.log("page:", page.join(", "));
