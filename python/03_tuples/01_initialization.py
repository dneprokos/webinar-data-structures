"""Creating tuples in Python."""

from __future__ import annotations
from typing import NamedTuple


def run() -> None:
    print("=== Basic tuples ===")
    pair = (1, "hello")
    print(f"(int, str):    {pair[0]}, {pair[1]!r}")

    triple = (True, 3.14, "x")
    print(f"(bool,float,str): {triple}")

    print("\n=== Tuple from function ===")
    user, orders = get_user_with_orders("u1")
    print(f"{user.name} has {len(orders)} orders")

    print("\n=== NamedTuple (like named fields in C#) ===")
    point = Point(x=10, y=20)
    print(f"Point(x={point.x}, y={point.y})")

    status = HttpStatus(code=200, message="OK", is_success=True)
    print(f"HTTP: {status.code} {status.message} success={status.is_success}")


class UserSummary(NamedTuple):
    id: str
    name: str


class Point(NamedTuple):
    x: int
    y: int


class HttpStatus(NamedTuple):
    code: int
    message: str
    is_success: bool


def get_user_with_orders(user_id: str) -> tuple[UserSummary, list[str]]:
    return UserSummary(user_id, "Ann"), ["o1", "o2"]


if __name__ == "__main__":
    run()
