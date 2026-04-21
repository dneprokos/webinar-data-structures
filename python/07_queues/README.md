# Queues

## What Is a Queue?

A **queue** is a First-In, First-Out (FIFO) data structure. Elements are added at the back and removed from the front — like a checkout line: the first person in is the first person served.

In C#, `Queue<T>` provides a purpose-built, efficient FIFO implementation.

## Visual Overview

```
Enqueue →  [ sync-users | purge-cache | notify-slack ]  → Dequeue
           ↑ back (new items)                 ↑ front (served first)
```

## Key Characteristics

| Property | Detail |
|----------|--------|
| Order | FIFO — first in, first out |
| Access | Only front (dequeue) and back (enqueue) |
| Index access | Not supported |
| Duplicates | Allowed |
| Thread-safe | No (`ConcurrentQueue<T>` for thread safety) |

## Time Complexity

| Operation | Complexity |
|-----------|-----------|
| `Enqueue` (add to back) | O(1) |
| `Dequeue` (remove from front) | O(1) |
| `Peek` (read front, no remove) | O(1) |
| `Contains` | O(n) |
| `Count` | O(1) |

## When to Use

- Task/job processing: execute work items in the order they were submitted.
- Message bus / event queue: events processed in arrival order.
- BFS (Breadth-First Search) graph/tree traversal.
- Test execution queues: tests run in the order they are scheduled.
- Rate-limiting: buffer requests and process one at a time.

## Language-Specific Notes

| Concept | C# | Python | TypeScript |
|---------|----|--------|------------|
| Type | `Queue<T>` | `collections.deque` | `T[]` (push/shift) |
| Enqueue | `queue.Enqueue(x)` | `deque.append(x)` | `arr.push(x)` |
| Dequeue | `queue.Dequeue()` | `deque.popleft()` | `arr.shift()` |
| Peek front | `queue.Peek()` | `deque[0]` | `arr[0]` |
| Size | `queue.Count` | `len(deque)` | `arr.length` |
| Note | — | `list.pop(0)` is O(n); use `deque` | `shift()` is O(n); fine for small queues |
