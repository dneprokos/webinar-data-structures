"""Converting queues (deque) to/from other types in Python."""
from __future__ import annotations
from collections import deque

def run() -> None:
    print("=== deque → list (front first) ===")
    q: deque[int] = deque([1, 2, 3])
    lst = list(q)
    print(f"list(deque)           -> {lst}")

    print("\n=== list → deque ===")
    from_list: deque[str] = deque(["sync", "purge", "notify"])
    print(f"deque(['sync',...])   -> front={from_list[0]!r}")

    print("\n=== Process all and collect results ===")
    jobs: deque[str] = deque(["job1", "job2", "job3"])
    results = []
    while jobs:
        results.append(f"done:{jobs.popleft()}")
    print(f"results               -> {results}")

if __name__ == "__main__":
    run()
