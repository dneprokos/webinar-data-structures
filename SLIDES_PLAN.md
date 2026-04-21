# Slide plan: «Data structures in programming: from theory to practice»

Same principle as the previous deck: **short theory / definition → code example**. Put abbreviated snippets on slides; full samples live in `csharp/`, `typescript/`, and `python/`.

**Author references**

- [Data Structures for QA Automation (C#)](https://medium.com/@dneprokos/data-structures-for-qa-automation-engineers-993135928456)
- [SDET: The Magic of Python Data Structures](https://medium.com/@dneprokos/sdet-the-magic-of-python-data-structures-3040e7da342d)

---

## Block 1 — Introduction

| # | Slide | Content | Code (repo) |
|---|--------|---------|-------------|
| 1 | Title | Webinar title, speaker, languages: C#, TypeScript, Python | — |
| 2 | About me / contacts | Experience, stack (like the old deck; update languages) | — |
| 3 | What is a data structure | Organizing data for efficient access and change; Wikipedia link (as in old ppt) | — |
| 4 | Why QA automation | Test data, test speed, frameworks (API/UI), deduplication, job queues, resource pools | — |
| 5 | Agenda | Arrays → generics/types → lists → tuples → sets → maps → stack → queue → linked list → tree/BST → collection transforms → final challenge | — |

---

## Block 2 — Arrays and “raw” sequences

| # | Slide | Content | Code |
|---|--------|---------|------|
| 6 | Array / fixed size | Zero-based index, fixed length (C#); in Python often `list` as dynamic array; in TS `Array` | **Slide:** concept. **Live:** `01_arrays` |
| 7 | QA case: query string | `?ids=2,5,7` from a set of ids (from Medium, C#) | `01_arrays` |
| 8 | QA case: string parsing | Extract digits from a string and sum them (from Medium) | `01_arrays` |

---

## Block 3 — Generics and typed models

| # | Slide | Content | Code |
|---|--------|---------|------|
| 9 | Generics | Type placeholders, reuse, type safety (as Generics slides in old ppt) | **Theory on slide** |
| 10 | QA case: API response | `RestResponse<T>` — same StatusCode, varying Body (from Medium) | `02_generics_api_response` |

---

## Block 4 — Lists (List / arrays in TS / list in Python)

| # | Slide | Content | Code |
|---|--------|---------|------|
| 11 | List | Dynamic size, indexing, common operations (ArrayList in Java analogy from old ppt) | `03_lists_qa` |
| 12 | QA: element collection | Simulate “found elements”: count checks, expect count > N (from Medium) | `03_lists_qa` |
| 13 | QA: list in response model | List of API records with unknown length | `03_lists_qa` |

---

## Block 5 — Tuples

| # | Slide | Content | Code |
|---|--------|---------|------|
| 14 | Tuple | Small fixed sequence of values; immutable in Python; ValueTuple / tuple in C# | `04_tuples` |
| 15 | QA case | Return “user + orders” from a helper as one value | `04_tuples` |

---

## Block 6 — Sets (Set / HashSet)

| # | Slide | Content | Code |
|---|--------|---------|------|
| 16 | Set / hash set | Uniqueness, no duplicates; tie-in to hash table (as in old ppt) | `05_sets` |
| 17 | QA case | Merge results from several sources without duplicates | `05_sets` |
| 18 | Operations (optional on slide) | Union / Intersect / Except (C#), `\| & -` (Python), etc. | `05_sets` |

---

## Block 7 — Dictionaries / Map / Dictionary

| # | Slide | Content | Code |
|---|--------|---------|------|
| 19 | Dictionary / map | Key → value; unique keys; link to JSON | `06_maps` |
| 20 | QA case: SQL operators | Enum/string → SQL fragment (from Medium) | `06_maps` |
| 21 | QA case: run-scoped data | e.g. book title → price; config key → value | `06_maps` |

---

## Block 8 — Stack (LIFO)

| # | Slide | Content | Code |
|---|--------|---------|------|
| 22 | Stack | LIFO, stack-of-plates analogy (old ppt + Medium) | `07_stack` |
| 23 | QA case | `clientId` pool: pop for parallel tests, push back in cleanup (from Medium) | `07_stack` |

---

## Block 9 — Queue (FIFO)

| # | Slide | Content | Code |
|---|--------|---------|------|
| 24 | Queue | FIFO, amusement-park line (old ppt) | `08_queue` |
| 25 | QA case | Task/event queue; in Python — `collections.deque` (from Python article) | `08_queue` |

---

## Block 9b — Linked List

| # | Slide | Content | Code |
|---|--------|---------|------|
| 25b | Linked List | Nodes + references; not contiguous memory; O(1) insert at known node, O(n) traversal; doubly-linked in C# (`LinkedList<T>`); hand-rolled singly-linked in Python / TypeScript | **Live:** `08_linked_lists` |
| 25c | QA case | Browser back/forward history: push URL nodes, move a `current` pointer, assert correct page; undo history for form wizard; fail-fast step chain | `08_linked_lists` |

---

## Block 10 — Trees

| # | Slide | Content | Code |
|---|--------|---------|------|
| 26 | Tree | Hierarchy, root, children, leaf; DOM/UI tie-in (for QA) | **Theory** |
| 27 | Terminology | Root, node, edge, path, leaf, height, level, parent, sibling (like old ppt slide 45) | — |
| 28 | Binary tree / BST | At most two children; BST: left ≤ parent < right (slide 46) | `09_tree_bst` |
| 29 | QA intuition | Decision trees, DOM, sometimes filter/search logic | **Brief on slide** |

---

## Block 11 — Higher-level collection work

| # | Slide | Content | Code |
|---|--------|---------|------|
| 30 | LINQ / array methods / comprehensions | Filter, projection, aggregates (Sum, Where, Select — old ppt; Python — list comp / map / filter) | `10_collection_transforms` |
| 31 | JS/TS parallel | `filter` / `map` / `reduce` on test data | `10_collection_transforms` |

---

## Block 12 — Combining structures

| # | Slide | Content | Code |
|---|--------|---------|------|
| 32 | Challenge | Most frequent character in a string (interview-style + Python article) | `11_challenge_most_frequent_char` |
| 33 | Walkthrough | Frequency map → sort pairs → first element / `MaxBy` | `11_challenge_most_frequent_char` |

---

## Block 13 — Closing

| # | Slide | Content | Code |
|---|--------|---------|------|
| 34 | Practice | HackerRank Interview Prep Kit (as in old ppt) | — |
| 35 | Resources | .NET Collections docs, MDN, Python docs; your GitHub with examples | — |
| 36 | Questions | Q&A | — |

---

## How to use the code folders

| Folder | Run |
|--------|-----|
| `csharp/DataStructuresQA` | `dotnet run` (all demos) or `dotnet run -- arrays` / `dotnet run -- linq` etc. Run `dotnet run -- help` for all keys. |
| `typescript` | `npm install` inside `typescript/`, then `npm run arrays:qa`, `npm run col:qa`, `npm run challenge`, etc. Or `npx tsx src/01_arrays/05_qa_example.ts` directly. |
| `python` | `python python/01_arrays/05_qa_example.py` from the repo root (each file is self-contained). |

**Slide tip:** show 5-15 lines of the "core" on a slide; keep the full file for live demo or homework.

---

## Folder map (new structure)

Each topic folder contains up to 5 files + a README:

| # | Folder | Files inside | Topic |
|---|--------|-------------|-------|
| 00 | `00_generics/` | `01_basic_generics`, `02_constraints`, `03_qa_example` | `RestResponse<T>`, constraints (`where`, `extends`, `TypeVar`) |
| 01 | `01_arrays/` | `01_init ... 05_qa_example` | Fixed arrays, dynamic arrays; QA query-string and parsing |
| 02 | `02_lists/` | `01_init ... 05_qa_example` | Dynamic list; add/remove/sort; QA element collection |
| 03 | `03_tuples/` | `01_init ... 05_qa_example` | ValueTuple / `tuple`; multi-return page objects |
| 04 | `04_sets/` | `01_init ... 05_qa_example` | Unique sets; union/intersect/diff; dedup test URLs |
| 05 | `05_dictionaries/` | `01_init ... 05_qa_example` | Key-value map; SQL operators; config-driven test data |
| 06 | `06_stacks/` | `01_init ... 05_qa_example` | LIFO; browser history; clientId pool |
| 07 | `07_queues/` | `01_init ... 05_qa_example` | FIFO; test execution queue; rate limiting |
| 08 | `08_linked_lists/` | `01_init ... 05_qa_example` | Nodes + references; browser nav history; undo; step chain |
| 09 | `09_trees/` | `01_init ... 05_qa_example` | BST; traversals; menu hierarchy validation |
| 10 | `10_linq/` (C#) / `10_collection_operations/` (PY/TS) | `01_filtering ... 05_qa_example` | Filter/project/aggregate/sort/group |
| 11 | `11_challenges/` | `01_most_frequent_char` | Frequency map + sorting; log analysis |
---

## Conclusion: data structures at a glance

**Theme (aligned with your slides):** midnight navy background, **neon green** (`#39FF14`) titles and keyword accents, **near-white** body text (`#e8eef8`) so nothing inherits low-contrast gray from the editor theme. Zebra rows use two dark blues. Every cell sets `color` explicitly.

| Token | Use |
|-------|-----|
| `#050a1a` | Table / slide panel background |
| `#0a1228` | Header row behind title |
| `#39FF14` | Structure name + `<strong>` keywords |
| `#10192e` / `#172238` | Alternating body rows |
| `#e8eef8` | Body sentence text |

<!-- Conclusion tables: dark theme, high contrast, inline colors only (reliable in preview) -->

<table style="border-collapse:collapse;width:100%;max-width:720px;margin:0 0 1.25em 0;border:1px solid #39FF14;background:#050a1a;font-family:system-ui,Segoe UI,sans-serif;font-size:14px;">
  <thead>
    <tr>
      <th style="text-align:left;padding:12px 16px;font-weight:bold;background:#0a1228;color:#39FF14;border-bottom:2px solid #39FF14;">Array</th>
    </tr>
  </thead>
  <tbody>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">1) Array stores elements in <strong style="color:#39FF14;font-weight:700;">contiguous memory</strong>.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#172238;color:#e8eef8;">2) Access by index is very fast <strong style="color:#39FF14;font-weight:700;">(O(1))</strong>.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">3) Size is usually <strong style="color:#39FF14;font-weight:700;">fixed</strong> (in many languages).</td></tr>
    <tr><td style="padding:12px 16px;background:#172238;color:#e8eef8;">4) Insertion/removal can be slow due to <strong style="color:#39FF14;font-weight:700;">shifting</strong> elements.</td></tr>
  </tbody>
</table>

<table style="border-collapse:collapse;width:100%;max-width:720px;margin:0 0 1.25em 0;border:1px solid #39FF14;background:#050a1a;font-family:system-ui,Segoe UI,sans-serif;font-size:14px;">
  <thead>
    <tr>
      <th style="text-align:left;padding:12px 16px;font-weight:bold;background:#0a1228;color:#39FF14;border-bottom:2px solid #39FF14;">List</th>
    </tr>
  </thead>
  <tbody>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">1) List is a <strong style="color:#39FF14;font-weight:700;">dynamic array</strong> (in many languages like Python, C#).</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#172238;color:#e8eef8;">2) It can <strong style="color:#39FF14;font-weight:700;">grow and shrink</strong> during runtime.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">3) Provides <strong style="color:#39FF14;font-weight:700;">fast access</strong> by index.</td></tr>
    <tr><td style="padding:12px 16px;background:#172238;color:#e8eef8;">4) Insertions/removals may be costly due to <strong style="color:#39FF14;font-weight:700;">shifting</strong>.</td></tr>
  </tbody>
</table>

<table style="border-collapse:collapse;width:100%;max-width:720px;margin:0 0 1.25em 0;border:1px solid #39FF14;background:#050a1a;font-family:system-ui,Segoe UI,sans-serif;font-size:14px;">
  <thead>
    <tr>
      <th style="text-align:left;padding:12px 16px;font-weight:bold;background:#0a1228;color:#39FF14;border-bottom:2px solid #39FF14;">Tuple</th>
    </tr>
  </thead>
  <tbody>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">1) Tuple is an <strong style="color:#39FF14;font-weight:700;">immutable</strong> ordered collection.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#172238;color:#e8eef8;">2) Elements <strong style="color:#39FF14;font-weight:700;">cannot be changed</strong> after creation.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">3) Access by index is <strong style="color:#39FF14;font-weight:700;">fast</strong>.</td></tr>
    <tr><td style="padding:12px 16px;background:#172238;color:#e8eef8;">4) Safer and slightly more <strong style="color:#39FF14;font-weight:700;">memory-efficient</strong> than lists.</td></tr>
  </tbody>
</table>

<table style="border-collapse:collapse;width:100%;max-width:720px;margin:0 0 1.25em 0;border:1px solid #39FF14;background:#050a1a;font-family:system-ui,Segoe UI,sans-serif;font-size:14px;">
  <thead>
    <tr>
      <th style="text-align:left;padding:12px 16px;font-weight:bold;background:#0a1228;color:#39FF14;border-bottom:2px solid #39FF14;">HashSet</th>
    </tr>
  </thead>
  <tbody>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">1) HashSet stores only <strong style="color:#39FF14;font-weight:700;">unique</strong> elements.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#172238;color:#e8eef8;">2) It uses <strong style="color:#39FF14;font-weight:700;">hashing</strong> for fast operations.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">3) Add, remove, and lookup are very fast <strong style="color:#39FF14;font-weight:700;">(O(1) average)</strong>.</td></tr>
    <tr><td style="padding:12px 16px;background:#172238;color:#e8eef8;">4) Does not preserve <strong style="color:#39FF14;font-weight:700;">order</strong> of elements.</td></tr>
  </tbody>
</table>

<table style="border-collapse:collapse;width:100%;max-width:720px;margin:0 0 1.25em 0;border:1px solid #39FF14;background:#050a1a;font-family:system-ui,Segoe UI,sans-serif;font-size:14px;">
  <thead>
    <tr>
      <th style="text-align:left;padding:12px 16px;font-weight:bold;background:#0a1228;color:#39FF14;border-bottom:2px solid #39FF14;">Dictionary (Map)</th>
    </tr>
  </thead>
  <tbody>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">1) Dictionary stores data as <strong style="color:#39FF14;font-weight:700;">key–value</strong> pairs.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#172238;color:#e8eef8;">2) Keys are <strong style="color:#39FF14;font-weight:700;">unique</strong> and mapped to values.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">3) Provides very fast lookup by key <strong style="color:#39FF14;font-weight:700;">(O(1) average)</strong>.</td></tr>
    <tr><td style="padding:12px 16px;background:#172238;color:#e8eef8;">4) Ideal for <strong style="color:#39FF14;font-weight:700;">indexing</strong> and fast data retrieval.</td></tr>
  </tbody>
</table>

<table style="border-collapse:collapse;width:100%;max-width:720px;margin:0 0 1.25em 0;border:1px solid #39FF14;background:#050a1a;font-family:system-ui,Segoe UI,sans-serif;font-size:14px;">
  <thead>
    <tr>
      <th style="text-align:left;padding:12px 16px;font-weight:bold;background:#0a1228;color:#39FF14;border-bottom:2px solid #39FF14;">Stack (LIFO)</th>
    </tr>
  </thead>
  <tbody>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">1) Stack follows <strong style="color:#39FF14;font-weight:700;">Last In, First Out (LIFO)</strong>.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#172238;color:#e8eef8;">2) Elements are added using <strong style="color:#39FF14;font-weight:700;">push</strong> and removed using <strong style="color:#39FF14;font-weight:700;">pop</strong>.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">3) Only the <strong style="color:#39FF14;font-weight:700;">top</strong> element is accessible.</td></tr>
    <tr><td style="padding:12px 16px;background:#172238;color:#e8eef8;">4) Used in <strong style="color:#39FF14;font-weight:700;">recursion</strong>, <strong style="color:#39FF14;font-weight:700;">undo</strong> operations, and <strong style="color:#39FF14;font-weight:700;">parsing</strong>.</td></tr>
  </tbody>
</table>

<table style="border-collapse:collapse;width:100%;max-width:720px;margin:0 0 1.25em 0;border:1px solid #39FF14;background:#050a1a;font-family:system-ui,Segoe UI,sans-serif;font-size:14px;">
  <thead>
    <tr>
      <th style="text-align:left;padding:12px 16px;font-weight:bold;background:#0a1228;color:#39FF14;border-bottom:2px solid #39FF14;">Queue (FIFO)</th>
    </tr>
  </thead>
  <tbody>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">1) Queue follows <strong style="color:#39FF14;font-weight:700;">First In, First Out (FIFO)</strong>.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#172238;color:#e8eef8;">2) Elements are added at the end (<strong style="color:#39FF14;font-weight:700;">enqueue</strong>).</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">3) Elements are removed from the front (<strong style="color:#39FF14;font-weight:700;">dequeue</strong>).</td></tr>
    <tr><td style="padding:12px 16px;background:#172238;color:#e8eef8;">4) Used in <strong style="color:#39FF14;font-weight:700;">scheduling</strong>, <strong style="color:#39FF14;font-weight:700;">buffering</strong>, and <strong style="color:#39FF14;font-weight:700;">processing</strong> tasks.</td></tr>
  </tbody>
</table>

<table style="border-collapse:collapse;width:100%;max-width:720px;margin:0 0 1.25em 0;border:1px solid #39FF14;background:#050a1a;font-family:system-ui,Segoe UI,sans-serif;font-size:14px;">
  <thead>
    <tr>
      <th style="text-align:left;padding:12px 16px;font-weight:bold;background:#0a1228;color:#39FF14;border-bottom:2px solid #39FF14;">Linked List</th>
    </tr>
  </thead>
  <tbody>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">1) Linked List stores elements as <strong style="color:#39FF14;font-weight:700;">nodes</strong> connected by <strong style="color:#39FF14;font-weight:700;">references</strong>.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#172238;color:#e8eef8;">2) Elements are <strong style="color:#39FF14;font-weight:700;">not</strong> stored in contiguous memory.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">3) Insertions/removals are <strong style="color:#39FF14;font-weight:700;">efficient</strong> (no shifting).</td></tr>
    <tr><td style="padding:12px 16px;background:#172238;color:#e8eef8;">4) Access by index is slower (requires <strong style="color:#39FF14;font-weight:700;">traversal</strong>).</td></tr>
  </tbody>
</table>

<table style="border-collapse:collapse;width:100%;max-width:720px;margin:0 0 1.25em 0;border:1px solid #39FF14;background:#050a1a;font-family:system-ui,Segoe UI,sans-serif;font-size:14px;">
  <thead>
    <tr>
      <th style="text-align:left;padding:12px 16px;font-weight:bold;background:#0a1228;color:#39FF14;border-bottom:2px solid #39FF14;">Tree</th>
    </tr>
  </thead>
  <tbody>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">1) Tree is a <strong style="color:#39FF14;font-weight:700;">hierarchical</strong> data structure with a <strong style="color:#39FF14;font-weight:700;">root</strong> node.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#172238;color:#e8eef8;">2) Each node can have multiple <strong style="color:#39FF14;font-weight:700;">child</strong> nodes.</td></tr>
    <tr><td style="padding:12px 16px;border-bottom:1px solid #2d3a5c;background:#10192e;color:#e8eef8;">3) Enables efficient <strong style="color:#39FF14;font-weight:700;">searching</strong> and organization of data.</td></tr>
    <tr><td style="padding:12px 16px;background:#172238;color:#e8eef8;">4) Used in <strong style="color:#39FF14;font-weight:700;">databases</strong>, <strong style="color:#39FF14;font-weight:700;">file systems</strong>, and <strong style="color:#39FF14;font-weight:700;">algorithms</strong>.</td></tr>
  </tbody>
</table>

**Note:** Linked list is included for the deck narrative; optional live code can be added later. Repo examples follow the main agenda (array → … → tree/BST). **Light theme alternative:** if you need a printable handout with light rows, use body text `#1a1a1a` and header fill `#b8c4a8` instead of the palette above.
