/** Traversal, index access (O(n)), and search on SinglyLinkedList. */

class LLNode<T> {
  constructor(public value: T, public next: LLNode<T> | null = null) {}
}

class SinglyLinkedList<T> {
  head: LLNode<T> | null = null;
  private tail: LLNode<T> | null = null;
  size = 0;

  append(value: T): void {
    const node = new LLNode(value);
    if (this.tail === null) { this.head = this.tail = node; }
    else { this.tail.next = node; this.tail = node; }
    this.size++;
  }

  get(index: number): T | undefined {
    let current = this.head;
    for (let i = 0; i < index; i++) {
      if (current === null) return undefined;
      current = current.next;
    }
    return current?.value;
  }

  contains(value: T): boolean {
    for (const v of this) if (v === value) return true;
    return false;
  }

  *[Symbol.iterator](): Iterator<T> {
    let current = this.head;
    while (current !== null) { yield current.value; current = current.next; }
  }

  toArray(): T[] { return [...this]; }
}

const ll = new SinglyLinkedList<string>();
for (const url of ["/login", "/dashboard", "/profile", "/settings"]) ll.append(url);

console.log("=== Traverse head → tail ===");
let i = 0;
for (const value of ll) console.log(`  [${i++}] ${value}`);

console.log("\n=== Head value ===");
console.log("head =", ll.head?.value);

console.log("\n=== Get by index (O(n)) ===");
console.log("get(2)  =", ll.get(2));
console.log("get(99) =", ll.get(99), " (out of range → undefined)");

console.log("\n=== Contains ===");
console.log("contains('/dashboard') =", ll.contains("/dashboard"));
console.log("contains('/missing')   =", ll.contains("/missing"));
