"""Building a Binary Search Tree in Python."""
from __future__ import annotations


class TreeNode:
    def __init__(self, value: int) -> None:
        self.value = value
        self.left: TreeNode | None = None
        self.right: TreeNode | None = None


class BinarySearchTree:
    def __init__(self) -> None:
        self._root: TreeNode | None = None
        self.count = 0

    def insert(self, value: int) -> None:
        self._root = self._insert(self._root, value)
        self.count += 1

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
    print("=== Create BST and insert values ===")
    tree = BinarySearchTree()
    for v in (10, 5, 15, 3, 7, 12, 20):
        tree.insert(v)
        print(f"insert({v:3}) -> count={tree.count}")

    print("\nStructure after inserting [10,5,15,3,7,12,20]:")
    print("          10")
    print("         /  \\")
    print("        5    15")
    print("       / \\  /  \\")
    print("      3   7 12  20")


if __name__ == "__main__":
    run()
