"""Dict: SQL operator map and in-run lookup (Python article + C# article)."""

from __future__ import annotations

from enum import Enum


class SqlOperator(Enum):
    EQUALS = "equals"
    LIKE = "like"
    IN = "in"


SQL_BY_OP: dict[SqlOperator, str] = {
    SqlOperator.EQUALS: "=",
    SqlOperator.LIKE: "LIKE",
    SqlOperator.IN: "IN",
}


def build_predicate(column: str, op: SqlOperator, value: str) -> str:
    return f"{column} {SQL_BY_OP[op]} {value}"


if __name__ == "__main__":
    print(build_predicate("email", SqlOperator.LIKE, "%@test.com"))

    book_prices = {"Clean Code": 42.5, "Refactoring": 39.0}
    key = next((k for k in book_prices if k.lower() == "clean code"), None)
    print(book_prices[key] if key else 0)
