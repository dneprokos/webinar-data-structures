/** Map / record: SQL operator tokens and in-run lookup. */

const SqlOperator = {
  Equals: "Equals",
  Like: "Like",
  In: "In",
} as const;

type SqlOperator = (typeof SqlOperator)[keyof typeof SqlOperator];

const sqlByOp: Record<SqlOperator, string> = {
  [SqlOperator.Equals]: "=",
  [SqlOperator.Like]: "LIKE",
  [SqlOperator.In]: "IN",
};

function buildPredicate(column: string, op: SqlOperator, value: string): string {
  return `${column} ${sqlByOp[op]} ${value}`;
}

console.log(buildPredicate("email", SqlOperator.Like, "%@test.com"));

const bookPrices = new Map<string, number>([
  ["Clean Code", 42.5],
  ["Refactoring", 39],
]);

const lookup = [...bookPrices.entries()].find(
  ([title]) => title.toLowerCase() === "clean code",
);
console.log(lookup?.[1] ?? 0);
