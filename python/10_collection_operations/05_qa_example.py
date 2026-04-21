"""Collection operations applied to QA automation in Python."""
from __future__ import annotations
from dataclasses import dataclass
from itertools import groupby

@dataclass
class TestResult:
    id: str
    name: str
    status: str
    duration_ms: int
    category: str

RESULTS = [
    TestResult("TC001", "login_happy_path",     "pass", 245, "Login"),
    TestResult("TC002", "login_wrong_password", "pass", 120, "Login"),
    TestResult("TC003", "checkout_empty_cart",  "fail", 380, "Checkout"),
    TestResult("TC004", "checkout_valid",       "pass",  95, "Checkout"),
    TestResult("TC005", "search_no_results",    "fail", 560, "Search"),
    TestResult("TC006", "search_with_filter",   "pass", 210, "Search"),
    TestResult("TC007", "profile_update",       "fail", 430, "Profile"),
    TestResult("TC008", "api_auth",             "pass", 180, "API"),
    TestResult("TC009", "api_data",             "pass", 200, "API"),
    TestResult("TC010", "api_rate_limit",       "fail", 670, "API"),
]

def run() -> None:
    print("=== Filter failed tests ===")
    failed = sorted([r for r in RESULTS if r.status == "fail"], key=lambda r: r.category)
    for r in failed:
        print(f"  ✗ [{r.id}] {r.name:<30} ({r.category})")

    print("\n=== Pass rate by category ===")
    by_cat = sorted(RESULTS, key=lambda r: r.category)
    for cat, group in groupby(by_cat, key=lambda r: r.category):
        items = list(group)
        passed = sum(1 for r in items if r.status == "pass")
        avg = sum(r.duration_ms for r in items) / len(items)
        print(f"  {cat:<10} {passed}/{len(items)} ({passed/len(items)*100:.0f}%)  avg={avg:.0f}ms")

    overall = sum(1 for r in RESULTS if r.status == "pass") / len(RESULTS) * 100
    print(f"  Overall: {overall:.0f}%")

    print("\n=== Paginate results (page size = 3) ===")
    sorted_results = sorted(RESULTS, key=lambda r: r.id)
    page_size = 3
    for i in range(0, len(sorted_results), page_size):
        page = sorted_results[i:i+page_size]
        print(f"  Page {i//page_size+1}: [{', '.join(r.id for r in page)}]")

    print("\n=== Slow tests (>= 400ms) ===")
    slow = sorted([r for r in RESULTS if r.duration_ms >= 400], key=lambda r: -r.duration_ms)
    for r in slow:
        print(f"  [{r.id}] {r.name:<30} {r.duration_ms}ms  {r.status}")

if __name__ == "__main__":
    run()
