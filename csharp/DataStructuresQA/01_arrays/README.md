# Arrays

## What Is an Array?

An **array** is the most fundamental data structure: a contiguous block of memory holding a fixed number of elements of the same type. Every element is accessible in **O(1)** time via its numeric index.

In C# there are two flavors:
- `T[]` — fixed-length array; length is set at creation and cannot change.
- `List<T>` — a resizable wrapper built on an internal array; use this when the count is not known upfront.

## Visual Overview

```
Index:   0     1     2     3
       ┌─────┬─────┬─────┬─────┐
T[]    │  10 │  20 │  30 │  40 │
       └─────┴─────┴─────┴─────┘
         ↑                   ↑
       first               last (index Length-1 or ^1)
```

## Key Characteristics

| Property | `T[]` | `List<T>` |
|----------|-------|-----------|
| Length | Fixed at creation | Dynamic (grows automatically) |
| Add / Remove | Not supported | `Add`, `Remove`, `RemoveAt`, `Insert` |
| Memory | Contiguous | Contiguous (resizes by doubling) |
| Thread-safety | Not thread-safe | Not thread-safe |
| Default values | Zero / null | n/a (you add explicitly) |

## Time Complexity

| Operation | `T[]` | `List<T>` |
|-----------|-------|-----------|
| Access by index | O(1) | O(1) |
| Search (unsorted) | O(n) | O(n) |
| Insert at end | n/a | O(1) amortized |
| Insert at middle | n/a | O(n) |
| Delete by value | n/a | O(n) |
| Sort | O(n log n) | O(n log n) |

## When to Use

- Use `T[]` when the size is known and fixed (pixel buffers, lookup tables, algorithm internals).
- Use `List<T>` for everyday collections where items are added/removed.
- Prefer arrays over lists when passing data to low-level APIs or when memory layout matters.

## Language-Specific Notes

| Concept | C# | Python | TypeScript |
|---------|----|--------|------------|
| Fixed array | `int[] a = new int[4]` | `[0] * 4` (list, not truly fixed) | `new Array(4).fill(0)` |
| Dynamic array | `List<int>` | `list` | `Array` / `T[]` |
| Last element | `arr[^1]` (index-from-end) | `arr[-1]` | `arr.at(-1)` |
| Sort (copy) | `arr.OrderBy(…).ToArray()` | `sorted(arr)` | `[...arr].sort(...)` |
| Sort (in-place) | `Array.Sort(arr)` | `arr.sort()` | `arr.sort(...)` |
