"""Tuple operations: equality, sorting, and using tuples in collections."""

from __future__ import annotations


def run() -> None:
    print("=== Equality ===")
    a = (1, "hello")
    b = (1, "hello")
    c = (2, "hello")
    print(f"a == b: {a == b}")
    print(f"a == c: {a == c}")

    print("\n=== Tuples are immutable ===")
    t = (1, 2, 3)
    print(f"count(1) = {t.count(1)}")
    print(f"index(2) = {t.index(2)}")
    # t[0] = 99  # would raise TypeError

    print("\n=== Sorting list of tuples ===")
    scores = [("Bob", 85), ("Ann", 92), ("Ann", 78)]
    sorted_scores = sorted(scores, key=lambda t: (t[0], -t[1]))
    for name, score in sorted_scores:
        print(f"  {name}: {score}")

    print("\n=== Tuples in dict values ===")
    config: dict[str, tuple[str, bool]] = {
        "db_host": ("localhost", False),
        "db_pass": ("s3cr3t", True),
    }
    for key, (value, is_secret) in config.items():
        print(f"  {key} = {'***' if is_secret else value!r}")


if __name__ == "__main__":
    run()
