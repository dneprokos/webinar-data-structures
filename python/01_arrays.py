"""Lists as dynamic arrays: query string + digit sum (Python article / QA patterns)."""

from __future__ import annotations


def build_query_string(ids: list[int]) -> str:
    return "?ids=" + ",".join(str(i) for i in ids)


def sum_digit_characters(text: str) -> int:
    return sum(int(ch) for ch in text if ch.isdigit())


if __name__ == "__main__":
    print(build_query_string([2, 5, 7]))
    print(sum_digit_characters("a1b2c3"))
