"""Add, update, remove, merge, and frequency map operations on Python dicts."""
from __future__ import annotations

def run() -> None:
    print("=== Add & Update ===")
    d: dict[str, int] = {}
    d["a"] = 1; d["b"] = 2
    print(f"after add a,b         -> {d}")
    d["a"] = 99
    print(f"update a=99           -> d['a']={d['a']}")
    d.setdefault("c", 3)
    print(f"setdefault c=3        -> {d}")
    d.setdefault("c", 999)
    print(f"setdefault c=999      -> c={d['c']}  (no change)")

    print("\n=== Remove ===")
    d2 = {"x": 1, "y": 2, "z": 3}
    del d2["y"]
    print(f"del d['y']            -> {d2}")
    popped = d2.pop("z", None)
    print(f"pop('z')              -> removed {popped}, dict={d2}")
    d2.clear()
    print(f"clear()               -> {d2}")

    print("\n=== Merge ===")
    d1 = {"a": 1, "b": 2}
    d2b = {"b": 99, "c": 3}
    merged = {**d1, **d2b}  # d2b wins on conflict
    print(f"{{**d1, **d2}}          -> {merged}")
    d1.update(d2b)
    print(f"d1.update(d2)         -> {d1}")

    print("\n=== Frequency map ===")
    words = ["api", "smoke", "api", "regression", "smoke", "api"]
    freq: dict[str, int] = {}
    for w in words:
        freq[w] = freq.get(w, 0) + 1
    for word, count in sorted(freq.items(), key=lambda kv: -kv[1]):
        print(f"  {word:<12} x{count}")

if __name__ == "__main__":
    run()
