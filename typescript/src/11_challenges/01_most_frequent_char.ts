/**
 * Challenge: Find the most frequent character in a string.
 * Uses a Map frequency counter, then iterate to find the max.
 *
 * QA relevance: Same pattern finds the most common error message in test logs,
 * the most-hit API endpoint in access logs, or the most-failing test in CI history.
 */

function getMostFrequentChar(text: string): { character: string; count: number } {
  const freq = new Map<string, number>();
  for (const ch of text) freq.set(ch, (freq.get(ch) ?? 0) + 1);

  let bestChar = "";
  let bestCount = -1;
  for (const [ch, n] of freq) {
    if (n > bestCount) { bestCount = n; bestChar = ch; }
  }
  return { character: bestChar, count: bestCount };
}

// ── Basic challenge ───────────────────────────────────────────────────────────

console.log("=== Most frequent character ===");
const phrase = "Beware the whispering winds of the Wandering Wastes";
const { character, count } = getMostFrequentChar(phrase);
console.log(`Input: "${phrase}"`);
console.log(`Most frequent: '${character}' x ${count}`);

// ── QA log analysis ───────────────────────────────────────────────────────────

console.log("\n=== QA: Most frequent error in test log ===");
const logLines = [
  "TimeoutException: element not found",
  "AssertionError: expected 200 got 404",
  "TimeoutException: element not found",
  "NullReferenceException: object not set",
  "AssertionError: expected 200 got 404",
  "TimeoutException: element not found",
  "AssertionError: expected 200 got 404",
  "StaleElementException: element stale",
];

const errorTypes = logLines.map((l) => l.split(":")[0].trim());
const freq = errorTypes.reduce((m, e) => m.set(e, (m.get(e) ?? 0) + 1), new Map<string, number>());

console.log("Error frequency:");
[...freq.entries()].sort(([, a], [, b]) => b - a).forEach(([e, n]) => {
  console.log(`  ${e.padEnd(35)} x${n}`);
});

const [topError, topCount] = [...freq.entries()].reduce((best, cur) => cur[1] > best[1] ? cur : best);
console.log(`\nMost common error: ${topError} (${topCount} occurrences)`);
