"""Converting Python lists to/from other collection types."""

from __future__ import annotations


def run() -> None:
    print("=== list → tuple ===")
    lst = [1, 2, 3]
    t = tuple(lst)
    print(f"tuple([1,2,3])   -> {t}")

    print("\n=== list → set (dedup) ===")
    with_dups = [1, 2, 2, 3, 3, 3]
    unique = sorted(set(with_dups))
    print(f"sorted(set(...)) -> {unique}")

    print("\n=== list → dict ===")
    pairs = [("a", 1), ("b", 2)]
    d = dict(pairs)
    print(f"dict(pairs)      -> {d}")

    employees = [{"id": "e1", "name": "Ann"}, {"id": "e2", "name": "Bob"}]
    by_id = {e["id"]: e["name"] for e in employees}
    print(f"{{id: name}}       -> {by_id}")

    print("\n=== list → string ===")
    words = ["Hello", "World"]
    print(f"' '.join(words)  -> {' '.join(words)!r}")
    ids = [2, 5, 7]
    print(f"csv ids          -> {'?ids=' + ','.join(str(i) for i in ids)}")


if __name__ == "__main__":
    run()
