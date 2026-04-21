/** Creating tuples in TypeScript — typed fixed-length arrays. */

// Basic tuple types.
const pair: [number, string] = [1, "hello"];
console.log("=== Basic tuples ===");
console.log(`[number, string]: [0]=${pair[0]}, [1]=${pair[1]}`);

const triple: [boolean, number, string] = [true, 3.14, "x"];
console.log(`[bool,num,str]:   ${triple}`);

// Named tuple via type alias — improves readability.
type UserSummary = { id: string; name: string };
type UserWithOrders = [UserSummary, string[]];

function getUserWithOrders(userId: string): UserWithOrders {
  return [{ id: userId, name: "Ann" }, ["o1", "o2"]];
}

console.log("\n=== Tuple from function ===");
const [user, orders] = getUserWithOrders("u1");
console.log(`${user.name} has ${orders.length} orders`);

// Readonly tuple — prevents mutation.
const httpStatus: readonly [number, string, boolean] = [200, "OK", true];
console.log("\n=== Readonly tuple ===");
console.log(`code=${httpStatus[0]}, msg=${httpStatus[1]}, ok=${httpStatus[2]}`);
