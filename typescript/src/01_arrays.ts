/** Fixed-size feel: typed arrays; query string + digit sum (QA article patterns). */

export function buildQueryString(ids: readonly number[]): string {
  return `?ids=${ids.join(",")}`;
}

export function sumDigitCharacters(text: string): number {
  let sum = 0;
  for (const ch of text) {
    if (ch >= "0" && ch <= "9") sum += ch.charCodeAt(0) - "0".charCodeAt(0);
  }
  return sum;
}

console.log(buildQueryString([2, 5, 7]));
console.log(sumDigitCharacters("a1b2c3"));
