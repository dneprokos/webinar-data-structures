/** Reading tuple elements and destructuring in TypeScript. */

console.log("=== Index access ===");
const result: [number, string] = [200, "OK"];
console.log("result[0] =", result[0]);
console.log("result[1] =", result[1]);

console.log("\n=== Destructuring ===");
const [code, message] = [404, "Not Found"] as [number, string];
console.log(`code=${code}, message=${message}`);

// Swap via destructuring.
let a = 1, b = 2;
[a, b] = [b, a];
console.log(`After swap: a=${a}, b=${b}`);

// Rest in destructuring.
const [first, ...rest] = [10, 20, 30, 40] as [number, ...number[]];
console.log(`first=${first}, rest=[${rest}]`);

console.log("\n=== Ignoring elements ===");
const [userId, , role] = ["u1", "Ann", "admin"] as [string, string, string];
console.log(`id=${userId}, role=${role}  (name skipped)`);
