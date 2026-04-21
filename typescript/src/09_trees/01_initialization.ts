/** Building a Binary Search Tree in TypeScript. */

class TreeNode {
  left: TreeNode | null = null;
  right: TreeNode | null = null;
  constructor(readonly value: number) {}
}

class BinarySearchTree {
  protected root: TreeNode | null = null;
  count = 0;

  insert(value: number): void {
    this.root = this.insertNode(this.root, value);
    this.count++;
  }

  protected insertNode(node: TreeNode | null, value: number): TreeNode {
    if (!node) return new TreeNode(value);
    if (value <= node.value) node.left = this.insertNode(node.left, value);
    else node.right = this.insertNode(node.right, value);
    return node;
  }

  contains(value: number): boolean {
    let node = this.root;
    while (node) {
      if (value === node.value) return true;
      node = value < node.value ? node.left : node.right;
    }
    return false;
  }

  inOrder(): number[] {
    const result: number[] = [];
    const visit = (n: TreeNode | null): void => {
      if (!n) return;
      visit(n.left); result.push(n.value); visit(n.right);
    };
    visit(this.root);
    return result;
  }
}

// ── Run ───────────────────────────────────────────────────────────────────────

const tree = new BinarySearchTree();
console.log("=== Create BST and insert values ===");
for (const v of [10, 5, 15, 3, 7, 12, 20]) {
  tree.insert(v);
  console.log(`insert(${String(v).padStart(2)}) -> count=${tree.count}`);
}

console.log("\nStructure after inserting [10,5,15,3,7,12,20]:");
console.log("          10");
console.log("         /  \\");
console.log("        5    15");
console.log("       / \\  /  \\");
console.log("      3   7 12  20");
