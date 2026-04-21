# Sets

## What Is a Set?

A **set** is an unordered collection of **unique** elements. Adding a duplicate has no effect — the set silently ignores it. The primary use cases are deduplication, membership testing, and mathematical set operations (union, intersection, difference).

In C#, the main implementation is `HashSet<T>`. It uses a hash table internally, so most operations are O(1) on average.

## Visual Overview

```
new HashSet<int>([1, 2, 3, 3, 2])
         ↓ duplicates removed automatically
         { 1, 2, 3 }

Union ({1,2,3} | {3,4,5})  →  {1, 2, 3, 4, 5}
Intersection ({1,2,3} & {3,4,5})  →  {3}
Difference ({1,2,3} - {3,4,5})  →  {1, 2}
```

## Key Characteristics

| Property | Detail |
|----------|--------|
| Unique elements | Guaranteed — duplicates are silently ignored |
| Ordered | No (use `SortedSet<T>` if you need sorted order) |
| Null | Allowed once (reference types) |
| Index access | Not supported — iterate or test membership |
| Backed by | Hash table |

## Time Complexity

| Operation | Average | Worst case |
|-----------|---------|------------|
| `Add` | O(1) | O(n) |
| `Contains` | O(1) | O(n) |
| `Remove` | O(1) | O(n) |
| `UnionWith` | O(n) | O(n) |
| `IntersectWith` | O(n) | O(n) |

## When to Use

- Deduplicate items from multiple sources (API + DB ids).
- Fast membership test: "have we already processed this id?"
- Compute overlap or unique items between two result sets.
- Track visited nodes in graph/tree traversal.

## Language-Specific Notes

| Concept | C# | Python | TypeScript |
|---------|----|--------|------------|
| Type | `HashSet<T>` | `set` | `Set<T>` |
| Create from list | `new HashSet<int>(list)` | `set(list)` | `new Set(array)` |
| Add | `set.Add(x)` | `set.add(x)` | `set.add(x)` |
| Contains | `set.Contains(x)` | `x in set` | `set.has(x)` |
| Union | `set.UnionWith(other)` | `a \| b` | `new Set([...a, ...b])` |
| Intersection | `a.Intersect(b)` | `a & b` | `[...a].filter(x => b.has(x))` |
| Difference | `a.Except(b)` | `a - b` | `[...a].filter(x => !b.has(x))` |
