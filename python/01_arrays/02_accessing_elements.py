"""Reading elements by index, iterating, and searching lists in Python."""

from __future__ import annotations


def run() -> None:
    index_access()
    iteration()
    searching()


def index_access() -> None:
    print("=== Index access (zero-based) ===")

    letters = ["a", "b", "c", "d"]

    print(f"letters[0]             = {letters[0]!r}  (first)")
    print(f"letters[2]             = {letters[2]!r}")
    print(f"letters[-1]            = {letters[-1]!r}  (last — negative index)")
    print(f"letters[-2]            = {letters[-2]!r}  (second-to-last)")

    # Slice — returns a new list.
    middle = letters[1:3]  # indices 1 and 2
    print(f"letters[1:3]           = {middle}")

    # Modify by index.
    nums = [10, 20, 30]
    nums[1] = 99
    print(f"After nums[1]=99       = {nums}")


def iteration() -> None:
    print("\n=== Iterating ===")

    scores = [55, 92, 81]

    # Plain for — most common.
    print("for item in scores:    ", end="")
    for s in scores:
        print(s, end=" ")
    print()

    # enumerate — when you need the index.
    print("enumerate:             ", end="")
    for i, s in enumerate(scores):
        print(f"[{i}]={s}", end=" ")
    print()

    # List comprehension to transform.
    labels = [f"s={s}" for s in scores]
    print(f"[f's={{s}}']:            {labels}")


def searching() -> None:
    print("\n=== Searching ===")

    fruits = ["apple", "banana", "cherry", "banana"]

    print(f'"banana" in fruits     = {"banana" in fruits}')
    print(f"index of 'banana'      = {fruits.index('banana')}  (first occurrence)")

    # Find with next() + generator.
    first_c = next((f for f in fruits if f.startswith("c")), None)
    print(f"first starting 'c'     = {first_c!r}")

    # any / all.
    print(f"any len > 5            = {any(len(f) > 5 for f in fruits)}")
    print(f"all len > 3            = {all(len(f) > 3 for f in fruits)}")


if __name__ == "__main__":
    run()
