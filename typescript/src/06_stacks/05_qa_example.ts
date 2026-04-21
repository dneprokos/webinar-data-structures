/** Practical QA automation examples using TypeScript array-based stacks. */

console.log("=== Browser navigation history ===");
const history: string[] = [];
for (const url of ["https://example.com", "https://example.com/products", "https://example.com/products/42"]) {
  history.push(url);
}
console.log("Current page:", history.at(-1));
history.pop();
console.log("After Back:  ", history.at(-1));
history.pop();
console.log("After Back:  ", history.at(-1));

console.log("\n=== Client resource pool ===");
const pool: number[] = [];
for (const id of [101, 102, 103]) pool.push(id);
console.log(`Pool size: ${pool.length}`);
const client1 = pool.pop()!;
console.log(`Test 1 acquired client ${client1}, pool: ${pool.length}`);
const client2 = pool.pop()!;
console.log(`Test 2 acquired client ${client2}, pool: ${pool.length}`);
pool.push(client1); pool.push(client2);
console.log(`Clients returned. Pool size: ${pool.length}`);

console.log("\n=== Undo-redo simulation ===");
const undoStack: string[] = [];
const redoStack: string[] = [];

function doAction(action: string): void {
  console.log(`  Do: ${action}`);
  undoStack.push(action);
  redoStack.length = 0;
}
function undo(): void {
  const a = undoStack.pop();
  if (a) { redoStack.push(a); console.log(`  Undo: ${a}`); }
}
function redo(): void {
  const a = redoStack.pop();
  if (a) { undoStack.push(a); console.log(`  Redo: ${a}`); }
}

doAction("type 'admin' in username");
doAction("type 'pass' in password");
doAction("click login");
undo(); undo(); redo();
console.log(`Undo: ${undoStack.length}, Redo: ${redoStack.length}`);
