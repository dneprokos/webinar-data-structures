"""Converting BST to sorted list, and building BST from unsorted data."""
from __future__ import annotations


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
        if node is None:
            return TreeNode(value)
        if value <= node.value:
            node.left = self._insert(node.left, value)
        else:
            node.right = self._insert(node.right, value)
        return node

    def in_order(self) -> list[int]:
        result: list[int] = []
        def visit(n: TreeNode | None) -> None:
            if n is None: return
            visit(n.left); result.append(n.value); visit(n.right)
        visit(self._root)
        return result


def run() -> None:
    print("=== BST → sorted list (in-order) ===")
    tree = BinarySearchTree()
    for v in (5, 3, 7, 1, 4, 6, 8):
        tree.insert(v)
    print(f"in-order list: {tree.in_order()}")

    print("\n=== Unsorted list → BST → sorted list ===")
    unsorted = [9, 2, 7, 1, 5]
    tree2 = BinarySearchTree()
    for v in unsorted:
        tree2.insert(v)
    print(f"input:   {unsorted}")
    print(f"sorted:  {tree2.in_order()}")


if __name__ == "__main__":
    run()
