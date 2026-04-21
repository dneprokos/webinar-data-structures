"""Creating queues in Python using collections.deque."""
from __future__ import annotations
from collections import deque

def run() -> None:
    print("=== Empty deque ===")
    empty: deque[int] = deque()
    print(f"deque()                -> len={len(empty)}")

    print("\n=== deque from iterable ===")
    from_list: deque[str] = deque(["a", "b", "c"])
    print(f"deque(['a','b','c'])    -> front={from_list[0]!r}")

    print("\n=== Build by appending ===")
    q: deque[str] = deque()
    q.append("sync-users")
    q.append("purge-cache")
    q.append("notify-slack")
    print(f"after 3 appends        -> len={len(q)}, front={q[0]!r}")

    print("\n=== maxlen — bounded queue ===")
    bounded: deque[int] = deque(maxlen=3)
    for v in range(1, 6):
        bounded.append(v)
    print(f"maxlen=3, after 1..5   -> {list(bounded)}  (oldest dropped)")

if __name__ == "__main__":
    run()
