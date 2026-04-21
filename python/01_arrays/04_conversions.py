"""Converting lists to/from other collection types in Python."""

from __future__ import annotations


def run() -> None:
    list_to_tuple()
    list_to_set()
    list_to_dict()
    list_to_string()
    string_to_list()


def list_to_tuple() -> None:
    print("=== list → tuple ===")

    items = [1, 2, 3]
    t = tuple(items)
    print(f"tuple([1,2,3])         -> {t}  (immutable)")


def list_to_set() -> None:
    print("\n=== list → set (dedup) ===")

    with_dups = [1, 2, 2, 3, 3, 3]
    unique = set(with_dups)
    print(f"set([1,2,2,3,3,3])     -> {unique}  (duplicates removed)")

    # Back to sorted list.
    back = sorted(unique)
    print(f"sorted(set(...))       -> {back}")


def list_to_dict() -> None:
    print("\n=== list → dict ===")

    # List of tuples → dict.
    pairs = [("a", 1), ("b", 2), ("c", 3)]
    d = dict(pairs)
    print(f"dict(pairs)            -> {d}")

    # Using dict comprehension.
    employees = [{"id": "e1", "name": "Ann"}, {"id": "e2", "name": "Bob"}]
    by_id = {e["id"]: e["name"] for e in employees}
    print(f"{{e[id]: e[name]}}       -> {by_id}")

    # Frequency map (list → count dict).
    tags = ["smoke", "api", "smoke", "regression", "smoke"]
    freq = {tag: tags.count(tag) for tag in set(tags)}
    print(f"frequency map          -> {freq}")


def list_to_string() -> None:
    print("\n=== list → string ===")

    ids = [2, 5, 7]
    query = "?ids=" + ",".join(str(i) for i in ids)
    print(f"query string           -> {query}")

    words = ["Hello", "World"]
    sentence = " ".join(words)
    print(f"join words             -> {sentence!r}")


def string_to_list() -> None:
    print("\n=== string → list ===")

    csv_line = "alice,bob,charlie"
    parts = csv_line.split(",")
    print(f"split(',')             -> {parts}")

    chars = list("hello")
    print(f"list('hello')          -> {chars}")


if __name__ == "__main__":
    run()
