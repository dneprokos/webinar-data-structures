"""Creating stacks in Python using list (append/pop)."""
from __future__ import annotations

def run() -> None:
    print("=== Empty stack ===")
    stack: list[int] = []
    print(f"[]                     -> len={len(stack)}")

    print("\n=== Build by pushing ===")
    for v in (101, 102, 103):
        stack.append(v)
    print(f"after push 101,102,103 -> top={stack[-1]}, len={len(stack)}")

    print("\n=== Stack from list ===")
    s2: list[str] = list(["a", "b", "c"])
    print(f"list(['a','b','c'])     -> top={s2[-1]}")

if __name__ == "__main__":
    run()
