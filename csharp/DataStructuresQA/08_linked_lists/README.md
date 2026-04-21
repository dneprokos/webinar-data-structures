# Linked Lists

## What Is a Linked List?

A **linked list** is a linear data structure where each element (a **node**) holds a value and a reference (pointer) to the next node. Unlike arrays, nodes are not stored in contiguous memory — they are scattered in the heap and wired together by references.

C#'s `LinkedList<T>` is a **doubly-linked list**: every node has both a `Next` and a `Previous` pointer.

## Visual Overview

```
null ← [Head: /login] ⇄ [/dashboard] ⇄ [/profile] ⇄ [/settings: Tail] → null
```

## Key Characteristics

| Property | Detail |
|----------|--------|
| Order | Insertion order preserved |
| Index access | Not supported (O(n) traversal required) |
| Insert/remove at known node | O(1) — just re-wire pointers |
| Search | O(n) |
| Duplicates | Allowed |
| Thread-safe | No |

## Time Complexity

| Operation | Complexity |
|-----------|-----------|
| `AddFirst` / `AddLast` | O(1) |
| `AddBefore` / `AddAfter` (node known) | O(1) |
| `Find` (search by value) | O(n) |
| `Remove` (node known) | O(1) |
| `Remove` (by value) | O(n) |
| Access by index | O(n) |
| `Count` | O(1) |

## When to Use

- You need frequent insertions/deletions in the **middle** of a sequence without shifting.
- Implementing **undo/redo** stacks, browser history, or step chains.
- Building custom queues or deques with O(1) front/back operations.
- The collection size is unknown and changes often.

## Language-Specific Notes

| Concept | C# | Python | TypeScript |
|---------|----|--------|------------|
| Type | `LinkedList<T>` (built-in, doubly-linked) | Custom `SinglyLinkedList` | Custom `SinglyLinkedList<T>` |
| Add to end | `list.AddLast(v)` | `ll.append(v)` | `ll.append(v)` |
| Add to front | `list.AddFirst(v)` | `ll.prepend(v)` | `ll.prepend(v)` |
| Insert after node | `list.AddAfter(node, v)` | `ll.insert_after(target, v)` | `ll.insertAfter(target, v)` |
| Remove by value | `list.Remove(v)` | `ll.remove(v)` | `ll.remove(v)` |
| First node | `list.First` | `ll.head` | `ll.head` |
| Size | `list.Count` | `len(ll)` | `ll.size` |
