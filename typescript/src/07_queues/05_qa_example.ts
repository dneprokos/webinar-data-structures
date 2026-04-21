/** Practical QA automation examples using TypeScript array-based queues. */

console.log("=== Test execution queue ===");
const testQueue = [
  "login_happy_path", "login_wrong_password",
  "checkout_empty_cart", "search_no_results",
];
console.log(`Scheduled ${testQueue.length} tests:`);
const results: [string, string][] = [];
let runNum = 1;
while (testQueue.length > 0) {
  const name = testQueue.shift()!;
  const status = runNum % 2 === 0 ? "fail" : "pass";
  results.push([name, status]);
  console.log(`  [${runNum++}] ${name.padEnd(30)} -> ${status}`);
}
const passed = results.filter(([, s]) => s === "pass").length;
console.log(`Result: ${passed}/${results.length} passed`);

console.log("\n=== Rate limiter: max 2 per batch ===");
const requests = [
  "GET /api/users", "POST /api/orders", "GET /api/products",
  "DELETE /api/sessions", "GET /api/reports",
];
let batch = 1;
while (requests.length > 0) {
  console.log(`  Batch ${batch++}:`);
  for (let i = 0; i < 2 && requests.length > 0; i++) {
    console.log(`    processed: ${requests.shift()}`);
  }
}

console.log("\n=== Event processing ===");
const events = [
  "page_load", "user_click_login",
  "api_request_sent", "api_response_received", "page_redirect",
];
while (events.length > 0) console.log(`  [event] ${events.shift()}`);
