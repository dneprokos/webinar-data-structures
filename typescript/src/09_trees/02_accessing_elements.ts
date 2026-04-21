/** Searching and traversing the BST in TypeScript. */

class TreeNode {
  left: TreeNode | null = null;
  right: TreeNode | null = null;
  constructor(readonly value: number) {}
}

class BinarySearchTree {
  private root: TreeNode | null = null;
  insert(value: number): void { this.root = this.ins(this.root, value); }
  private ins(n: TreeNode | null, v: number): TreeNode {
    if (!n) return new TreeNode(v);
    if (v <= n.value) n.left = this.ins(n.left, v); else n.right = this.ins(n.right, v);
    return n;
  }
  contains(value: number): boolean {
    let n = this.root;
    while (n) { if (value === n.value) return true; n = value < n.value ? n.left : n.right; }
    return false;
  }
  inOrder(): number[] {
    const r: number[] = [];
    const v = (n: TreeNode | null): void => { if (!n) return; v(n.left); r.push(n.value); v(n.right); };
    v(this.root); return r;
  }
}

const tree = new BinarySearchTree();
for (const v of [10, 5, 15, 3, 7, 12, 20]) tree.insert(v);

console.log("=== Contains (O(log n) average) ===");
console.log("contains(7)   =", tree.contains(7));
console.log("contains(99)  =", tree.contains(99));
console.log("contains(15)  =", tree.contains(15));

console.log("\n=== In-order traversal (sorted output) ===");
const inOrder = tree.inOrder();
console.log("in-order:", inOrder);

console.log("\n=== Min / Max ===");
console.log("min =", inOrder[0]);
console.log("max =", inOrder[inOrder.length - 1]);
