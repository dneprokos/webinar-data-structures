/**
 * Practical QA automation examples using a singly-linked list.
 *
 * Scenarios:
 *   1. Browser navigation history (back/forward pointer).
 *   2. Form-wizard undo history.
 *   3. Sequential test-step chain (fail-fast).
 */

class LLNode<T> {
  constructor(public value: T, public next: LLNode<T> | null = null) {}
}

class SinglyLinkedList<T> {
  head: LLNode<T> | null = null;
  tail: LLNode<T> | null = null;
  size = 0;

  append(value: T): LLNode<T> {
    const node = new LLNode(value);
    if (this.tail === null) { this.head = this.tail = node; }
    else { this.tail.next = node; this.tail = node; }
    this.size++;
    return node;
  }

  removeLast(): T | undefined {
    if (this.head === null) return undefined;
    if (this.head === this.tail) {
      const value = this.head.value;
      this.head = this.tail = null;
      this.size--;
      return value;
    }
    let prev = this.head;
    while (prev.next !== this.tail) prev = prev.next!;
    const value = this.tail!.value;
    prev.next = null;
    this.tail = prev;
    this.size--;
    return value;
  }

  *[Symbol.iterator](): Iterator<T> {
    let current = this.head;
    while (current !== null) { yield current.value; current = current.next; }
  }
}

// ── Scenario 1: Browser navigation history ───────────────────────────────────
console.log("=== Browser navigation history ===");

const history = new SinglyLinkedList<string>();
let current: LLNode<string> | null = null;

function navigate(url: string): void {
  // Truncate forward history.
  if (current !== null) {
    current.next = null;
    history.tail = current;
  }
  current = history.append(url);
  console.log(`  Navigate -> ${url}  (history len: ${history.size})`);
}

function goBack(): void {
  if (current === history.head) { console.log("  Back: already at start"); return; }
  let node = history.head;
  while (node !== null && node.next !== current) node = node.next;
  if (node !== null) current = node;
  console.log(`  Back    <- ${current?.value}`);
}

navigate("/login");
navigate("/dashboard");
navigate("/orders");
navigate("/order/42");
goBack();
goBack();
console.log("  Current page:", current?.value);
navigate("/profile");   // Clears /orders and /order/42 forward history.
goBack();
console.log("  Current page after back:", current?.value);

// ── Scenario 2: Form-wizard undo history ──────────────────────────────────────
console.log("\n=== Form wizard undo history ===");

const steps = new SinglyLinkedList<string>();
for (const s of ["Filled: first name", "Filled: last name", "Filled: email", "Filled: address"]) {
  steps.append(s);
}
console.log(`Completed steps (${steps.size}):`);
for (const s of steps) console.log(`  + ${s}`);

console.log("Undoing last 2 steps:");
for (let i = 0; i < 2; i++) {
  const undone = steps.removeLast();
  if (undone !== undefined) console.log(`  Undo: ${undone}`);
}

console.log(`Remaining steps (${steps.size}):`);
for (const s of steps) console.log(`  + ${s}`);

// ── Scenario 3: Sequential test-step chain ────────────────────────────────────
console.log("\n=== Sequential test-step chain ===");

interface TestStep { name: string; execute: () => boolean; }

const testSteps = new SinglyLinkedList<TestStep>();
testSteps.append({ name: "Open login page",   execute: () => true });
testSteps.append({ name: "Enter credentials", execute: () => true });
testSteps.append({ name: "Click login",       execute: () => true });
testSteps.append({ name: "Assert dashboard",  execute: () => true });
testSteps.append({ name: "Assert user name",  execute: () => false }); // Simulates failure.

let passed = 0, failed = 0;
for (const step of testSteps) {
  const ok = step.execute();
  console.log(`  [${ok ? "PASS" : "FAIL"}] ${step.name}`);
  if (ok) { passed++; } else { failed++; break; } // Fail-fast.
}

console.log(`Result: ${passed} passed, ${failed} failed out of ${testSteps.size} steps`);
