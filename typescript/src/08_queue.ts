/** Queue FIFO: use array + shift (for large queues prefer a deque library). */

const jobs: string[] = [];
jobs.push("sync-users", "purge-cache", "notify-slack");

while (jobs.length > 0) {
  const next = jobs.shift()!;
  console.log("processing:", next);
}
