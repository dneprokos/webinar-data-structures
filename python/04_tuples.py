"""Tuple return: user summary + orders without a full class (or use NamedTuple)."""

from __future__ import annotations

from dataclasses import dataclass


@dataclass
class UserSummary:
    id: str
    name: str


def get_user_with_orders(user_id: str) -> tuple[UserSummary, list[str]]:
    return UserSummary(user_id, "Ann"), ["o1", "o2"]


if __name__ == "__main__":
    user, orders = get_user_with_orders("u1")
    print(f"{user.name} has {len(orders)} orders")
