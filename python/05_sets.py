"""Set: uniqueness when merging several sources (Python article)."""

from __future__ import annotations

if __name__ == "__main__":
    from_api = [1, 2, 3, 3]
    from_db = [3, 4, 5]
    merged = set(from_api) | set(from_db)
    print(", ".join(str(x) for x in sorted(merged)))

    a = {"fail", "pass", "skip"}
    b = {"pass", "warn"}
    print("intersection:", ", ".join(sorted(a & b)))
