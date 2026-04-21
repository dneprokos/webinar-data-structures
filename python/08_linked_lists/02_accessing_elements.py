"""Traversal, index access (O(n)), and search on SinglyLinkedList."""
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

    def __len__(self) -> int:
        return self._size

    def __iter__(self) -> Iterator[T]:
        current = self.head
        while current is not None:
            yield current.value
            current = current.next

    def get(self, index: int) -> T | None:
        """Return value at index (O(n))."""
        current = self.head
        for _ in range(index):
            if current is None:
                return None
            current = current.next
        return current.value if current is not None else None

    def contains(self, value: T) -> bool:
        return any(v == value for v in self)


def run() -> None:
    ll: SinglyLinkedList[str] = SinglyLinkedList(["/login", "/dashboard", "/profile", "/settings"])

    print("=== Traverse head → tail ===")
    for i, value in enumerate(ll):
        print(f"  [{i}] {value}")

    print("\n=== Head value ===")
    print(f"head = {ll.head.value!r}" if ll.head else "head = None")

    print("\n=== Get by index (O(n)) ===")
    print(f"get(2)  = {ll.get(2)!r}")
    print(f"get(99) = {ll.get(99)!r}  (out of range → None)")

    print("\n=== Contains ===")
    print(f"contains('/dashboard') = {ll.contains('/dashboard')}")
    print(f"contains('/missing')   = {ll.contains('/missing')}")


if __name__ == "__main__":
    run()
