# Collection Operations (Python)

## What Are Collection Operations?

Python provides a rich set of built-in tools for filtering, transforming, and aggregating sequences. Unlike C#'s LINQ (which is a library), Python's operations are built into the language as comprehensions, built-in functions (`filter`, `map`, `sum`, `sorted`), and the `functools` module.

## Comprehensions — The Pythonic Approach

List comprehensions are idiomatic Python and usually preferred over `map()`/`filter()`:

```python
# Filtering
passed = [s for s in scores if s >= 80]

# Projection (map)
doubled = [s * 2 for s in scores]

# Combined
labels = [f"score={s}" for s in scores if s >= 80]

# Generator (lazy — no list created until consumed)
total = sum(s for s in scores if s > 80)
```

## Key Built-in Functions

| Function | Purpose | Example |
|----------|---------|---------|
| `filter(fn, seq)` | Keep elements where fn returns True | `list(filter(lambda x: x > 0, nums))` |
| `map(fn, seq)` | Transform each element | `list(map(str, nums))` |
| `sum(seq)` | Sum of all elements | `sum(scores)` |
| `min(seq)` / `max(seq)` | Smallest / largest | `max(scores)` |
| `sorted(seq, key=..., reverse=...)` | Return sorted copy | `sorted(items, key=lambda x: x.score)` |
| `any(seq)` | True if any element is truthy | `any(s >= 80 for s in scores)` |
| `all(seq)` | True if all elements are truthy | `all(s >= 0 for s in scores)` |
| `enumerate(seq)` | Index + value pairs | `for i, v in enumerate(items)` |
| `zip(a, b)` | Pair elements from two sequences | `for x, y in zip(keys, vals)` |

## functools for Aggregation

```python
from functools import reduce

total = reduce(lambda acc, x: acc + x, scores, 0)
```

## Execution: Lazy vs Eager

- `map()`, `filter()`, generator expressions are **lazy** — no work done until iterated.
- List comprehensions `[...]` are **eager** — produce a list immediately.
- Use `list()` or `sum()` to materialize lazy iterators.

## LINQ Equivalents

| LINQ (C#) | Python |
|-----------|--------|
| `Where` | `[x for x in seq if cond]` or `filter()` |
| `Select` | `[f(x) for x in seq]` or `map()` |
| `Sum` | `sum(seq)` |
| `Min` / `Max` | `min(seq)` / `max(seq, key=...)` |
| `OrderBy` | `sorted(seq, key=...)` |
| `Skip(n).Take(m)` | `seq[n:n+m]` |
| `Any` | `any(cond(x) for x in seq)` |
| `All` | `all(cond(x) for x in seq)` |
| `GroupBy` | `itertools.groupby` or dict comprehension |
| `Distinct` | `set(seq)` or `dict.fromkeys(seq)` |
| `First` | `next(iter(seq))` or `seq[0]` |
| `Count` | `len(list(seq))` or `sum(1 for x in seq if cond)` |
