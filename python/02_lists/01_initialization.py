"""All the ways to create lists in Python."""

from __future__ import annotations


def run() -> None:
    print("=== Empty list ===")
    empty: list[int] = []
    print(f"[]                  -> len={len(empty)}")

    with_capacity = []  # Python lists grow on demand; no pre-allocated capacity concept
    print(f"[]                  -> (no explicit capacity needed)")

    print("\n=== List with values ===")
    tags = ["smoke", "api", "regression"]
    print(f"inline literal      -> {tags}")

    scores = list(range(10, 50, 10))
    print(f"list(range(...))    -> {scores}")

    print("\n=== From existing collection ===")
    from_tuple = list((1, 2, 3))
    print(f"list((1,2,3))       -> {from_tuple}")

    evens = [x for x in range(10) if x % 2 == 0]
    print(f"even comprehension  -> {evens}")

    from_set = sorted(list({3, 1, 2}))
    print(f"sorted(list(set))   -> {from_set}")


if __name__ == "__main__":
    run()
