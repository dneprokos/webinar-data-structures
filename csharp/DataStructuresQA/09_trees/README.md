# Trees — Binary Search Tree (BST)

## What Is a Tree?

A **tree** is a hierarchical data structure where each node has a value and zero or more child nodes. There are no cycles. The top node is called the **root**; nodes with no children are called **leaves**.

A **Binary Search Tree (BST)** is a specialized binary tree (each node has at most two children) where:
- All values in the **left** subtree are **less than** the node's value.
- All values in the **right** subtree are **greater than** the node's value.

This ordering property enables efficient O(log n) search, insert, and delete **on a balanced tree**.

## Visual Overview

```
Insert: 10, 5, 15, 3, 7

          10          ← root
         /  \
        5    15
       / \
      3   7           ← leaves

Contains(7)  → go right from 5  → found ✓
Contains(99) → go right from 10 → go right from 15 → null → not found ✗
```

## Key Characteristics

| Property | Detail |
|----------|--------|
| Structure | Hierarchical; each node has at most 2 children (BST) |
| Ordering | Left < node < Right |
| Balanced? | Only if you use a self-balancing variant (AVL, Red-Black) |
| Duplicates | Typically ≤ goes left; exact policy is implementation-defined |
| In-order traversal | Produces sorted output |

## Time Complexity (balanced BST)

| Operation | Average | Worst (unbalanced) |
|-----------|---------|-------------------|
| Insert | O(log n) | O(n) |
| Contains / Search | O(log n) | O(n) |
| Delete | O(log n) | O(n) |
| In-order traversal | O(n) | O(n) |

## When to Use

- Fast sorted data lookup (autocomplete, range queries).
- DOM/menu hierarchy traversal in UI testing.
- Sitemap or file-system path validation.
- Any hierarchical relationship: categories, org charts, permission trees.

## Language-Specific Notes

There is no built-in BST in C#, Python, or TypeScript — you implement the `Node` and `BinarySearchTree` classes yourself (as shown in the examples). For production, consider:
- C#: `SortedDictionary<K,V>` (Red-Black tree)
- Python: `sortedcontainers.SortedList`
- TypeScript: third-party libraries or custom implementation
