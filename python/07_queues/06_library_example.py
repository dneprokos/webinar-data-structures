"""Queue using Python's standard-library queue.Queue (thread-safe FIFO)."""
from __future__ import annotations
from queue import Queue

def run() -> None:
    print("=== Empty Queue ===")
    q: Queue[str] = Queue()
    print(f"Queue()                -> empty={q.empty()}, size={q.qsize()}")

    print("\n=== Build by enqueueing ===")
    for task in ("sync-users", "purge-cache", "notify-slack"):
        q.put(task)
    print(f"after put 3 tasks      -> size={q.qsize()}")

    print("\n=== Dequeue all (FIFO order) ===")
    while not q.empty():
        print(f"  get() -> {q.get()!r}")

    print("\n=== Bounded queue (maxsize) ===")
    bounded: Queue[int] = Queue(maxsize=3)
    for v in range(1, 4):
        bounded.put(v)
    print(f"maxsize=3, full={bounded.full()}")
    print(f"  get() -> {bounded.get()}  (FIFO: 1 out first)")

    print("\n=== vs collections.deque ===")
    print("  queue.Queue       : thread-safe (uses locks); best for multi-threaded producers/consumers")
    print("  collections.deque : single-threaded, faster; best for in-process task loops")

if __name__ == "__main__":
    run()
