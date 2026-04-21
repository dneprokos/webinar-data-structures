/** Reading values from Records and Maps, safe access, and iteration. */

console.log("=== Record access ===");
const config: Record<string, string> = {
  base_url: "https://api.example.com",
  timeout: "30",
};
console.log('config["base_url"]   =', config["base_url"]);
console.log('"timeout" in config  =', "timeout" in config);
console.log("config?.missing      =", config["missing"] ?? "default");

console.log("\n=== Map access ===");
const bookPrices = new Map([["Clean Code", 42.5], ["Refactoring", 39]]);
console.log('map.get("Clean Code")=', bookPrices.get("Clean Code"));
console.log('map.has("missing")   =', bookPrices.has("missing"));
console.log('map.get("missing")??0=', bookPrices.get("missing") ?? 0);

console.log("\n=== Iterating Record ===");
Object.entries(config).sort(([a], [b]) => a.localeCompare(b)).forEach(([k, v]) => {
  console.log(`  ${k.padEnd(10)} = ${v}`);
});

console.log("\n=== Iterating Map ===");
for (const [title, price] of bookPrices) {
  console.log(`  ${title.padEnd(12)} = ${price}`);
}
