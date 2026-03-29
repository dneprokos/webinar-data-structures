# Webinar: Data structures (C#, TypeScript, Python)

Code examples and a slide outline for the talk **«Структури даних у програмуванні: від теорії до практики»**.

- **Slide plan:** [SLIDES_PLAN.md](./SLIDES_PLAN.md)

## Prerequisites

| Stack       | Requirement |
|------------|-------------|
| C#         | [.NET SDK](https://dotnet.microsoft.com/download) 8.0 or newer (9.x works) |
| TypeScript | [Node.js](https://nodejs.org/) 18+ (includes `npm`) |
| Python     | Python 3.8+ (3.10+ recommended) |

## Repository layout

```
webinar-data-structures/
├── SLIDES_PLAN.md
├── csharp/DataStructuresQA/   # .NET console app (all examples)
├── typescript/                # Node + tsx, one file per topic
└── python/                    # One script per topic
```

Numbered topics (same order everywhere): `01` arrays → `11` most-frequent-character challenge.

---

## C# (`csharp/DataStructuresQA`)

### Build

```bash
cd csharp/DataStructuresQA
dotnet build
```

### Run

Run **all** examples in order (default):

```bash
dotnet run
```

Run a **single** topic by key:

```bash
dotnet run -- arrays
dotnet run -- generics
dotnet run -- lists
dotnet run -- tuples
dotnet run -- sets
dotnet run -- maps
dotnet run -- stack
dotnet run -- queue
dotnet run -- tree
dotnet run -- transforms
dotnet run -- challenge
```

List keys:

```bash
dotnet run -- help
```

From the repo root (any shell):

```bash
dotnet run --project csharp/DataStructuresQA/DataStructuresQA.csproj -- challenge
```

---

## TypeScript (`typescript`)

### Install

```bash
cd typescript
npm install
```

### Run

Per file with `tsx`:

```bash
npx tsx src/01_arrays.ts
npx tsx src/02_generics_api_response.ts
npx tsx src/03_lists_qa.ts
npx tsx src/04_tuples.ts
npx tsx src/05_sets.ts
npx tsx src/06_maps.ts
npx tsx src/07_stack.ts
npx tsx src/08_queue.ts
npx tsx src/09_tree_bst.ts
npx tsx src/10_collection_transforms.ts
npx tsx src/11_challenge_most_frequent_char.ts
```

Or use npm scripts:

```bash
npm run arrays
npm run generics
npm run lists
npm run tuples
npm run sets
npm run maps
npm run stack
npm run queue
npm run tree
npm run transforms
npm run challenge
```

Optional typecheck (no emit):

```bash
npx tsc --noEmit
```

---

## Python (`python`)

No install step; standard library only (plus `dataclasses` / `typing` / `enum` / `collections`).

Run from the `python` folder:

```bash
cd python
python 01_arrays.py
python 02_generics_api_response.py
python 03_lists_qa.py
python 04_tuples.py
python 05_sets.py
python 06_maps.py
python 07_stack.py
python 08_queue.py
python 09_tree_bst.py
python 10_collection_transforms.py
python 11_challenge_most_frequent_char.py
```

On some systems the launcher is `python3` instead of `python`.

---

## Git

This folder is a Git repository. After cloning elsewhere:

```bash
cd webinar-data-structures
cd typescript && npm install && cd ..
```

`node_modules/`, `bin/`, `obj/`, `__pycache__/`, and common IDE files are ignored via `.gitignore`.
