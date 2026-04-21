# Tuples

## What Is a Tuple?

A **tuple** is a fixed-size, ordered group of values that can be of different types. Unlike a class or struct, it requires no explicit type declaration — you just bundle values together inline.

Tuples are ideal for returning multiple values from a method without creating a dedicated DTO class, or for grouping short-lived pieces of related data.

## Visual Overview

```
(UserSummary User, List<string> Orders)
     ↑ Item1 / named field          ↑ Item2 / named field
     └──────────────────────────────┘
           returned together
```

## Key Characteristics

| Property | Detail |
|----------|--------|
| Size | Fixed at declaration |
| Types | Each element can be a different type |
| Named fields | Optional but strongly recommended for readability |
| Mutable | Value tuples in C# are mutable; use records for immutability |
| Nesting | Tuples can contain other tuples |

## When to Use

- Return two or three related values from a method (e.g., `(bool success, string error)`).
- Short-lived data grouping that does not warrant a dedicated class.
- Destructuring: `var (user, orders) = GetUserWithOrders(id)`.
- Dictionary entries or LINQ projections where a key-value pair suffices.

## When NOT to Use

- When the data has behavior or more than 3–4 fields — use a `record` or `class` instead.
- Public API boundaries — named types are more self-documenting.

## Time Complexity

Tuples are value types (`ValueTuple`) in C#. Access to any field is O(1). There is no heap allocation for value tuples.

## Language-Specific Notes

| Concept | C# | Python | TypeScript |
|---------|----|--------|------------|
| Syntax | `(int, string)` or `(int x, string y)` | `tuple[int, str]` | `[number, string]` |
| Named fields | `(int Id, string Name)` | `NamedTuple` or names via unpacking | `[number, string]` (no names) |
| Destructure | `var (a, b) = tuple` | `a, b = tuple` | `const [a, b] = tuple` |
| Immutable? | Mutable (value type) | Immutable | Array is mutable; use `readonly` |
| Multiple returns | Primary use case | Primary use case | Primary use case |
