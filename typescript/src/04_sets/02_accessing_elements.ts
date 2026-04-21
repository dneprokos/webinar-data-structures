/** Membership testing and iterating TypeScript Sets. */

console.log("=== Membership test O(1) ===");
const allowed = new Set(["admin", "editor", "viewer"]);
console.log('"admin" in set   =', allowed.has("admin"));
console.log('"hacker" in set  =', allowed.has("hacker"));

console.log("\n=== Iterating ===");
for (const role of [...allowed].sort()) {
  console.log(" ", role);
}

console.log("\n=== No index access ===");
console.log("(Sets have no [i] — spread to array for index access)");
const asList = [...allowed].sort();
console.log("[...set].sort()[0] =", asList[0]);
