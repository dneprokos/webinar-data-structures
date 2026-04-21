"""Membership testing and iterating Python sets."""
from __future__ import annotations

def run() -> None:
    print("=== Membership test O(1) ===")
    allowed = {"admin", "editor", "viewer"}
    print(f'"admin" in allowed   = {"admin" in allowed}')
    print(f'"hacker" in allowed  = {"hacker" in allowed}')

    print("\n=== Iterating (no guaranteed order) ===")
    for role in sorted(allowed):
        print(f"  {role}")

    print("\n=== No index access ===")
    print("(sets have no [i] indexer — use sorted(s) or list(s) for index access)")
    as_list = sorted(allowed)
    print(f"sorted(allowed)[0] = {as_list[0]!r}")

if __name__ == "__main__":
    run()
