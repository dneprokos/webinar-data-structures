"""Typed generic-style response (typing.Generic) — same idea as RestResponse[T]."""

from __future__ import annotations

from dataclasses import dataclass
from typing import Generic, TypeVar

T = TypeVar("T")


@dataclass
class RestResponse(Generic[T]):
    status: int
    body: T


@dataclass
class UserDto:
    id: str
    name: str


if __name__ == "__main__":
    users = RestResponse(
        200,
        [UserDto("ann", "Ann"), UserDto("bob", "Bob")],
    )
    print(f"{users.status}: {len(users.body)} users")
