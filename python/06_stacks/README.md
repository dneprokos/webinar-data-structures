# Stacks

## What Is a Stack?

A **stack** is a Last-In, First-Out (LIFO) data structure. The last element you put in is always the first one you take out — like a stack of plates: you always add and remove from the top.

In C#, `Stack<T>` provides a purpose-built implementation with O(1) push and pop.

## Visual Overview

```
Push 101, 102, 103          Pop
                            ↓
  ┌──────────┐           103 ← taken first (LIFO)
  │   103    │  ← top
  ├──────────┤
  │   102    │
  ├──────────┤
  │   101    │
  └──────────┘
```

## Key Characteristics

| Property | Detail |
|----------|--------|
| Order | LIFO — last in, first out |
| Access | Only the top element is directly accessible |
| Index access | Not supported |
| Duplicates | Allowed |
| Thread-safe | No (`ConcurrentStack<T>` for thread safety) |

## Time Complexity

| Operation | Complexity |
|-----------|-----------|
| `Push` (add to top) | O(1) |
| `Pop` (remove from top) | O(1) |
| `Peek` (read top, no remove) | O(1) |
| `Contains` | O(n) |
| `Count` | O(1) |

## When to Use

- Undo / redo history (text editors, navigation history).
- Backtracking algorithms (maze solving, depth-first search).
- Call stack simulation / expression parsing.
- Resource pools in test frameworks: push available clients, pop to acquire, push back to release.
- Browser navigation: the back-button history is a stack.

## Language-Specific Notes

| Concept | C# | Python | TypeScript |
|---------|----|--------|------------|
| Type | `Stack<T>` | `list` (append/pop) | `T[]` (push/pop) |
| Push | `stack.Push(x)` | `stack.append(x)` | `stack.push(x)` |
| Pop | `stack.Pop()` | `stack.pop()` | `stack.pop()` |
| Peek | `stack.Peek()` | `stack[-1]` | `stack[stack.length - 1]` |
| Size | `stack.Count` | `len(stack)` | `stack.length` |
| Empty check | `stack.Count == 0` | `not stack` | `stack.length === 0` |

## Library Implementations (06)

When you need a dedicated, purpose-built stack rather than a bare `list` or array:

| Language | Library | Type | Notes |
|----------|---------|------|-------|
| Python | `queue` (stdlib) | `LifoQueue[T]` | Thread-safe; uses internal locks. Best when multiple threads push/pop. |
| TypeScript | `js-sdsl` | `Stack<T>` | Explicit `.top()` peek; clearer intent than `arr[arr.length-1]`. |

**When to choose the library type:**
- Python: use `queue.LifoQueue` when producers and consumers run in separate threads; use `list` for single-threaded code.
- TypeScript: use `js-sdsl Stack<T>` when you want an explicit, self-documenting stack API; use a plain array for simple scripts.

See `06_library_example.py` for the runnable example.
