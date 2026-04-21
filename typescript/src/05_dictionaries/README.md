# Dictionaries (Maps)

## What Is a Dictionary?

A **dictionary** (also called a map or hash map) stores data as **key–value pairs**. Given a key, you can retrieve its associated value in O(1) average time. Keys must be unique; values can repeat.

In C#, the primary type is `Dictionary<TKey, TValue>`. It is backed by a hash table.

## Visual Overview

```
Dictionary<string, decimal>
┌──────────────────┬──────────┐
│ Key              │ Value    │
├──────────────────┼──────────┤
│ "Clean Code"     │ 42.50    │
│ "Refactoring"    │ 39.00    │
│ "POODR"          │ 45.00    │
└──────────────────┴──────────┘
       ↑ O(1) lookup by key
```

## Key Characteristics

| Property | Detail |
|----------|--------|
| Keys | Unique |
| Values | Can repeat |
| Ordered | No (use `SortedDictionary` for sorted keys) |
| Access | O(1) by key; O(n) by value |
| Null keys | Not allowed (for reference key types, use care) |

## Time Complexity

| Operation | Average | Worst case |
|-----------|---------|------------|
| Get by key | O(1) | O(n) |
| Add / Update | O(1) | O(n) |
| Remove | O(1) | O(n) |
| `ContainsKey` | O(1) | O(n) |
| Iterate | O(n) | O(n) |

## When to Use

- Map codes/identifiers to human-readable labels (SQL operator → SQL fragment).
- Cache computed values (memoization).
- Count occurrences of items (frequency map).
- Config / settings store: string key → typed value.
- Any scenario requiring fast lookup by a named key.

## Language-Specific Notes

| Concept | C# | Python | TypeScript |
|---------|----|--------|------------|
| Type | `Dictionary<K,V>` | `dict` | `Record<K,V>` or `Map<K,V>` |
| Add / update | `dict[key] = val` | `dict[key] = val` | `obj[key] = val` / `map.set(k,v)` |
| Get | `dict[key]` | `dict[key]` | `obj[key]` / `map.get(k)` |
| Safe get | `dict.GetValueOrDefault(k)` | `dict.get(k, default)` | `map.get(k) ?? default` |
| Contains key | `dict.ContainsKey(k)` | `k in dict` | `k in obj` / `map.has(k)` |
| Remove | `dict.Remove(k)` | `del dict[k]` | `delete obj[k]` / `map.delete(k)` |
| Iterate | `foreach (var (k,v) in dict)` | `for k, v in dict.items()` | `for (const [k,v] of map)` |
| Case-insensitive | `StringComparer.OrdinalIgnoreCase` | `.lower()` in key | `.toLowerCase()` in key |
