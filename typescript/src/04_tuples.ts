/** Tuple return: user + orders without a dedicated class (or use a small type). */

type UserSummary = { id: string; name: string };

function getUserWithOrders(userId: string): [UserSummary, string[]] {
  return [{ id: userId, name: "Ann" }, ["o1", "o2"]];
}

const [user, orders] = getUserWithOrders("u1");
console.log(`${user.name} has ${orders.length} orders`);
