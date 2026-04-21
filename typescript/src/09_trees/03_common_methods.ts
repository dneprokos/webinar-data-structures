/** Insert, search, and all traversal orders for TypeScript BST. */

class TreeNode {
  left: TreeNode | null = null;
  right: TreeNode | null = null;
  constructor(readonly value: number) {}
}

class BinarySearchTree {
  private root: TreeNode | null = null;
  count = 0;

  insert(v: number): void { this.root = this.ins(this.root, v); this.count++; }
  private ins(n: TreeNode | null, v: number): TreeNode {
    if (!n) return new TreeNode(v);
    if (v <= n.value) n.left = this.ins(n.left, v); else n.right = this.ins(n.right, v);
    return n;
  }
  contains(v: number): boolean {
    let n = this.root;
    while (n) { if (v === n.value) return true; n = v < n.value ? n.left : n.right; }
    return false;
  }
  inOrder(): number[]   { const r: number[] = []; const f = (n: TreeNode | null): void => { if (!n) return; f(n.left); r.push(n.value); f(n.right); }; f(this.root); return r; }
  preOrder(): number[]  { const r: number[] = []; const f = (n: TreeNode | null): void => { if (!n) return; r.push(n.value); f(n.left); f(n.right); }; f(this.root); return r; }
  postOrder(): number[] { const r: number[] = []; const f = (n: TreeNode | null): void => { if (!n) return; f(n.left); f(n.right); r.push(n.value); }; f(this.root); return r; }
}

const tree = new BinarySearchTree();
for (const v of [10, 5, 15, 3, 7, 12, 20]) tree.insert(v);

console.log("=== Insert and search ===");
tree.insert(6);
console.log("after insert(6): contains(6) =", tree.contains(6));

console.log("\n=== Traversals ===");
console.log("in-order   (sorted):       ", tree.inOrder());
console.log("pre-order  (root first):   ", tree.preOrder());
console.log("post-order (leaves first): ", tree.postOrder());

console.log("\nNode count:", tree.count);
