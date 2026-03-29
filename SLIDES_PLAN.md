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
| 5 | Agenda | Arrays → generics/types → lists → tuples → sets → maps → stack → queue → tree/BST → collection transforms → final challenge | — |

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
| `csharp/DataStructuresQA` | From the project directory: `dotnet run` (all demos) or `dotnet run -- arrays` / `dotnet run -- challenge`, etc.; `dotnet run -- help` lists keys |
| `typescript` | `npm install` → `npx tsx src/01_arrays.ts` (change the filename as needed) |
| `python` | `python 01_arrays.py` (from the `python/` folder) |

**Slide tip:** show 5–15 lines of the “core” on a slide; keep the full file for live demo or homework.

---

## File numbering map

| File | Topic |
|------|--------|
| `01_arrays` | Arrays, query string, digit sum |
| `02_generics_api_response` | Generic API response model |
| `03_lists_qa` | Lists and QA scenarios |
| `04_tuples` | Tuples, returning multiple values |
| `05_sets` | Sets, deduplication, operations |
| `06_maps` | Maps/dicts, SQL operators, config |
| `07_stack` | Stack, LIFO resource pool |
| `08_queue` | FIFO queue |
| `09_tree_bst` | Minimal BST, lookup |
| `10_collection_transforms` | LINQ / map-filter / comprehension |
| `11_challenge_most_frequent_char` | Dict + sorting combined |
