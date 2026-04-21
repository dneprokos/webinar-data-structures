"""Practical QA automation examples using Python lists."""

from __future__ import annotations

from dataclasses import dataclass


@dataclass
class OrderRow:
    code: str
    amount: float


@dataclass
class TestResult:
    name: str
    status: str


def run() -> None:
    print("=== Validate API response row count ===")
    api_records = [OrderRow("A", 10), OrderRow("B", 20), OrderRow("C", 30)]
    print(f"Count == 0?  {len(api_records) == 0}")
    print(f"Count >= 3?  {len(api_records) >= 3}")
    print(f"Any >= 25?   {any(r.amount >= 25 for r in api_records)}")
    found = next((r for r in api_records if r.code == "B"), None)
    print(f"Find code B: {found}")

    all_unique = len(api_records) == len({r.code for r in api_records})
    print(f"All codes unique: {all_unique}")

    print("\n=== Collect and analyze test results ===")
    results = [
        TestResult("Login happy path", "pass"),
        TestResult("Login wrong password", "pass"),
        TestResult("Checkout empty cart", "fail"),
        TestResult("Search no results", "pass"),
        TestResult("Profile update", "fail"),
    ]
    passed = [r for r in results if r.status == "pass"]
    failed = [r for r in results if r.status == "fail"]
    print(f"Total: {len(results)}  Passed: {len(passed)}  Failed: {len(failed)}")
    print("Failed tests:")
    for r in failed:
        print(f"  ✗ {r.name}")
    pass_rate = len(passed) / len(results) * 100
    print(f"Pass rate: {pass_rate:.0f}%")

    print("\n=== Build dynamic test case list ===")
    test_cases = [
        f"{feature}@{env}"
        for feature in ["login", "checkout", "profile"]
        for env in ["staging"]
    ]
    print(f"Generated {len(test_cases)} test cases:")
    for tc in test_cases:
        print(f"  {tc}")


if __name__ == "__main__":
    run()
