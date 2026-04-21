# Collection Operations (TypeScript / JavaScript)

## What Are Collection Operations?

JavaScript/TypeScript arrays have a rich set of built-in methods for filtering, transforming, and aggregating data. Unlike C#'s LINQ (an extension library) or Python's comprehensions (language syntax), JS array methods are regular methods on the `Array` prototype — always available, no imports needed.

## Core Array Methods

| Method | Purpose | Returns |
|--------|---------|---------|
| `.filter(fn)` | Keep elements where fn returns true | New array |
| `.map(fn)` | Transform each element | New array |
| `.reduce(fn, initial)` | Accumulate a single result | Any value |
| `.find(fn)` | First element matching fn | Element or `undefined` |
| `.findIndex(fn)` | Index of first match | number or -1 |
| `.some(fn)` | True if any element matches | boolean |
| `.every(fn)` | True if all elements match | boolean |
| `.sort(compareFn)` | Sort **in-place** (mutates!) | Same array |
| `.slice(start, end)` | Copy a portion | New array |
| `.flatMap(fn)` | Map then flatten one level | New array |
| `.forEach(fn)` | Side-effect iteration | void |

## Important: sort() Mutates

```typescript
const original = [3, 1, 4, 1, 5];
const sorted = [...original].sort((a, b) => a - b); // spread to avoid mutation
// original is unchanged; sorted is a new array
```

## Chaining

Methods can be chained because each returns a new array:

```typescript
const result = employees
  .filter(e => e.salary > 80000)
  .map(e => e.name)
  .sort((a, b) => a.localeCompare(b));
```

## Lazy Evaluation

Unlike LINQ, JS array methods are **eager** — each step creates a new array immediately. For large datasets consider:
- Combining operations into one `reduce`
- Using generator functions
- Libraries like `iter-tools` or `lazy.js`

## LINQ Equivalents

| LINQ (C#) | TypeScript |
|-----------|------------|
| `Where` | `.filter(fn)` |
| `Select` | `.map(fn)` |
| `SelectMany` | `.flatMap(fn)` |
| `Sum` | `.reduce((a, b) => a + b, 0)` |
| `Min` / `Max` | `Math.min(...arr)` / `Math.max(...arr)` |
| `OrderBy` | `[...arr].sort((a,b) => a - b)` |
| `Skip(n).Take(m)` | `.slice(n, n + m)` |
| `Any` | `.some(fn)` |
| `All` | `.every(fn)` |
| `First` | `.find(fn)` |
| `Count` | `.filter(fn).length` |
| `Distinct` | `[...new Set(arr)]` |
| `GroupBy` | `.reduce()` into a `Map` |
| `ToDictionary` | `Object.fromEntries(arr.map(...))` |
