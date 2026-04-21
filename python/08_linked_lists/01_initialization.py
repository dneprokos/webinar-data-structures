"""Creating SinglyLinkedList instances in Python."""
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
    print("=== Empty linked list ===")
    empty: SinglyLinkedList[int] = SinglyLinkedList()
    print(f"SinglyLinkedList()            -> len={len(empty)}  head={empty.head}")

    print("\n=== LinkedList from iterable ===")
    from_iter: SinglyLinkedList[str] = SinglyLinkedList(["login", "dashboard", "profile"])
    print(f"SinglyLinkedList([...])       -> len={len(from_iter)}  head={from_iter.head.value!r}")

    print("\n=== Build by appending ===")
    ll: SinglyLinkedList[str] = SinglyLinkedList()
    ll.append("step-1")
    ll.append("step-2")
    ll.append("step-3")
    print(f"After 3 appends               -> len={len(ll)}  head={ll.head.value!r}")

    print("\n=== Prepend to front ===")
    ll.prepend("step-0")
    print(f"After prepend('step-0')       -> len={len(ll)}  head={ll.head.value!r}")
    print(f"Values: {ll.to_list()}")


if __name__ == "__main__":
    run()
