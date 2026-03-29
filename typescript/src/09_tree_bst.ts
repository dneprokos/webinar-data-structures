/** Minimal binary search tree — insert + contains. */

class TreeNode {
  left: TreeNode | null = null;
  right: TreeNode | null = null;
  constructor(readonly value: number) {}
}

class BinarySearchTree {
  private root: TreeNode | null = null;

  insert(value: number): void {
    this.root = this.insertNode(this.root, value);
  }

  private insertNode(node: TreeNode | null, value: number): TreeNode {
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
}

const tree = new BinarySearchTree();
for (const v of [10, 5, 15, 3, 7]) tree.insert(v);
console.log(tree.contains(7));
console.log(tree.contains(99));
