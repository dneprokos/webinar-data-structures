/** Creating SinglyLinkedList instances in TypeScript. */

class LLNode<T> {
  constructor(public value: T, public next: LLNode<T> | null = null) {}
}

class SinglyLinkedList<T> {
  head: LLNode<T> | null = null;
  private tail: LLNode<T> | null = null;
  size = 0;

  append(value: T): void {
    const node = new LLNode(value);
    if (this.tail === null) {
      this.head = this.tail = node;
    } else {
      this.tail.next = node;
      this.tail = node;
    }
    this.size++;
  }

  prepend(value: T): void {
    const node = new LLNode(value, this.head);
    this.head = node;
    if (this.tail === null) this.tail = node;
    this.size++;
  }

  *[Symbol.iterator](): Iterator<T> {
    let current = this.head;
    while (current !== null) {
      yield current.value;
      current = current.next;
    }
  }

  toArray(): T[] {
    return [...this];
  }
}

console.log("=== Empty linked list ===");
const empty = new SinglyLinkedList<number>();
console.log("new SinglyLinkedList<number>()     -> size =", empty.size, "  head =", empty.head);

console.log("\n=== Build by appending ===");
const ll = new SinglyLinkedList<string>();
ll.append("step-1");
ll.append("step-2");
ll.append("step-3");
console.log("After 3 appends                    -> size =", ll.size, "  head =", ll.head?.value);

console.log("\n=== Prepend to front ===");
ll.prepend("step-0");
console.log("After prepend('step-0')            -> size =", ll.size, "  head =", ll.head?.value);
console.log("Values:", ll.toArray());
