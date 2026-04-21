/** Practical QA automation examples using TypeScript tuples. */

type ElementInfo = [selector: string, isVisible: boolean];
type ValidationResult = [isValid: boolean, error: string];
type ConfigEntry = [key: string, value: string];

function getLoginButton(): ElementInfo {
  return ["#login-btn", true];
}

function validateEmail(email: string): ValidationResult {
  const isValid = email.includes("@") && email.includes(".");
  return [isValid, isValid ? "" : "Invalid email format"];
}

function getTestConfig(env: string): ConfigEntry[] {
  return [
    ["BASE_URL", `https://${env}.example.com`],
    ["TIMEOUT_SEC", "30"],
    ["HEADLESS", "true"],
  ];
}

console.log("=== Page object method returning element info ===");
const [selector, isVisible] = getLoginButton();
console.log(`Selector: '${selector}', Visible: ${isVisible}`);
if (isVisible) console.log("Proceeding to click login button");

console.log("\n=== Validation returning [isValid, error] ===");
for (const email of ["alice@test.com", "not-an-email", "bob@example.org"]) {
  const [valid, err] = validateEmail(email);
  console.log(`  ${email.padEnd(25)} valid=${valid}${valid ? "" : "  error: " + err}`);
}

console.log("\n=== Environment config as array of [key, value] tuples ===");
const config = getTestConfig("staging");
config.forEach(([key, value]) => console.log(`  ${key.padEnd(15)} = ${value}`));
