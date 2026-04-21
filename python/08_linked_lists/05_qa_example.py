"""Practical QA automation examples using a singly-linked list.

Scenarios:
  1. Browser navigation history (back/forward pointer).
  2. Form-wizard undo history.
  3. Sequential test-step chain (fail-fast).
"""
from __future__ import annotations
from dataclasses import dataclass
from typing import Callable, Generic, Iterable, Iterator, TypeVar

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

    def remove_after(self, node: Node[T]) -> bool:
        """Remove the node immediately after the given node. O(1)."""
        if node.next is None:
            return False
        removed = node.next
        node.next = removed.next
        if removed is self._tail:
            self._tail = node
        self._size -= 1
        return True

    def __len__(self) -> int:
        return self._size

    def __iter__(self) -> Iterator[T]:
        current = self.head
        while current is not None:
            yield current.value
            current = current.next


def run() -> None:
    _browser_navigation_history()
    _form_wizard_undo()
    _test_step_chain()


def _browser_navigation_history() -> None:
    print("=== Browser navigation history ===")

    history: SinglyLinkedList[str] = SinglyLinkedList()
    current: Node[str] | None = None

    def navigate(url: str) -> None:
        nonlocal current
        # Truncate any forward history.
        if current is not None:
            current.next = None
            history._tail = current  # type: ignore[attr-defined]
        history.append(url)
        current = history._tail  # type: ignore[attr-defined]
        print(f"  Navigate -> {url}  (history len: {len(history)})")

    def go_back() -> None:
        nonlocal current
        # Walk from head to find the node just before current.
        if current is history.head:
            print("  Back: already at start")
            return
        node = history.head
        while node is not None and node.next is not current:
            node = node.next
        if node is not None:
            current = node
        print(f"  Back    <- {current.value if current else '?'}")

    navigate("/login")
    navigate("/dashboard")
    navigate("/orders")
    navigate("/order/42")
    go_back()
    go_back()
    print(f"  Current page: {current.value if current else '?'}")
    navigate("/profile")   # Clears /orders and /order/42 forward history.
    go_back()
    print(f"  Current page after back: {current.value if current else '?'}")


def _form_wizard_undo() -> None:
    print("\n=== Form wizard undo history ===")

    steps: SinglyLinkedList[str] = SinglyLinkedList([
        "Filled: first name",
        "Filled: last name",
        "Filled: email",
        "Filled: address",
    ])
    print(f"Completed steps ({len(steps)}):")
    for s in steps:
        print(f"  + {s}")

    print("Undoing last 2 steps:")
    for _ in range(2):
        if steps.head is None:
            break
        # Walk to the second-to-last node.
        node = steps.head
        while node.next is not None and node.next.next is not None:
            node = node.next
        last_value = node.next.value if node.next else node.value
        if node.next is not None:
            steps.remove_after(node)
        else:
            # Only one element.
            steps.head = steps._tail = None  # type: ignore[attr-defined]
            steps._size -= 1  # type: ignore[attr-defined]
        print(f"  Undo: {last_value}")

    print(f"Remaining steps ({len(steps)}):")
    for s in steps:
        print(f"  + {s}")


def _test_step_chain() -> None:
    print("\n=== Sequential test-step chain ===")

    @dataclass
    class Step:
        name: str
        execute: Callable[[], bool]

    steps: SinglyLinkedList[Step] = SinglyLinkedList([
        Step("Open login page",   lambda: True),
        Step("Enter credentials", lambda: True),
        Step("Click login",       lambda: True),
        Step("Assert dashboard",  lambda: True),
        Step("Assert user name",  lambda: False),  # Simulates a failing assertion.
    ])

    passed = failed = 0
    for step in steps:
        ok = step.execute()
        print(f"  [{'PASS' if ok else 'FAIL'}] {step.name}")
        if ok:
            passed += 1
        else:
            failed += 1
            break  # Fail-fast.

    print(f"Result: {passed} passed, {failed} failed out of {len(steps)} steps")


if __name__ == "__main__":
    run()
