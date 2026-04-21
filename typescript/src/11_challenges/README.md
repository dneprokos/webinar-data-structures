# Coding Challenges

## About This Section

This section contains practical coding challenges that combine multiple data structures and algorithms. Each challenge is a realistic problem you might encounter in a coding interview, on the job, or while building QA automation tooling.

## Challenges

### 01 — Most Frequent Character

**Problem:** Given a string, find the character that appears most often and return both the character and its count.

**Key concepts:** Dictionary (frequency map), iteration, aggregation.

**Example:**
```
Input:  "Beware the whispering winds of the Wandering Wastes"
Output: ' ' (space) × 7
```

**Why it matters for QA:** You can apply the same pattern to find the most common error message in a test log, the most-hit API endpoint in access logs, or the most frequently failing test in a CI history.

## How to Run

```bash
# C#
dotnet run -- challenge

# Python
python 10_challenges/01_most_frequent_char.py

# TypeScript
npx tsx 10_challenges/01_most_frequent_char.ts
```
