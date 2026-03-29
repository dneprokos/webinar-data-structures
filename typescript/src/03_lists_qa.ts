/** Lists: counting found items / variable-length API payloads. */

const foundRows = ["row-a", "row-b"];
console.log(`Count == 0? ${foundRows.length === 0}`);
console.log(`Count >= 2? ${foundRows.length >= 2}`);

type OrderRow = { code: string; amount: number };
const apiRecords: OrderRow[] = [
  { code: "A", amount: 10 },
  { code: "B", amount: 20 },
];
console.log(`API returned ${apiRecords.length} records (unknown upfront).`);
