"""Aggregation in Python: sum, min, max, len, functools.reduce."""
from __future__ import annotations
from functools import reduce

scores = [55, 92, 81, 40, 88]

def run() -> None:
    print("=== Basic aggregates ===")
    print(f"len:         {len(scores)}")
    print(f"sum:         {sum(scores)}")
    print(f"min:         {min(scores)}")
    print(f"max:         {max(scores)}")
    print(f"average:     {sum(scores)/len(scores):.1f}")

    print("\n=== Conditional aggregates ===")
    print(f"count >= 80: {sum(1 for s in scores if s >= 80)}")
    print(f"sum >= 80:   {sum(s for s in scores if s >= 80)}")
    print(f"avg >= 80:   {sum(s for s in scores if s >= 80) / sum(1 for s in scores if s >= 80):.1f}")

    print("\n=== min/max with key ===")
    employees = [{"name": "Ann", "salary": 90_000}, {"name": "Bob", "salary": 70_000}, {"name": "Carl", "salary": 85_000}]
    top_earner = max(employees, key=lambda e: e["salary"])
    lowest = min(employees, key=lambda e: e["salary"])
    print(f"max salary:  {top_earner['name']} ${top_earner['salary']:,}")
    print(f"min salary:  {lowest['name']} ${lowest['salary']:,}")

    print("\n=== functools.reduce (fold) ===")
    product = reduce(lambda acc, s: acc * s, scores, 1)
    print(f"product of all: {product}")
    csv = reduce(lambda acc, s: f"{acc},{s}" if acc else str(s), [e["name"] for e in employees], "")
    print(f"names as CSV:   {csv!r}")

if __name__ == "__main__":
    run()
