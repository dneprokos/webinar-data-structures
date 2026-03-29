"""Minimal binary search tree — insert + contains."""

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


if __name__ == "__main__":
    tree = BinarySearchTree()
    for v in (10, 5, 15, 3, 7):
        tree.insert(v)
    print(tree.contains(7))
    print(tree.contains(99))
