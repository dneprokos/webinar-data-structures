"""List comprehensions / map / filter — parallel to LINQ (Python article)."""

from __future__ import annotations

if __name__ == "__main__":
    scores = [55, 92, 81, 40, 88]
    sum_over_80 = sum(s for s in scores if s > 80)
    print("sum (>80):", sum_over_80)

    employees = [
        {"name": "Ann", "title": "SDET", "salary": 90000},
        {"name": "Bob", "title": "QA", "salary": 70000},
    ]
    print("names:", ", ".join(e["name"] for e in employees))

    page = sorted(scores, reverse=True)[1:3]
    print("page:", ", ".join(str(x) for x in page))

    items = [
        ("Invisibility Cloak", 10),
        ("Time-Turner", 9),
        ("Elder Wand", 12),
    ]
    prices = [item[1] for item in items]
    print("prices:", prices)
