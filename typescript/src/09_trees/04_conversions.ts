/** Converting BST to sorted array, and building BST from unsorted data. */

class TreeNode {
  left: TreeNode | null = null; right: TreeNode | null = null;
  constructor(readonly value: number) {}
}
class BinarySearchTree {
  private root: TreeNode | null = null;
  insert(v: number): void { this.root = this.ins(this.root, v); }
  private ins(n: TreeNode | null, v: number): TreeNode {
    if (!n) return new TreeNode(v);
    if (v <= n.value) n.left = this.ins(n.left, v); else n.right = this.ins(n.right, v);
    return n;
  }
  inOrder(): number[] {
    const r: number[] = [];
    const f = (n: TreeNode | null): void => { if (!n) return; f(n.left); r.push(n.value); f(n.right); };
    f(this.root); return r;
  }
}

console.log("=== BST → sorted array (in-order) ===");
const tree = new BinarySearchTree();
for (const v of [5, 3, 7, 1, 4, 6, 8]) tree.insert(v);
console.log("in-order list:", tree.inOrder());

console.log("\n=== Unsorted array → BST → sorted array ===");
const unsorted = [9, 2, 7, 1, 5];
const tree2 = new BinarySearchTree();
for (const v of unsorted) tree2.insert(v);
console.log("input:  ", unsorted);
console.log("sorted: ", tree2.inOrder());
