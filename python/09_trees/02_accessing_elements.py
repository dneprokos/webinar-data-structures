"""Searching and traversing the BST in Python."""
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

    def contains(self, value: int) -> bool:
        node = self._root
        while node is not None:
            if value == node.value:
                return True
            node = node.left if value < node.value else node.right
        return False

    def in_order(self) -> list[int]:
        result: list[int] = []
        def visit(n: TreeNode | None) -> None:
            if n is None:
                return
            visit(n.left)
            result.append(n.value)
            visit(n.right)
        visit(self._root)
        return result


def run() -> None:
    tree = BinarySearchTree()
    for v in (10, 5, 15, 3, 7, 12, 20):
        tree.insert(v)

    print("=== Contains (O(log n) average) ===")
    print(f"contains(7)   = {tree.contains(7)}")
    print(f"contains(99)  = {tree.contains(99)}")
    print(f"contains(15)  = {tree.contains(15)}")

    print("\n=== In-order traversal (sorted output) ===")
    in_order = tree.in_order()
    print(f"in-order: {in_order}")

    print("\n=== Min / Max ===")
    print(f"min = {in_order[0]}")
    print(f"max = {in_order[-1]}")


if __name__ == "__main__":
    run()
