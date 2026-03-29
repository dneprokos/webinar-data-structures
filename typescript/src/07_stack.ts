/** Stack LIFO: pool of client ids for parallel tests. */

const pool: number[] = [];
for (const id of [101, 102, 103]) pool.push(id);

const taken = pool.pop()!;
console.log(`Test uses client ${taken}; pool left: ${pool.length}`);
pool.push(taken);
console.log(`Returned client; pool size: ${pool.length}`);
