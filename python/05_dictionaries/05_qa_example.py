"""Practical QA automation examples using Python dicts."""
from __future__ import annotations
from enum import Enum

class SqlOperator(Enum):
    EQUALS = "equals"; LIKE = "like"; IN = "in"; GREATER_THAN = "gt"

SQL_MAP: dict[SqlOperator, str] = {
    SqlOperator.EQUALS: "=", SqlOperator.LIKE: "LIKE",
    SqlOperator.IN: "IN", SqlOperator.GREATER_THAN: ">",
}

def build_predicate(column: str, op: SqlOperator, value: str) -> str:
    return f"{column} {SQL_MAP[op]} {value}"

def run() -> None:
    print("=== SQL operator map ===")
    predicates = [
        build_predicate("email", SqlOperator.LIKE, "%@test.com"),
        build_predicate("status", SqlOperator.EQUALS, "'active'"),
        build_predicate("age", SqlOperator.GREATER_THAN, "18"),
    ]
    for p in predicates:
        print(f"  WHERE {p}")

    print("\n=== Config-driven test parameters ===")
    test_config = {
        "BASE_URL": "https://staging.example.com",
        "API_KEY": "test-key-abc123",
        "TIMEOUT_SEC": "30",
        "RETRY_COUNT": "3",
    }
    for key, value in sorted(test_config.items()):
        print(f"  {key:<15} = {value}")
    timeout = int(test_config.get("TIMEOUT_SEC", "10"))
    print(f"Parsed timeout: {timeout}s")

    print("\n=== Aggregate test results ===")
    results = [
        ("Login test", "pass"), ("Checkout test", "fail"),
        ("Search test", "pass"), ("Profile test", "fail"),
        ("API auth test", "pass"), ("API data test", "pass"),
    ]
    by_status: dict[str, int] = {}
    for _, status in results:
        by_status[status] = by_status.get(status, 0) + 1
    for status, count in sorted(by_status.items()):
        print(f"  {status:<6} = {count}")
    pass_rate = by_status.get("pass", 0) / len(results) * 100
    print(f"Pass rate: {pass_rate:.0f}%")

if __name__ == "__main__":
    run()
