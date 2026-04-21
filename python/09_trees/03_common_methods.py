"""Insert, search, and all traversal orders for Python BST."""
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
            if n is None: return
            visit(n.left); result.append(n.value); visit(n.right)
        visit(self._root)
        return result

    def pre_order(self) -> list[int]:
        result: list[int] = []
        def visit(n: TreeNode | None) -> None:
            if n is None: return
            result.append(n.value); visit(n.left); visit(n.right)
        visit(self._root)
        return result

    def post_order(self) -> list[int]:
        result: list[int] = []
        def visit(n: TreeNode | None) -> None:
            if n is None: return
            visit(n.left); visit(n.right); result.append(n.value)
        visit(self._root)
        return result


def run() -> None:
    tree = BinarySearchTree()
    for v in (10, 5, 15, 3, 7, 12, 20):
        tree.insert(v)

    print("=== Insert and search ===")
    tree.insert(6)
    print(f"after insert(6): contains(6)={tree.contains(6)}")

    print("\n=== Traversals ===")
    print(f"in-order   (sorted):        {tree.in_order()}")
    print(f"pre-order  (root first):    {tree.pre_order()}")
    print(f"post-order (leaves first):  {tree.post_order()}")

    print(f"\nNode count: {tree.count}")


if __name__ == "__main__":
    run()
