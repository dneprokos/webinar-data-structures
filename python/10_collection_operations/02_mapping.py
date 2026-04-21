"""Mapping/projection in Python: comprehensions and map()."""
from __future__ import annotations
from dataclasses import dataclass

@dataclass
class Order:
    id: str
    customer_id: str
    items: list[tuple[str, float]]

ORDERS = [
    Order("o1", "c1", [("Laptop", 1200), ("Mouse", 25)]),
    Order("o2", "c2", [("Keyboard", 75)]),
    Order("o3", "c1", [("Monitor", 400), ("Desk", 200)]),
]

def run() -> None:
    scores = [55, 92, 81, 40, 88]

    print("=== List comprehension (map) ===")
    print(f"doubled:      {[s * 2 for s in scores]}")
    print(f"to strings:   {[f's={s}' for s in scores]}")

    print("\n=== map() built-in (lazy) ===")
    doubled = list(map(lambda s: s * 2, scores))
    print(f"map(double):  {doubled}")

    print("\n=== Project to dict ===")
    summaries = [{"id": o.id, "total": sum(p for _, p in o.items)} for o in ORDERS]
    for s in summaries:
        print(f"  {s['id']}: ${s['total']:.0f}")

    print("\n=== Flatten (like SelectMany) ===")
    all_items = [item for o in ORDERS for item, _ in o.items]
    print(f"all item names: {all_items}")

    print("\n=== enumerate (index + value) ===")
    for i, s in enumerate(scores):
        print(f"  [{i}] = {s}")

if __name__ == "__main__":
    run()
