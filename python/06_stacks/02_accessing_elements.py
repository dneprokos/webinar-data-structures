"""Reading from a Python list-based stack."""
from __future__ import annotations

def run() -> None:
    stack = ["first", "second", "third"]

    print("=== Peek (read top without removing) ===")
    print(f"stack[-1]              = {stack[-1]!r}")
    print(f"len after peek         = {len(stack)}  (unchanged)")

    print("\n=== Contains ===")
    print(f'"second" in stack      = {"second" in stack}')
    print(f'"missing" in stack     = {"missing" in stack}')

    print("\n=== Iteration (top → bottom) ===")
    for item in reversed(stack):
        print(f"  {item!r}")

    print("\n=== No index access by design ===")
    print("(list supports stack[-1] for peek; use only append/pop for stack semantics)")

if __name__ == "__main__":
    run()
