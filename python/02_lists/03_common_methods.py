"""Add, remove, sort, and other common list operations in Python."""

from __future__ import annotations


def run() -> None:
    print("=== Add & Remove ===")
    lst = ["a", "b", "c"]
    lst.append("d")
    print(f"append('d')      -> {lst}")
    lst.extend(["e", "f"])
    print(f"extend(['e','f'])-> {lst}")
    lst.insert(1, "X")
    print(f"insert(1,'X')    -> {lst}")
    lst.remove("X")
    print(f"remove('X')      -> {lst}")
    popped = lst.pop()
    print(f"pop()            -> removed {popped!r}, list={lst}")
    lst2 = [x for x in lst if x != "b"]
    print(f"remove all 'b'   -> {lst2}")
    lst.clear()
    print(f"clear()          -> {lst}")

    print("\n=== Sort ===")
    nums = [3, 1, 4, 1, 5]
    nums.sort()
    print(f"sort() in-place  -> {nums}")
    names = ["Zebra", "apple", "Mango"]
    print(f"sorted(key=lower)-> {sorted(names, key=str.lower)}")

    print("\n=== Aggregates & checks ===")
    scores = [55, 92, 81, 40, 88]
    print(f"len              = {len(scores)}")
    print(f"sum              = {sum(scores)}")
    print(f"min / max        = {min(scores)} / {max(scores)}")
    print(f"any(> 90)        = {any(s > 90 for s in scores)}")
    print(f"all(> 0)         = {all(s > 0 for s in scores)}")


if __name__ == "__main__":
    run()
