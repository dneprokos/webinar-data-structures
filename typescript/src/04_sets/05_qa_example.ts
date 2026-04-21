/** Practical QA automation examples using TypeScript Sets. */

console.log("=== Deduplicate test environment URLs ===");
const envUrls = [
  "https://staging.example.com",
  "https://prod.example.com",
  "https://staging.example.com",
  "HTTPS://STAGING.EXAMPLE.COM",
];
const uniqueUrls = new Set(envUrls.map((u) => u.toLowerCase()));
console.log(`Input:  ${envUrls.length} URLs`);
console.log(`Unique: ${uniqueUrls.size} URLs`);
[...uniqueUrls].sort().forEach((url) => console.log(`  ${url}`));

console.log("\n=== Verify API response has all required fields ===");
const required = new Set(["id", "name", "email", "role", "createdAt"]);
const returned = new Set(["id", "name", "email", "createdAt"]);
const missing = [...required].filter((f) => !returned.has(f));
const extra = [...returned].filter((f) => !required.has(f));
console.log(`Missing: [${missing}]`);
console.log(`Extra:   [${extra}]`);
console.log(missing.length === 0 ? "PASS: all required fields present" : "FAIL: missing fields detected");

console.log("\n=== Find untested endpoints ===");
const allEndpoints = new Set(["GET /users", "POST /users", "GET /users/{id}", "PUT /users/{id}", "DELETE /users/{id}", "GET /orders"]);
const tested = new Set(["GET /users", "POST /users", "GET /users/{id}"]);
const untested = [...allEndpoints].filter((ep) => !tested.has(ep)).sort();
console.log(`Total: ${allEndpoints.size}  Tested: ${tested.size}  Untested: ${untested.length}`);
untested.forEach((ep) => console.log(`  ○ ${ep}`));
