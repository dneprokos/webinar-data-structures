"""Converting tuples to/from other types in Python."""

from __future__ import annotations


def run() -> None:
    print("=== Tuple → list ===")
    t = (1, 2, 3)
    lst = list(t)
    lst.append(4)
    print(f"list((1,2,3))        -> {lst}  (now mutable)")

    print("\n=== List of tuples → dict ===")
    items = [("a", 1), ("b", 2), ("c", 3)]
    d = dict(items)
    print(f"dict(pairs)          -> {d}")

    print("\n=== Dict items → list of tuples ===")
    env = {"BASE_URL": "https://api.example.com", "TIMEOUT": "30"}
    pairs = list(env.items())
    print(f"dict.items()         -> {pairs}")

    print("\n=== Tuple of tuples (2D structure) ===")
    matrix = ((1, 2), (3, 4), (5, 6))
    for row in matrix:
        print(f"  {row}")

    print("\n=== zip → list of tuples ===")
    keys = ["name", "role"]
    values = ["Ann", "admin"]
    zipped = list(zip(keys, values))
    print(f"zip(keys, values)    -> {zipped}")


if __name__ == "__main__":
    run()
