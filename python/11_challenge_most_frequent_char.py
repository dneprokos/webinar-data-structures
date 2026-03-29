"""Dict frequencies + sort — most frequent character (Python article challenge)."""

from __future__ import annotations

if __name__ == "__main__":
    arcane_phrase = "Beware the whispering winds of the Wandering Wastes"

    char_frequency: dict[str, int] = {}
    for char in arcane_phrase:
        char_frequency[char] = char_frequency.get(char, 0) + 1

    char_frequency_sorted = sorted(
        char_frequency.items(),
        key=lambda kv: kv[1],
        reverse=True,
    )
    most_common_rune, frequency = char_frequency_sorted[0]
    print(f"'{most_common_rune}' x {frequency}")
