"""Converting SinglyLinkedList to/from lists, tuples, and other collections."""
from __future__ import annotations
from collections import deque
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

    def to_list(self) -> list[T]:
        return list(self)


def run() -> None:
    ll: SinglyLinkedList[int] = SinglyLinkedList([1, 2, 3, 4, 5])

    print("=== LinkedList → list ===")
    as_list = ll.to_list()
    print(f"to_list()          -> {as_list}")

    print("\n=== LinkedList → tuple ===")
    as_tuple = tuple(ll)
    print(f"tuple(ll)          -> {as_tuple}")

    print("\n=== LinkedList → set (lose order, deduplicate) ===")
    ll_with_dupes: SinglyLinkedList[int] = SinglyLinkedList([1, 2, 2, 3, 3])
    as_set = set(ll_with_dupes)
    print(f"set(ll_with_dupes) -> {as_set}  (duplicates removed)")

    print("\n=== LinkedList → deque (efficient queue) ===")
    as_deque: deque[int] = deque(ll)
    print(f"deque(ll)          -> {list(as_deque)}  front={as_deque[0]}")

    print("\n=== list → LinkedList ===")
    from_list: SinglyLinkedList[str] = SinglyLinkedList(["x", "y", "z"])
    print(f"SinglyLinkedList(['x','y','z']) -> {from_list.to_list()}")

    print("\n=== Filter and rebuild ===")
    evens: SinglyLinkedList[int] = SinglyLinkedList(v for v in ll if v % 2 == 0)
    print(f"Even nodes only    -> {evens.to_list()}")


if __name__ == "__main__":
    run()
