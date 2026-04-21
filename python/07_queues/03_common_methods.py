"""Enqueue (append), dequeue (popleft), and FIFO demonstration."""
from __future__ import annotations
from collections import deque

def run() -> None:
    print("=== Enqueue (append), Dequeue (popleft) ===")
    q: deque[str] = deque()
    q.append("a"); q.append("b"); q.append("c")
    print(f"after append a,b,c    -> len={len(q)}, front={q[0]!r}")
    first = q.popleft()
    print(f"popleft()              = {first!r}  len={len(q)}")

    print("\n=== appendleft / pop (double-ended) ===")
    dq: deque[int] = deque([1, 2, 3])
    dq.appendleft(0)
    print(f"appendleft(0)         -> {list(dq)}")
    dq.pop()
    print(f"pop() from right      -> {list(dq)}")

    print("\n=== Clear ===")
    q.clear()
    print(f"clear()               -> {list(q)}")

    print("\n=== FIFO demonstration ===")
    fifo: deque[str] = deque(["first", "second", "third"])
    print("Dequeue order (FIFO):  ", end="")
    while fifo:
        print(fifo.popleft(), end=" ")
    print()

if __name__ == "__main__":
    run()
