# LINQ — Language Integrated Query

## What Is LINQ?

**LINQ** (Language Integrated Query) is a set of C# methods (and a query syntax) that lets you query and transform any sequence that implements `IEnumerable<T>` — arrays, lists, databases, XML, and more — using a consistent, readable API.

LINQ methods are **lazy by default** (deferred execution): they return an `IEnumerable<T>` and do not execute until you iterate the result (e.g., with `foreach`, `.ToList()`, or `.ToArray()`).

## Method Syntax vs Query Syntax

```csharp
// Method syntax (most common)
var passed = scores.Where(s => s >= 80).OrderBy(s => s).ToList();

// Query syntax (SQL-like, less common)
var passed = (from s in scores where s >= 80 orderby s select s).ToList();
```

Both produce identical results. Method syntax is preferred in modern C# codebases.

## Execution: Deferred vs Immediate

| Returns | Execution | Examples |
|---------|-----------|---------|
| `IEnumerable<T>` | Deferred | `Where`, `Select`, `OrderBy`, `Skip`, `Take` |
| A value or collection | Immediate | `ToList()`, `ToArray()`, `Count()`, `Sum()`, `First()`, `Any()` |

Calling `.ToList()` forces execution and materializes the sequence into memory.

## Key Method Categories

| Category | Methods |
|----------|---------|
| Filtering | `Where`, `OfType`, `Distinct` |
| Projection | `Select`, `SelectMany` |
| Aggregation | `Count`, `Sum`, `Average`, `Min`, `Max`, `Aggregate` |
| Element access | `First`, `FirstOrDefault`, `Single`, `Last`, `ElementAt` |
| Existence | `Any`, `All`, `Contains` |
| Ordering | `OrderBy`, `OrderByDescending`, `ThenBy`, `ThenByDescending` |
| Paging | `Skip`, `Take`, `Chunk` |
| Grouping | `GroupBy` |
| Joining | `Join`, `GroupJoin`, `Zip` |
| Set operations | `Union`, `Intersect`, `Except`, `Concat` |
| Conversion | `ToList`, `ToArray`, `ToDictionary`, `ToHashSet` |

## When to Use LINQ

- Filter a list of test results by status.
- Project API response objects to simpler DTOs.
- Aggregate scores, counts, or totals.
- Page through large result sets (`Skip` + `Take`).
- Group test failures by category.

## Language Equivalents

| LINQ (C#) | Python | TypeScript |
|-----------|--------|------------|
| `Where` | `[x for x in seq if cond]` / `filter()` | `.filter()` |
| `Select` | `[f(x) for x in seq]` / `map()` | `.map()` |
| `Sum` | `sum(...)` | `.reduce((a,b) => a+b, 0)` |
| `OrderBy` | `sorted(seq, key=...)` | `[...arr].sort(...)` |
| `Skip`/`Take` | `seq[skip:skip+take]` | `.slice(skip, skip+take)` |
| `GroupBy` | `itertools.groupby` / `dict` | `reduce` to `Map` |
| `First` | `next(iter(seq))` | `.find()` |
| `Any` | `any(...)` | `.some()` |
| `All` | `all(...)` | `.every()` |
