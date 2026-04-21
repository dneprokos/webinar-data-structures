"""Practical QA automation examples using Python stacks."""
from __future__ import annotations

def run() -> None:
    print("=== Browser navigation history ===")
    history: list[str] = []
    for url in ["https://example.com", "https://example.com/products", "https://example.com/products/42"]:
        history.append(url)
    print(f"Current page: {history[-1]!r}")
    history.pop()
    print(f"After Back:   {history[-1]!r}")
    history.pop()
    print(f"After Back:   {history[-1]!r}")

    print("\n=== Client resource pool ===")
    pool: list[int] = []
    for cid in (101, 102, 103):
        pool.append(cid)
    print(f"Pool size: {len(pool)}")
    client1 = pool.pop()
    print(f"Test 1 acquired client {client1}, pool: {len(pool)}")
    client2 = pool.pop()
    print(f"Test 2 acquired client {client2}, pool: {len(pool)}")
    pool.append(client1)
    pool.append(client2)
    print(f"Clients returned. Pool size: {len(pool)}")

    print("\n=== Undo-redo simulation ===")
    undo_stack: list[str] = []
    redo_stack: list[str] = []

    def do_action(action: str) -> None:
        print(f"  Do: {action}")
        undo_stack.append(action)
        redo_stack.clear()

    def undo() -> None:
        if undo_stack:
            action = undo_stack.pop()
            redo_stack.append(action)
            print(f"  Undo: {action}")

    def redo() -> None:
        if redo_stack:
            action = redo_stack.pop()
            undo_stack.append(action)
            print(f"  Redo: {action}")

    do_action("type 'admin' in username")
    do_action("type 'pass' in password")
    do_action("click login")
    undo(); undo(); redo()
    print(f"Undo: {len(undo_stack)}, Redo: {len(redo_stack)}")

if __name__ == "__main__":
    run()
