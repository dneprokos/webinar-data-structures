"""Filtering sequences in Python: list comprehensions and filter()."""
from __future__ import annotations
from dataclasses import dataclass

@dataclass
class Employee:
    id: str
    name: str
    title: str
    salary: int
    department: str

EMPLOYEES = [
    Employee("e1", "Ann",   "SDET",   90_000, "QA"),
    Employee("e2", "Bob",   "QA",     70_000, "QA"),
    Employee("e3", "Carl",  "DevOps", 85_000, "Ops"),
    Employee("e4", "Diana", "SDET",   95_000, "QA"),
    Employee("e5", "Eve",   "Dev",    80_000, "Dev"),
]

def run() -> None:
    print("=== List comprehension with if ===")
    qa = [e for e in EMPLOYEES if e.department == "QA"]
    print(f"Department QA:    {[e.name for e in qa]}")

    high = [e for e in EMPLOYEES if e.salary > 85_000]
    print(f"Salary > 85k:     {[e.name for e in high]}")

    sdet_qa = [e for e in EMPLOYEES if e.title == "SDET" and e.department == "QA"]
    print(f"SDET in QA:       {[e.name for e in sdet_qa]}")

    print("\n=== filter() built-in ===")
    qa2 = list(filter(lambda e: e.department == "QA", EMPLOYEES))
    print(f"filter(dept==QA): {[e.name for e in qa2]}")

    print("\n=== First / any / all ===")
    first_qa = next((e for e in EMPLOYEES if e.department == "QA"), None)
    print(f"first QA:         {first_qa.name if first_qa else None!r}")
    print(f"any salary > 90k: {any(e.salary > 90_000 for e in EMPLOYEES)}")
    print(f"all salary > 50k: {all(e.salary > 50_000 for e in EMPLOYEES)}")

    print("\n=== Distinct values ===")
    depts = sorted(set(e.department for e in EMPLOYEES))
    print(f"unique depts:     {depts}")

if __name__ == "__main__":
    run()
