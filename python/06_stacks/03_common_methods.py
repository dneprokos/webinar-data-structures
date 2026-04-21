"""Push, pop, peek, and LIFO demonstration for Python stacks."""
from __future__ import annotations

def run() -> None:
    print("=== Push (append), Pop, Peek ===")
    stack: list[int] = []
    stack.append(1); stack.append(2); stack.append(3)
    print(f"after append 1,2,3    -> top={stack[-1]}, len={len(stack)}")
    popped = stack.pop()
    print(f"pop()                  = {popped}  len={len(stack)}")

    print("\n=== Safe peek ===")
    top = stack[-1] if stack else None
    print(f"top = {top!r}")

    print("\n=== Clear ===")
    stack.clear()
    print(f"clear()               -> {stack}")

    print("\n=== LIFO demonstration ===")
    lifo: list[str] = []
    for s in ("first", "second", "third"):
        lifo.append(s)
    print("Pop order (LIFO):     ", end="")
    while lifo:
        print(lifo.pop(), end=" ")
    print()

if __name__ == "__main__":
    run()
