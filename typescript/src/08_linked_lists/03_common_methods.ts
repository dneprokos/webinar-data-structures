/** append, prepend, insertAfter, remove, and clear on SinglyLinkedList. */

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

  prepend(value: T): void {
    const node = new LLNode(value, this.head);
    this.head = node;
    if (this.tail === null) this.tail = node;
    this.size++;
  }

  /** Insert a new node with value after the first node matching target. O(n). */
  insertAfter(target: T, value: T): boolean {
    let current = this.head;
    while (current !== null) {
      if (current.value === target) {
        const node = new LLNode(value, current.next);
        current.next = node;
        if (current === this.tail) this.tail = node;
        this.size++;
        return true;
      }
      current = current.next;
    }
    return false;
  }

  /** Remove first occurrence of value. O(n). */
  remove(value: T): boolean {
    let prev: LLNode<T> | null = null;
    let current = this.head;
    while (current !== null) {
      if (current.value === value) {
        if (prev === null) this.head = current.next;
        else prev.next = current.next;
        if (current === this.tail) this.tail = prev;
        this.size--;
        return true;
      }
      prev = current;
      current = current.next;
    }
    return false;
  }

  clear(): void {
    this.head = this.tail = null;
    this.size = 0;
  }

  *[Symbol.iterator](): Iterator<T> {
    let current = this.head;
    while (current !== null) { yield current.value; current = current.next; }
  }

  toArray(): T[] { return [...this]; }
}

const ll = new SinglyLinkedList<string>();
ll.append("a"); ll.append("c");
console.log("Start:", ll.toArray());

console.log("\n=== append / prepend ===");
ll.append("END"); ll.prepend("START");
console.log("After append('END'), prepend('START'):", ll.toArray());

console.log("\n=== insertAfter ===");
const inserted = ll.insertAfter("a", "b");
console.log(`insertAfter('a', 'b') -> success=${inserted}`);
console.log("List:", ll.toArray());

console.log("\n=== remove ===");
const removed = ll.remove("c");
console.log(`remove('c') -> success=${removed}`);
console.log("List:", ll.toArray());
const removedMissing = ll.remove("MISSING");
console.log(`remove('MISSING') -> success=${removedMissing}  (not in list)`);

console.log("\n=== clear ===");
ll.clear();
console.log(`After clear() -> size=${ll.size}  head=${ll.head}`);
