"""Creating dictionaries in Python."""
from __future__ import annotations
from enum import Enum

def run() -> None:
    print("=== Basic dict ===")
    scores = {"Alice": 92, "Bob": 85, "Charlie": 78}
    print(f"inline literal         -> len={len(scores)}")

    print("\n=== Enum key dict ===")
    class SqlOp(Enum):
        EQUALS = "equals"; LIKE = "like"; IN = "in"
    sql_map = {SqlOp.EQUALS: "=", SqlOp.LIKE: "LIKE", SqlOp.IN: "IN"}
    print(f"enum key dict          -> {sql_map[SqlOp.LIKE]!r}")

    print("\n=== Case-insensitive (manual) ===")
    book_prices = {"clean code": 42.5, "refactoring": 39.0}
    key = "Clean Code"
    val = book_prices.get(key.lower(), 0)
    print(f"lookup '{key}'    = {val}")

    print("\n=== Dict comprehension ===")
    squares = {x: x ** 2 for x in range(1, 6)}
    print(f"squares              -> {squares}")

    print("\n=== Nested dict ===")
    nested = {"env1": {"pass": 10, "fail": 2}, "env2": {"pass": 8, "fail": 5}}
    print(f"nested env1.pass     = {nested['env1']['pass']}")

if __name__ == "__main__":
    run()
