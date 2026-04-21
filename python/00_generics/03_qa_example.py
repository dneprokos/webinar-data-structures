"""
Generic API response wrapper used in QA automation frameworks.
A single typed envelope works for any API endpoint.
"""

from __future__ import annotations

from dataclasses import dataclass, field
from typing import Callable, Generic, TypeVar

T = TypeVar("T")


# ── Generic response envelope ─────────────────────────────────────────────────

@dataclass
class ApiResponse(Generic[T]):
    status: int
    body: T

    @property
    def is_ok(self) -> bool:
        return 200 <= self.status < 300


# ── Domain DTOs ───────────────────────────────────────────────────────────────

@dataclass
class UserDto:
    id: str
    name: str
    role: str


@dataclass
class OrderDto:
    id: str
    total: float


# ── Generic assertion helpers ─────────────────────────────────────────────────

def assert_status(response: ApiResponse[T], expected: int) -> None:
    if response.status != expected:
        raise AssertionError(f"Expected {expected} but got {response.status}")


def assert_not_empty(collection: list[T], name: str = "collection") -> None:
    if not collection:
        raise AssertionError(f"{name} must not be empty")


def find_first(items: list[T], predicate: Callable[[T], bool]) -> T | None:
    return next((x for x in items if predicate(x)), None)


# ── Generic test data factory ─────────────────────────────────────────────────

def create_many(count: int, factory: Callable[[int], T]) -> list[T]:
    """Create `count` instances using a factory function receiving the index."""
    return [factory(i) for i in range(1, count + 1)]


# ── Simulate HTTP calls ───────────────────────────────────────────────────────

def api_call(endpoint: str, status: int, body: T) -> ApiResponse[T]:
    print(f"  [HTTP] {endpoint}")
    return ApiResponse(status, body)


# ── Run ───────────────────────────────────────────────────────────────────────

def run() -> None:
    print("=== Typed API response wrapper ===")

    users_resp = api_call(
        "/api/users", 200,
        [UserDto("u1", "Ann", "admin"), UserDto("u2", "Bob", "viewer")],
    )
    order_resp = api_call("/api/orders/1", 200, OrderDto("o1", 199.99))

    print(f"GET /api/users    -> {users_resp.status}, {len(users_resp.body)} users")
    print(f"GET /api/orders/1 -> {order_resp.status}, order {order_resp.body.id} = ${order_resp.body.total}")

    assert_status(users_resp, 200)
    assert_status(order_resp, 200)
    print("Both status assertions passed")

    print("\n=== Generic assertion helpers ===")
    assert_not_empty(users_resp.body, "users list")
    print("assert_not_empty passed")

    found = find_first(users_resp.body, lambda u: u.role == "viewer")
    print(f"find_first(role=viewer) = {found}")

    print("\n=== Generic test data factory ===")
    test_users = create_many(3, lambda i: UserDto(f"u{i}", f"User{i}", "viewer"))
    for u in test_users:
        print(f"  {u.id}: {u.name} ({u.role})")


if __name__ == "__main__":
    run()
