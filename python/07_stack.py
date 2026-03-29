"""Stack LIFO: list as stack (append/pop) — client pool pattern."""

from __future__ import annotations

if __name__ == "__main__":
    pool: list[int] = []
    for cid in (101, 102, 103):
        pool.append(cid)

    taken = pool.pop()
    print(f"Test uses client {taken}; pool left: {len(pool)}")
    pool.append(taken)
    print(f"Returned client; pool size: {len(pool)}")
