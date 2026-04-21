"""Converting Python dicts to/from other types."""
from __future__ import annotations

def run() -> None:
    print("=== list of tuples → dict ===")
    pairs = [("a", 1), ("b", 2), ("c", 3)]
    d = dict(pairs)
    print(f"dict(pairs)          -> {d}")

    print("\n=== dict → list of tuples ===")
    env = {"BASE_URL": "https://api.example.com", "TIMEOUT": "30"}
    pairs2 = list(env.items())
    print(f"dict.items()         -> {pairs2}")

    print("\n=== dict → sorted keys list ===")
    d2 = {"b": 2, "a": 1, "c": 3}
    print(f"sorted(d.keys())     -> {sorted(d2.keys())}")

    print("\n=== GroupBy → dict of lists ===")
    results = [("Ann", "pass"), ("Bob", "fail"), ("Carl", "pass"), ("Dan", "fail")]
    by_status: dict[str, list[str]] = {}
    for name, status in results:
        by_status.setdefault(status, []).append(name)
    for status, names in sorted(by_status.items()):
        print(f"  {status}: {names}")

if __name__ == "__main__":
    run()
