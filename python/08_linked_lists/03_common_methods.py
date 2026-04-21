"""append, prepend, insert_after, remove, and clear on SinglyLinkedList."""
from __future__ import annotations
from dataclasses import dataclass
from typing import Generic, Iterable, Iterator, TypeVar

T = TypeVar("T")


@dataclass
class Node(Generic[T]):
    value: T
    next: Node[T] | None = None


class SinglyLinkedList(Generic[T]):
    def __init__(self, values: Iterable[T] | None = None) -> None:
        self.head: Node[T] | None = None
        self._tail: Node[T] | None = None
        self._size: int = 0
        if values is not None:
            for v in values:
                self.append(v)

    def append(self, value: T) -> None:
        node = Node(value)
        if self._tail is None:
            self.head = self._tail = node
        else:
            self._tail.next = node
            self._tail = node
        self._size += 1

    def prepend(self, value: T) -> None:
        node = Node(value, self.head)
        self.head = node
        if self._tail is None:
            self._tail = node
        self._size += 1

    def insert_after(self, target: T, value: T) -> bool:
        """Insert a new node with value after the first node matching target. O(n)."""
        current = self.head
        while current is not None:
            if current.value == target:
                new_node = Node(value, current.next)
                current.next = new_node
                if current is self._tail:
                    self._tail = new_node
                self._size += 1
                return True
            current = current.next
        return False

    def remove(self, value: T) -> bool:
        """Remove first occurrence of value. O(n)."""
        prev: Node[T] | None = None
        current = self.head
        while current is not None:
            if current.value == value:
                if prev is None:
                    self.head = current.next
                else:
                    prev.next = current.next
                if current is self._tail:
                    self._tail = prev
                self._size -= 1
                return True
            prev, current = current, current.next
        return False

    def clear(self) -> None:
        self.head = self._tail = None
        self._size = 0

    def __len__(self) -> int:
        return self._size

    def __iter__(self) -> Iterator[T]:
        current = self.head
        while current is not None:
            yield current.value
            current = current.next

    def to_list(self) -> list[T]:
        return list(self)


def run() -> None:
    ll: SinglyLinkedList[str] = SinglyLinkedList(["a", "c"])
    print(f"Start: {ll.to_list()}")

    print("\n=== append / prepend ===")
    ll.append("END")
    ll.prepend("START")
    print(f"After append('END'), prepend('START'): {ll.to_list()}")

    print("\n=== insert_after ===")
    inserted = ll.insert_after("a", "b")
    print(f"insert_after('a', 'b') -> success={inserted}")
    print(f"List: {ll.to_list()}")

    print("\n=== remove ===")
    removed = ll.remove("c")
    print(f"remove('c') -> success={removed}")
    print(f"List: {ll.to_list()}")

    removed_missing = ll.remove("MISSING")
    print(f"remove('MISSING') -> success={removed_missing}  (not in list)")

    print("\n=== clear ===")
    ll.clear()
    print(f"After clear() -> len={len(ll)}  head={ll.head}")


if __name__ == "__main__":
    run()
