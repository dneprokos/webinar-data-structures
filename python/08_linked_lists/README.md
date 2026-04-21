# Linked Lists

## What Is a Linked List?

A **linked list** is a linear data structure where each element (a **node**) holds a value and a reference (pointer) to the next node. Unlike arrays, nodes are not stored in contiguous memory — they are scattered in the heap and wired together by references.

Python has no built-in linked list type, so these files define a minimal `SinglyLinkedList` class inline. For production use, `collections.deque` is backed by a doubly-linked list internally.

## Visual Overview

```
None ← [Head: /login] → [/dashboard] → [/profile] → [/settings: Tail] → None
```

## Key Characteristics

| Property | Detail |
|----------|--------|
| Order | Insertion order preserved |
| Index access | Not supported (O(n) traversal required) |
| Insert/remove at known node | O(1) — just re-wire pointers |
| Search | O(n) |
| Duplicates | Allowed |

## Time Complexity

| Operation | Complexity |
|-----------|-----------|
| `append` / `prepend` | O(1) |
| `insert_after` (value known) | O(n) to find, O(1) to insert |
| `remove` (by value) | O(n) |
| Access by index | O(n) |
| `__len__` | O(1) |

## When to Use

- You need frequent insertions/deletions at the **front** without shifting.
- Implementing **undo/redo** stacks, browser history, or step chains.
- Building custom queues or deques with O(1) front operations.
- The collection size is unknown and changes often.

## Language-Specific Notes

| Concept | C# | Python | TypeScript |
|---------|----|--------|------------|
| Type | `LinkedList<T>` (built-in, doubly-linked) | Custom `SinglyLinkedList` | Custom `SinglyLinkedList<T>` |
| Add to end | `list.AddLast(v)` | `ll.append(v)` | `ll.append(v)` |
| Add to front | `list.AddFirst(v)` | `ll.prepend(v)` | `ll.prepend(v)` |
| Insert after | `list.AddAfter(node, v)` | `ll.insert_after(target, v)` | `ll.insertAfter(target, v)` |
| Remove by value | `list.Remove(v)` | `ll.remove(v)` | `ll.remove(v)` |
| First node | `list.First` | `ll.head` | `ll.head` |
| Size | `list.Count` | `len(ll)` | `ll.size` |
