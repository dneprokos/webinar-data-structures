"""Queue FIFO: collections.deque (Python article)."""

from __future__ import annotations

from collections import deque

if __name__ == "__main__":
    jobs: deque[str] = deque()
    jobs.append("sync-users")
    jobs.append("purge-cache")
    jobs.append("notify-slack")

    while jobs:
        print("processing:", jobs.popleft())
