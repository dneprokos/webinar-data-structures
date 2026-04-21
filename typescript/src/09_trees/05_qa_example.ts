/** Practical QA automation examples using trees in TypeScript. */

type MenuNode = { label: string; children: MenuNode[] };

function createMenu(label: string): MenuNode { return { label, children: [] }; }
function addChild(parent: MenuNode, label: string): MenuNode {
  const child = createMenu(label);
  parent.children.push(child);
  return child;
}
function allDescendants(node: MenuNode): MenuNode[] {
  return node.children.flatMap((c) => [c, ...allDescendants(c)]);
}

// BST for sorted lookup.
class TreeNode { left: TreeNode | null = null; right: TreeNode | null = null; constructor(readonly value: number) {} }
class BinarySearchTree {
  private root: TreeNode | null = null;
  insert(v: number): void { this.root = this.ins(this.root, v); }
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
  inOrder(): number[] {
    const r: number[] = [];
    const f = (n: TreeNode | null): void => { if (!n) return; f(n.left); r.push(n.value); f(n.right); };
    f(this.root); return r;
  }
}

console.log("=== Validate navigation menu hierarchy ===");
const menu = createMenu("Home");
const products = addChild(menu, "Products");
addChild(products, "Electronics");
addChild(products, "Clothing");
const support = addChild(menu, "Support");
addChild(support, "FAQ");
addChild(support, "Contact");

const allLabels = allDescendants(menu).map((n) => n.label);
console.log("Root:", menu.label);
console.log("Children:", menu.children.map((c) => c.label));
console.log("All items:", allLabels);
console.log("Contains 'FAQ':", allLabels.includes("FAQ"));
console.log("Contains 'Admin':", allLabels.includes("Admin"));

console.log("\n=== Response time percentiles using BST sort ===");
const times = [245, 120, 380, 95, 210, 450, 175];
const bst = new BinarySearchTree();
for (const t of times) bst.insert(t);
const sorted = bst.inOrder();
const p50 = sorted[Math.floor(sorted.length / 2)];
const p95 = sorted[Math.floor(sorted.length * 0.95)];
console.log("sorted:", sorted);
console.log(`p50=${p50}ms  p95=${p95}ms  max=${sorted[sorted.length - 1]}ms`);
