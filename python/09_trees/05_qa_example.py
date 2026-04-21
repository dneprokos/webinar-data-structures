"""Practical QA automation examples using trees in Python."""
from __future__ import annotations
from dataclasses import dataclass, field


@dataclass
class MenuNode:
    label: str
    children: list["MenuNode"] = field(default_factory=list)

    def add_child(self, label: str) -> "MenuNode":
        child = MenuNode(label)
        self.children.append(child)
        return child

    def all_descendants(self) -> list["MenuNode"]:
        result = []
        for child in self.children:
            result.append(child)
            result.extend(child.all_descendants())
        return result


class TreeNode:
    def __init__(self, value: int) -> None:
        self.value = value
        self.left: TreeNode | None = None
        self.right: TreeNode | None = None


class BinarySearchTree:
    def __init__(self) -> None:
        self._root: TreeNode | None = None

    def insert(self, value: int) -> None:
        self._root = self._insert(self._root, value)

    def _insert(self, node: TreeNode | None, value: int) -> TreeNode:
        if node is None: return TreeNode(value)
        if value <= node.value: node.left = self._insert(node.left, value)
        else: node.right = self._insert(node.right, value)
        return node

    def contains(self, value: int) -> bool:
        n = self._root
        while n:
            if value == n.value: return True
            n = n.left if value < n.value else n.right
        return False

    def in_order(self) -> list[int]:
        r: list[int] = []
        def v(n: TreeNode | None) -> None:
            if n: v(n.left); r.append(n.value); v(n.right)
        v(self._root)
        return r


def run() -> None:
    print("=== Validate navigation menu hierarchy ===")
    menu = MenuNode("Home")
    products = menu.add_child("Products")
    products.add_child("Electronics")
    products.add_child("Clothing")
    support = menu.add_child("Support")
    support.add_child("FAQ")
    support.add_child("Contact")

    all_labels = [n.label for n in menu.all_descendants()]
    print(f"Root: {menu.label!r}")
    print(f"Children: {[c.label for c in menu.children]}")
    print(f"All items: {all_labels}")
    print(f"Contains 'FAQ': {'FAQ' in all_labels}")
    print(f"Contains 'Admin': {'Admin' in all_labels}")

    print("\n=== Response time percentiles using BST sort ===")
    times = [245, 120, 380, 95, 210, 450, 175]
    tree = BinarySearchTree()
    for t in times:
        tree.insert(t)
    sorted_times = tree.in_order()
    p50 = sorted_times[len(sorted_times) // 2]
    p95 = sorted_times[int(len(sorted_times) * 0.95)]
    print(f"sorted: {sorted_times}")
    print(f"p50={p50}ms  p95={p95}ms  max={sorted_times[-1]}ms")


if __name__ == "__main__":
    run()
