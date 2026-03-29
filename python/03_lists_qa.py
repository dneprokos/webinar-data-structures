"""List scenarios: counts and variable-length API payloads."""

from __future__ import annotations

from dataclasses import dataclass


@dataclass
class OrderRow:
    code: str
    amount: float


if __name__ == "__main__":
    found_rows = ["row-a", "row-b"]
    print(f"Count == 0? {len(found_rows) == 0}")
    print(f"Count >= 2? {len(found_rows) >= 2}")

    api_records = [OrderRow("A", 10), OrderRow("B", 20)]
    print(f"API returned {len(api_records)} records (unknown upfront).")
