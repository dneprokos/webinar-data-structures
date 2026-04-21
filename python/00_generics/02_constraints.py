"""TypeVar constraints in Python: bound= and positional constraint arguments."""

from __future__ import annotations

from dataclasses import dataclass
from typing import Generic, Protocol, TypeVar

# ── bound= : T must be a subtype of the bound ────────────────────────────────

class HasId(Protocol):
    """Structural interface — any class with .id: str satisfies this."""
    id: str


TEntity = TypeVar("TEntity", bound=HasId)


def format_id(dto: TEntity) -> str:
    """Equivalent to C# FormatId<T>(T dto) where T : IHasId."""
    return f"{type(dto).__name__} id={dto.id}"


@dataclass
class UserDto:
    id: str
    name: str


@dataclass
class ProductDto:
    id: str
    title: str


# ── Positional constraints: T must be one of the listed types ─────────────────

TNum = TypeVar("TNum", int, float)


def add_numbers(a: TNum, b: TNum) -> TNum:
    """Only int or float allowed — equivalent to C# 'where T : struct' union."""
    return a + b  # type: ignore[operator]


# ── bound=Scored — must have a .score attribute ───────────────────────────────

class Scored(Protocol):
    score: int


TScored = TypeVar("TScored", bound=Scored)


def pick_higher(a: TScored, b: TScored) -> TScored:
    """Return the item with the higher score."""
    return a if a.score >= b.score else b


@dataclass
class RunResult:
    name: str
    score: int


# ── Generic class with bound ──────────────────────────────────────────────────

TBody = TypeVar("TBody", bound=object)


@dataclass
class RestResponse(Generic[TBody]):
    status: int
    body: TBody


# ── Run ───────────────────────────────────────────────────────────────────────

def run() -> None:
    print("=== bound=HasId (Protocol — structural interface) ===")
    print(format_id(UserDto("u1", "Ann")))
    print(format_id(ProductDto("p99", "Mug")))

    print("\n=== TypeVar('TNum', int, float) — union constraint ===")
    print(f"add_numbers(10, 25)    = {add_numbers(10, 25)}")
    print(f"add_numbers(1.5, 2.5)  = {add_numbers(1.5, 2.5)}")

    print("\n=== bound=Scored (pick by score) ===")
    winner = pick_higher(RunResult("a", 80), RunResult("b", 90))
    print(f"pick_higher(80, 90)    = {winner}")

    print("\n=== RestResponse[TBody] with bound=object ===")
    users = RestResponse(200, [UserDto("ann", "Ann"), UserDto("bob", "Bob")])
    print(f"{users.status}: {len(users.body)} users")


if __name__ == "__main__":
    run()
