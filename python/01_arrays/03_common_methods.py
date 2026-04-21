"""Add, remove, sort, filter, and map operations on Python lists."""

from __future__ import annotations


def run() -> None:
    adding_and_removing()
    sorting()
    filtering()
    projection()


def adding_and_removing() -> None:
    print("=== Adding & Removing ===")

    items = ["a", "b", "c", "b"]

    items.append("d")
    print(f"append('d')            -> {items}")

    items.insert(1, "X")
    print(f"insert(1, 'X')         -> {items}")

    items.remove("b")
    print(f"remove('b')            -> {items}  (first match only)")

    popped = items.pop(0)
    print(f"pop(0)                 -> removed {popped!r}, list={items}")

    # Remove all matching — list comprehension.
    items2 = ["a", "b", "c", "b"]
    items2 = [x for x in items2 if x != "b"]
    print(f"remove all 'b'         -> {items2}")

    items.clear()
    print(f"clear()                -> {items}")


def sorting() -> None:
    print("\n=== Sorting ===")

    values = [3, 1, 4, 1, 5]

    # sorted() — returns a NEW list, original unchanged.
    sorted_copy = sorted(values)
    print(f"sorted(values)         -> {sorted_copy}  (original: {values})")

    # .sort() — in-place, returns None.
    values.sort()
    print(f"values.sort()          -> {values}  (in-place)")

    # Reverse sort.
    desc = sorted(values, reverse=True)
    print(f"sorted(reverse=True)   -> {desc}")

    # Sort by key.
    names = ["zebra", "apple", "Mango"]
    print(f"sorted(key=str.lower)  -> {sorted(names, key=str.lower)}")


def filtering() -> None:
    print("\n=== Filtering ===")

    scores = [55, 92, 81, 40, 88]

    passed = [s for s in scores if s >= 80]
    print(f">= 80 (comp):          {passed}")

    mids = [s for s in scores if 50 < s < 90]
    print(f"50 < s < 90:           {mids}")

    words = ["a", "", "bb", "ccc"]
    non_empty = [w for w in words if len(w) > 0]
    print(f"non-empty strings:     {non_empty}")

    # filter() built-in (lazy — wrap with list()).
    positive = list(filter(lambda x: x > 0, [-1, 2, -3, 4]))
    print(f"filter(> 0):           {positive}")


def projection() -> None:
    print("\n=== Projection / Map ===")

    scores = [55, 92, 81, 40, 88]

    doubled = [s * 2 for s in scores]
    print(f"[s*2 for s in scores]: {doubled}")

    labels = [f"s={s}" for s in scores]
    print(f"to strings:            {labels}")

    employees = [{"name": "Ann", "title": "SDET"}, {"name": "Bob", "title": "QA"}]
    emp_names = [e["name"] for e in employees]
    print(f"pluck 'name':          {emp_names}")

    # map() built-in (lazy).
    squared = list(map(lambda x: x ** 2, [1, 2, 3, 4]))
    print(f"map(square, 1..4):     {squared}")


if __name__ == "__main__":
    run()
