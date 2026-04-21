"""All the ways to create lists (Python's dynamic array) and array-like structures."""

from __future__ import annotations

import array  # module for typed arrays (rare; shown for completeness)


def run() -> None:
    empty_list()
    list_with_values()
    list_from_collection()
    typed_array()


def empty_list() -> None:
    print("=== Empty / pre-filled list ===")

    empty: list[int] = []
    print(f"[]                    -> len={len(empty)}")

    zeros = [0] * 4
    print(f"[0] * 4               -> {zeros}")

    ones = [1] * 5
    print(f"[1] * 5               -> {ones}")


def list_with_values() -> None:
    print("\n=== List with initial values ===")

    scores = [10, 20, 30]
    print(f"[10, 20, 30]          -> {scores}")

    tags = ["smoke", "api"]
    tags.append("regression")
    print(f"after append          -> {tags}")

    # List comprehension — create from a range.
    squares = [x ** 2 for x in range(1, 6)]
    print(f"squares 1..5          -> {squares}")


def list_from_collection() -> None:
    print("\n=== List from another collection ===")

    tup = (1, 2, 3)
    from_tuple = list(tup)
    print(f"list((1,2,3))         -> {from_tuple}")

    from_range = list(range(1, 6))
    print(f"list(range(1,6))      -> {from_range}")

    # Filter during creation.
    evens = [x for x in range(10) if x % 2 == 0]
    print(f"evens from range(10)  -> {evens}")


def typed_array() -> None:
    print("\n=== array.array — typed, memory-efficient (rare) ===")

    int_array = array.array("i", [10, 20, 30])
    print(f"array('i', [10,20,30]) -> {list(int_array)}")
    print("(Use list[] for everyday work; array.array only for performance-critical numeric data)")


if __name__ == "__main__":
    run()
