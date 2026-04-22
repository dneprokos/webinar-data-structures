"""Stack using Python's standard-library queue.LifoQueue (thread-safe LIFO)."""
from __future__ import annotations
from queue import LifoQueue

def run() -> None:
    print("=== Empty LifoQueue ===")
    stack: LifoQueue[int] = LifoQueue()
    print(f"LifoQueue()            -> empty={stack.empty()}, size={stack.qsize()}")

    print("\n=== Build by pushing ===")
    for v in (101, 102, 103):
        stack.put(v)
    print(f"after put 101,102,103  -> size={stack.qsize()}")

    print("\n=== Peek top (get + put back) ===")
    top = stack.get()
    stack.put(top)
    print(f"top                    -> {top}")

    print("\n=== Pop all (LIFO order) ===")
    while not stack.empty():
        print(f"  get() -> {stack.get()}")

    print("\n=== Bounded stack (maxsize) ===")
    bounded: LifoQueue[str] = LifoQueue(maxsize=2)
    bounded.put("first")
    bounded.put("second")
    print(f"maxsize=2, full={bounded.full()}")
    print(f"  get() -> {bounded.get()}  (LIFO: second out first)")

if __name__ == "__main__":
    run()
