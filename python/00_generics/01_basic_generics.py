"""Generic classes and functions in Python using typing.Generic and TypeVar."""

from __future__ import annotations

from dataclasses import dataclass
from typing import Generic, TypeVar

# T is our type parameter — like <T> in C# or TypeScript.
T = TypeVar("T")


# ── Generic class ─────────────────────────────────────────────────────────────

@dataclass
class RestResponse(Generic[T]):
    """Typed HTTP response wrapper — same class for any body type."""
    status: int
    body: T


@dataclass
class UserDto:
    id: str
    name: str


@dataclass
class OrderDto:
    id: str
    total: float


# ── Generic function ──────────────────────────────────────────────────────────

def swap(a: T, b: T) -> tuple[T, T]:
    """Return the pair swapped — works for any type."""
    return b, a


def first_or_default(items: list[T], default: T) -> T:
    """Return the first element or a default value if the list is empty."""
    return items[0] if items else default


# ── Run ───────────────────────────────────────────────────────────────────────

def run() -> None:
    print("=== Generic class: RestResponse[T] ===")

    users_resp: RestResponse[list[UserDto]] = RestResponse(
        200, [UserDto("ann", "Ann"), UserDto("bob", "Bob")]
    )
    print(f"Status: {users_resp.status}")
    print(f"Body:   {len(users_resp.body)} users")

    error_resp: RestResponse[str] = RestResponse(400, "Not found")
    print(f"Error:  {error_resp.status} — {error_resp.body}")

    print("\n=== Generic function: swap ===")
    a, b = swap(1, 2)
    print(f"swap(1, 2)  -> a={a}, b={b}")

    x, y = swap("hello", "world")
    print(f"swap(str)   -> x={x!r}, y={y!r}")

    print("\n=== Generic function: first_or_default ===")
    print(f"first([1,2,3], 0) = {first_or_default([1, 2, 3], 0)}")
    print(f"first([], 99)     = {first_or_default([], 99)}")


if __name__ == "__main__":
    run()
