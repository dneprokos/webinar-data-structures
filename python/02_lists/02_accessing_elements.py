"""Reading, iterating, and searching Python lists."""

from __future__ import annotations


def run() -> None:
    print("=== Index access ===")
    items = ["apple", "banana", "cherry"]
    print(f"items[0]         = {items[0]!r}")
    print(f"items[-1]        = {items[-1]!r}  (last)")
    print(f"len(items)       = {len(items)}")

    items[1] = "blueberry"
    print(f"items[1]='blueberry': {items}")

    print("\n=== Iterating ===")
    scores = [55, 92, 81]
    print("for s in scores: ", end="")
    for s in scores:
        print(s, end=" ")
    print()

    print("enumerate:       ", end="")
    for i, s in enumerate(scores):
        print(f"[{i}]={s}", end=" ")
    print()

    print("\n=== Searching ===")
    fruits = ["apple", "banana", "cherry"]
    print(f'"banana" in fruits = {"banana" in fruits}')
    print(f"index of 'banana'  = {fruits.index('banana')}")
    first_c = next((f for f in fruits if f.startswith("c")), None)
    print(f"first starts 'c'   = {first_c!r}")
    print(f"any len > 5        = {any(len(f) > 5 for f in fruits)}")
    print(f"all len > 3        = {all(len(f) > 3 for f in fruits)}")


if __name__ == "__main__":
    run()
