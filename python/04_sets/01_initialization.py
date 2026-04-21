"""Creating sets in Python."""
from __future__ import annotations

def run() -> None:
    print("=== Empty set ===")
    empty: set[int] = set()
    print(f"set()                  -> len={len(empty)}")

    print("\n=== Set with initial values ===")
    tags = {"smoke", "api", "regression"}
    print(f"inline literal         -> {tags}")

    print("\n=== From list (dedup) ===")
    with_dups = [1, 2, 2, 3, 3, 3]
    unique = set(with_dups)
    print(f"set([1,2,2,3,3,3])     -> {sorted(unique)}  (len={len(unique)})")

    print("\n=== Frozenset — immutable set ===")
    immutable = frozenset({"read", "write", "execute"})
    print(f"frozenset              -> {sorted(immutable)}")

if __name__ == "__main__":
    run()
