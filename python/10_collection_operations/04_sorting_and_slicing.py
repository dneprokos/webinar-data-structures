"""Sorting and slicing in Python: sorted(), slices, groupby."""
from __future__ import annotations
from itertools import groupby

def run() -> None:
    scores = [55, 92, 81, 40, 88]
    employees = [
        {"name": "Ann",   "dept": "QA",  "salary": 90_000},
        {"name": "Bob",   "dept": "Dev", "salary": 80_000},
        {"name": "Carl",  "dept": "QA",  "salary": 70_000},
        {"name": "Diana", "dept": "Dev", "salary": 85_000},
    ]

    print("=== sorted (non-mutating) ===")
    print(f"sorted asc:          {sorted(scores)}")
    print(f"sorted desc:         {sorted(scores, reverse=True)}")
    print(f"original unchanged:  {scores}")

    print("\n=== Sort by key ===")
    by_salary = sorted(employees, key=lambda e: e["salary"], reverse=True)
    for e in by_salary:
        print(f"  {e['name']:<8} ${e['salary']:,}")

    print("\n=== Multi-key sort ===")
    multi = sorted(employees, key=lambda e: (e["dept"], -e["salary"]))
    for e in multi:
        print(f"  {e['dept']:<5} {e['name']:<8} ${e['salary']:,}")

    print("\n=== Slicing (Skip/Take equivalent) ===")
    s = sorted(scores)
    page_size = 2
    for page in range(0, len(s), page_size):
        print(f"  Page {page//page_size+1}: {s[page:page+page_size]}")

    print("\n=== itertools.groupby ===")
    sorted_by_dept = sorted(employees, key=lambda e: e["dept"])
    for dept, group in groupby(sorted_by_dept, key=lambda e: e["dept"]):
        names = [e["name"] for e in group]
        print(f"  {dept}: {names}")

if __name__ == "__main__":
    run()
