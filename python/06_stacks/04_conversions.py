"""Converting stacks (lists) to/from other types in Python."""
from __future__ import annotations

def run() -> None:
    print("=== Stack (list) → reversed list ===")
    stack = [1, 2, 3]
    reversed_list = list(reversed(stack))
    print(f"list(reversed(stack)) -> {reversed_list}  (top first)")

    print("\n=== Reverse a sequence using a stack ===")
    original = [1, 2, 3, 4, 5]
    temp = list(original)
    result = []
    while temp:
        result.append(temp.pop())
    print(f"Original:  {original}")
    print(f"Reversed:  {result}")

    print("\n=== Stack → tuple (snapshot) ===")
    snapshot = tuple(reversed(stack))
    print(f"tuple(reversed(stack)) -> {snapshot}")

if __name__ == "__main__":
    run()
