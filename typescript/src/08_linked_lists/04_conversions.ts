/** Converting SinglyLinkedList to/from arrays, sets, and other collections. */

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

  static fromArray<T>(arr: T[]): SinglyLinkedList<T> {
    const ll = new SinglyLinkedList<T>();
    for (const v of arr) ll.append(v);
    return ll;
  }

  *[Symbol.iterator](): Iterator<T> {
    let current = this.head;
    while (current !== null) { yield current.value; current = current.next; }
  }

  toArray(): T[] { return [...this]; }
}

const ll = SinglyLinkedList.fromArray([1, 2, 3, 4, 5]);

console.log("=== LinkedList → Array ===");
console.log("toArray()          ->", ll.toArray());

console.log("\n=== LinkedList → Set (deduplicate) ===");
const llDupes = SinglyLinkedList.fromArray([1, 2, 2, 3, 3]);
const asSet = new Set(llDupes);
console.log("new Set(ll_dupes)  ->", [...asSet], " (duplicates removed)");

console.log("\n=== Array → LinkedList ===");
const fromArr = SinglyLinkedList.fromArray(["x", "y", "z"]);
console.log("fromArray(['x','y','z']) -> head =", fromArr.head?.value, "  size =", fromArr.size);

console.log("\n=== LinkedList → Map (index as key) ===");
const indexMap = new Map<number, number>(ll.toArray().map((v, i) => [i, v]));
console.log("Map from ll        ->", [...indexMap.entries()]);

console.log("\n=== Filter and rebuild ===");
const evens = SinglyLinkedList.fromArray(ll.toArray().filter(v => v % 2 === 0));
console.log("Even nodes only    ->", evens.toArray());
