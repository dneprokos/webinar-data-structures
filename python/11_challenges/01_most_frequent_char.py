"""
Challenge: Find the most frequent character in a string.
Uses a dict frequency map, then sorted or max() to find the winner.

QA relevance: Same pattern finds the most common error message in test logs,
the most-hit API endpoint in access logs, or the most-failing test in CI history.
"""

from __future__ import annotations


def get_most_frequent_char(text: str) -> tuple[str, int]:
    freq: dict[str, int] = {}
    for ch in text:
        freq[ch] = freq.get(ch, 0) + 1
    most_common, count = max(freq.items(), key=lambda kv: kv[1])
    return most_common, count


def run() -> None:
    print("=== Most frequent character ===")
    phrase = "Beware the whispering winds of the Wandering Wastes"
    char, count = get_most_frequent_char(phrase)
    print(f'Input: "{phrase}"')
    print(f"Most frequent: {char!r} x {count}")

    print("\n=== QA: Most frequent error in test log ===")
    log_lines = [
        "TimeoutException: element not found",
        "AssertionError: expected 200 got 404",
        "TimeoutException: element not found",
        "NullReferenceException: object not set",
        "AssertionError: expected 200 got 404",
        "TimeoutException: element not found",
        "AssertionError: expected 200 got 404",
        "StaleElementException: element stale",
    ]

    error_types = [line.split(":")[0].strip() for line in log_lines]

    freq: dict[str, int] = {}
    for e in error_types:
        freq[e] = freq.get(e, 0) + 1

    print("Error frequency:")
    for error, n in sorted(freq.items(), key=lambda kv: -kv[1]):
        print(f"  {error:<35} x{n}")

    top_error, top_count = max(freq.items(), key=lambda kv: kv[1])
    print(f"\nMost common error: {top_error} ({top_count} occurrences)")


if __name__ == "__main__":
    run()
