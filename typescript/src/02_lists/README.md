# Lists

## What Is a List?

A **list** (called `List<T>` in C#) is a dynamic, ordered, mutable sequence of elements. Internally it is a resizable array: when the capacity is exceeded, a new array of double the size is allocated and all elements are copied.

Lists are the go-to collection for everyday work — when you know items need to be added, removed, or iterated but you do not know the final count at compile time.

## Visual Overview

```
List<string> items = ["smoke", "regression", "api"]

Index:   0            1              2
       ┌────────────┬──────────────┬─────────┐
       │  "smoke"   │ "regression" │  "api"  │
       └────────────┴──────────────┴─────────┘
             ↑ Add/Remove shifts elements
```

## Key Characteristics

| Property | Detail |
|----------|--------|
| Ordered | Yes — insertion order preserved |
| Duplicates | Allowed |
| Null elements | Allowed (reference types) |
| Index access | O(1) |
| Mutable | Yes |

## Time Complexity

| Operation | Complexity |
|-----------|-----------|
| Access by index | O(1) |
| Search (`Contains`) | O(n) |
| Add to end (`Add`) | O(1) amortized |
| Insert at index | O(n) |
| Remove by value | O(n) |
| Remove at end | O(1) |
| `Count` | O(1) |

## When to Use

- You need a collection that grows dynamically.
- Order matters and you need index-based access.
- You need to collect API response rows, UI elements found on a page, or test case results.
- You need LINQ transformations (`Where`, `Select`, `OrderBy`) — all work on `IEnumerable<T>`.

## Language-Specific Notes

| Concept | C# | Python | TypeScript |
|---------|----|--------|------------|
| Type | `List<T>` | `list` | `T[]` (Array) |
| Add | `list.Add(x)` | `list.append(x)` | `arr.push(x)` |
| Remove by value | `list.Remove(x)` | `list.remove(x)` | `arr.splice(arr.indexOf(x), 1)` |
| Remove by index | `list.RemoveAt(i)` | `list.pop(i)` | `arr.splice(i, 1)` |
| Count | `list.Count` | `len(list)` | `arr.length` |
| Clear | `list.Clear()` | `list.clear()` | `arr.length = 0` |
