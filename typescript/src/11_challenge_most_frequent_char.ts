/** Frequency map + reduce: most common character. */

function mostFrequentChar(text: string): { character: string; count: number } {
  const freq = new Map<string, number>();
  for (const ch of text) freq.set(ch, (freq.get(ch) ?? 0) + 1);

  let bestChar = "";
  let bestCount = -1;
  for (const [ch, n] of freq) {
    if (n > bestCount) {
      bestCount = n;
      bestChar = ch;
    }
  }
  return { character: bestChar, count: bestCount };
}

const text = "Beware the whispering winds of the Wandering Wastes";
const r = mostFrequentChar(text);
console.log(`'${r.character}' x ${r.count}`);
