"""Converting Python sets to/from other types."""
from __future__ import annotations

def run() -> None:
    print("=== list → set (dedup) ===")
    lst = [1, 2, 2, 3, 3, 3]
    print(f"set([1,2,2,3,3,3]) -> {sorted(set(lst))}")

    print("\n=== set → sorted list ===")
    roles = {"viewer", "admin", "editor"}
    print(f"sorted(roles)      -> {sorted(roles)}")

    print("\n=== set → tuple ===")
    t = tuple(sorted(roles))
    print(f"tuple(sorted(set)) -> {t}")

    print("\n=== Deduplicate list preserving order ===")
    with_dups = ["a", "b", "a", "c", "b"]
    seen: set[str] = set()
    deduped = [x for x in with_dups if not (x in seen or seen.add(x))]
    print(f"order-preserving dedup -> {deduped}")

if __name__ == "__main__":
    run()
