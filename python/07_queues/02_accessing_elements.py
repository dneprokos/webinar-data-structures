"""Reading from a Python deque queue."""
from __future__ import annotations
from collections import deque

def run() -> None:
    q: deque[str] = deque(["first", "second", "third"])

    print("=== Peek front without removing ===")
    print(f"q[0]               = {q[0]!r}")
    print(f"len after peek     = {len(q)}  (unchanged)")

    print("\n=== Contains ===")
    print(f'"second" in q      = {"second" in q}')
    print(f'"missing" in q     = {"missing" in q}')

    print("\n=== Iteration (front → back) ===")
    for item in q:
        print(f"  {item!r}")

if __name__ == "__main__":
    run()
