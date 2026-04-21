"""Set operations in Python: union, intersection, difference, etc."""
from __future__ import annotations

def run() -> None:
    print("=== Add & Remove ===")
    s = {1, 2, 3}
    s.add(4)
    print(f"add(4)              -> {sorted(s)}")
    s.add(2)
    print(f"add(2) duplicate    -> {sorted(s)}  (no change)")
    s.discard(1)
    print(f"discard(1)          -> {sorted(s)}")
    s.discard(99)
    print(f"discard(99) safe    -> {sorted(s)}  (no error if missing)")

    print("\n=== Set operations ===")
    a = {1, 2, 3, 4}
    b = {3, 4, 5, 6}
    print(f"union     a | b     -> {sorted(a | b)}")
    print(f"intersect a & b     -> {sorted(a & b)}")
    print(f"diff      a - b     -> {sorted(a - b)}")
    print(f"sym diff  a ^ b     -> {sorted(a ^ b)}")

    print("\n=== Subset / Superset ===")
    full = {"fail", "pass", "skip", "warn"}
    sub = {"fail", "pass"}
    print(f"sub.issubset(full)      = {sub.issubset(full)}")
    print(f"full.issuperset(sub)    = {full.issuperset(sub)}")
    print(f"full.isdisjoint({'x','y'}) = {full.isdisjoint({'x','y'})}")

if __name__ == "__main__":
    run()
