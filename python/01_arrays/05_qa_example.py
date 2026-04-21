"""
Practical QA automation examples using Python lists.

Scenarios:
- Build URL query strings from parameter lists
- Parse CSV test data into typed records
- Validate API response has no duplicate IDs
- Generate parameterized test inputs
"""

from __future__ import annotations

from dataclasses import dataclass


@dataclass
class TestUser:
    email: str
    role: str
    status: str


def build_query_string(ids: list[int]) -> str:
    return "?ids=" + ",".join(str(i) for i in ids)


def parse_csv_test_data(csv_lines: list[str]) -> list[TestUser]:
    users = []
    for line in csv_lines:
        parts = line.split(",")
        users.append(TestUser(email=parts[0], role=parts[1], status=parts[2]))
    return users


def has_duplicate_ids(ids: list[str]) -> bool:
    return len(ids) != len(set(ids))


def find_duplicated_ids(ids: list[str]) -> list[str]:
    seen: set[str] = set()
    duplicates: list[str] = []
    for id_ in ids:
        if id_ in seen and id_ not in duplicates:
            duplicates.append(id_)
        seen.add(id_)
    return duplicates


def generate_test_combinations(environments: list[str], roles: list[str]) -> list[dict[str, str]]:
    return [{"environment": env, "role": role} for env in environments for role in roles]


def run() -> None:
    print("=== Build URL query string ===")
    ids = [2, 5, 7, 12]
    print(f"IDs: {ids}")
    print(f"URL: https://api.example.com/users{build_query_string(ids)}")

    print("\n=== Parse CSV test data ===")
    csv_lines = [
        "alice@test.com,admin,active",
        "bob@test.com,viewer,inactive",
        "charlie@test.com,editor,active",
    ]
    users = parse_csv_test_data(csv_lines)
    print(f"Parsed {len(users)} users:")
    for u in users:
        print(f"  {u.email:<25} role={u.role:<8} status={u.status}")

    print("\n=== Validate no duplicate IDs in API response ===")
    response_ids = ["u1", "u2", "u3", "u4"]
    print(f"Has duplicates: {has_duplicate_ids(response_ids)}")
    print("PASS: all IDs are unique" if not has_duplicate_ids(response_ids) else "FAIL")

    ids_with_dup = ["u1", "u2", "u2", "u3"]
    duplicated = find_duplicated_ids(ids_with_dup)
    print(f"Duplicated IDs in bad response: {duplicated}")

    print("\n=== Generate parameterized test combinations ===")
    test_cases = generate_test_combinations(["staging", "production"], ["admin", "viewer"])
    print(f"Generated {len(test_cases)} combinations:")
    for tc in test_cases:
        print(f"  env={tc['environment']:<12} role={tc['role']}")


if __name__ == "__main__":
    run()
