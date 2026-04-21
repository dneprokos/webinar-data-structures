# Generics

## What Are Generics?

Generics allow you to write code that works with **any type** while retaining full compile-time type safety. Instead of writing separate classes for `int`, `string`, or custom types, you write one class parameterized with `T` — and the compiler enforces type correctness at every call site.

Without generics you would need `object`-based collections with risky casts, or separate duplicated implementations per type. Generics eliminate both problems.

## Visual Overview

```
Generic class           Concrete usage
─────────────           ─────────────────────────────
RestResponse<T>  ──▶   RestResponse<List<UserDto>>
                  ──▶   RestResponse<OrderDto>
                  ──▶   RestResponse<byte[]>
```

## Key Characteristics

| Property | Detail |
|----------|--------|
| Type parameter | `T`, `TKey`, `TBody` — any valid identifier |
| Resolved at | Compile time (C#/TypeScript) / Runtime via type erasure (Python typing) |
| Constraints | Limit which types are allowed for `T` |
| Collections | All built-in collections (`List<T>`, `Dictionary<K,V>`, `HashSet<T>`) use generics |

## Constraints (where clause in C#)

| Constraint | Meaning |
|------------|---------|
| `where T : class` | T must be a reference type |
| `where T : struct` | T must be a value type (int, DateTime, etc.) |
| `where T : new()` | T must have a parameterless constructor |
| `where T : IFoo` | T must implement interface IFoo |
| `where T : IComparable<T>` | T must be comparable to itself |
| Combined | `where T : class, IFoo, new()` — all conditions must hold |

## Time Complexity

Generics have **no runtime cost** in C# — the JIT specializes value types and shares code for reference types. There is no boxing overhead.

## When to Use

- Any reusable class or method that should work with multiple types (`Repository<T>`, `ApiResponse<T>`)
- Typed collections instead of `ArrayList` / `object[]`
- Utility methods like `Max<T>`, `FindFirst<T>`, `Clone<T>`
- Builder/factory patterns: `Create<T>() where T : new()`

## Language-Specific Notes

| Concept | C# | Python | TypeScript |
|---------|----|--------|------------|
| Type parameter | `<T>` | `TypeVar("T")` | `<T>` |
| Constraint syntax | `where T : IFoo` | `TypeVar("T", bound=IFoo)` | `T extends IFoo` |
| Interface analog | `interface IHasId` | `Protocol` class | `{ id: string }` structural type |
| Fixed-type union | `where T : int` (not valid) | `TypeVar("T", int, float)` | `T extends number \| string` |
