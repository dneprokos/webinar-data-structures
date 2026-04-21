# Webinar: Data Structures for QA Engineers

Practical examples in **C#**, **Python**, and **TypeScript** covering the most important data structures, generics, collection operations, and coding challenges relevant to QA automation.

---

## Repository Layout

```
webinar-data-structures/
├── csharp/DataStructuresQA/
│   ├── 00_generics/           ← Generics, type constraints, typed API responses
│   ├── 01_arrays/             ← Arrays and List<T>
│   ├── 02_lists/              ← List<T> in depth
│   ├── 03_tuples/             ← ValueTuples and named fields
│   ├── 04_sets/               ← HashSet<T> and set operations
│   ├── 05_dictionaries/       ← Dictionary<K,V> and maps
│   ├── 06_stacks/             ← Stack<T> — LIFO
│   ├── 07_queues/             ← Queue<T> — FIFO
│   ├── 08_linked_lists/       ← LinkedList<T> — nodes and references
│   ├── 09_trees/              ← Binary Search Tree
│   ├── 10_linq/               ← LINQ: filter, project, aggregate, sort, group
│   └── 11_challenges/         ← Coding challenges
│
├── python/
│   ├── 00_generics/           ← TypeVar, Generic, Protocol
│   ├── 01_arrays/             ← list (Python's dynamic array)
│   ├── 02_lists/ … 07_queues/ ← Same topics as C#
│   ├── 08_linked_lists/       ← Custom SinglyLinkedList — nodes and references
│   ├── 09_trees/              ← Binary Search Tree
│   ├── 10_collection_operations/ ← Comprehensions, filter/map/reduce, itertools
│   └── 11_challenges/
│
└── typescript/src/
    ├── 00_generics/ … 07_queues/  ← Same topics
    ├── 08_linked_lists/           ← Custom SinglyLinkedList<T> — nodes and references
    ├── 09_trees/                  ← Binary Search Tree
    ├── 10_collection_operations/  ← .filter/.map/.reduce/.sort/.slice
    └── 11_challenges/
```

### File Structure (per topic folder)

| File | Purpose |
|------|---------|
| `README.md` | What the data structure is, Big-O table, when to use |
| `01_Initialization` | All ways to create the structure |
| `02_AccessingElements` | Read by index/key, iterate, search |
| `03_CommonMethods` | Add, remove, sort, and built-in helpers |
| `04_Conversions` | Convert to/from other types |
| `05_QaExample` | Practical QA automation scenario |

---

## Prerequisites

| Language | Requirement |
|----------|-------------|
| C# | .NET 8 SDK or later |
| Python | Python 3.12+ |
| TypeScript | Node.js 20+, `npm install` inside `typescript/` |

---

## Running Examples

### C#

```bash
cd csharp/DataStructuresQA

# Run all demos
dotnet run

# Run a specific topic
dotnet run -- arrays
dotnet run -- generics
dotnet run -- lists
dotnet run -- tuples
dotnet run -- sets
dotnet run -- dicts
dotnet run -- stacks
dotnet run -- queues
dotnet run -- linked
dotnet run -- trees
dotnet run -- linq
dotnet run -- challenge

# Help
dotnet run -- help
```

### Python

```bash
# Run any file directly
python python/01_arrays/05_qa_example.py
python python/09_collection_operations/05_qa_example.py
python python/10_challenges/01_most_frequent_char.py
```

### TypeScript

```bash
cd typescript
npm install

# Run a specific script (see package.json for all keys)
npm run arrays:qa
npm run col:qa
npm run challenge

# Or run any file directly
npx tsx src/01_arrays/05_qa_example.ts
```

---

## Topics Covered

| # | Topic | Key Concepts |
|---|-------|-------------|
| 00 | Generics | Type parameters, constraints, typed API wrappers |
| 01 | Arrays | Fixed arrays, dynamic arrays (`List<T>`), LINQ operations |
| 02 | Lists | Dynamic ordered collection, add/remove/sort |
| 03 | Tuples | Multiple return values, named fields, destructuring |
| 04 | Sets | Uniqueness, set operations (union/intersect/diff) |
| 05 | Dictionaries | Key-value lookup, frequency maps, config |
| 06 | Stacks | LIFO, undo/redo, resource pools |
| 07 | Queues | FIFO, job scheduling, event processing |
| 08 | Linked Lists | Nodes and references, O(1) insert, O(n) traversal, browser history |
| 09 | Trees (BST) | Hierarchical data, sorted lookup, traversals |
| 10 | LINQ / Collection Ops | Filter, project, aggregate, sort, group |
| 11 | Challenges | Most frequent character, log analysis |
