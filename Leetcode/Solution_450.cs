// 450. Delete Node in a BST

#region Вариант 1 - Мой - Runtime 0 ms, Beats 100.00%, Memory 51.42 MB Beats 7.61%
public class Solution_450_1
{
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root is null)
        {
            return null;
        }

        if (root.val == key)
        {
            return DeleteRoot(root);
        }

        var parent = FindParentNode(root, key);

        if (parent is null)
        {
            return root;
        }

        if (parent.left?.val == key)
        {
            DeleteLeftNode(parent);
        }
        else
        {
            DeleteRightNode(parent);
        }

        return root;
    }

    private TreeNode FindParentNode(TreeNode root, int key)
    {
        var node = root;

        while (node is not null)
        {
            if (key < node.val)
            {
                if (node.left is null)
                {
                    return null;
                }

                if (node.left.val == key)
                {
                    return node;
                }

                node = node.left;
            }
            else
            {
                if (node.right is null)
                {
                    return null;
                }

                if (node.right.val == key)
                {
                    return node;
                }

                node = node.right;
            }
        }

        return node;
    }

    private TreeNode FindLeftmostParentInRightSubtree(TreeNode node)
    {
        var leftmostParent = node.right;

        while (leftmostParent.left.left is not null)
        {
            leftmostParent = leftmostParent.left;
        }

        return leftmostParent;
    }

    private TreeNode DeleteRoot(TreeNode root)
    {
        if (root.left is null)
        {
            root = root.right;
            return root;
        }

        if (root.right is null)
        {
            root = root.left;
            return root;
        }

        if (root.right.left is null)
        {
            root.right.left = root.left;
            root = root.right;
            return root;
        }

        var parentOfNextValue = FindLeftmostParentInRightSubtree(root);

        var deletedNodeRight = parentOfNextValue.left.right;
        parentOfNextValue.left.left = root.left;
        parentOfNextValue.left.right = root.right;
        root = parentOfNextValue.left;
        parentOfNextValue.left = deletedNodeRight;

        return root;
    }

    private void DeleteLeftNode(TreeNode parent)
    {
        // 1 случай - нет потомков
        if (parent.left.left is null && parent.left.right is null)
        {
            parent.left = null;
            return;
        }

        // 2 случай - есть один потомок
        if (parent.left.left is not null && parent.left.right is null)
        {
            parent.left = parent.left.left;
            return;
        }

        if (parent.left.left is null && parent.left.right is not null)
        {
            parent.left = parent.left.right;
            return;
        }

        // 3 случай - есть оба потомка
        if (parent.left.right.left is null)
        {
            parent.left.right.left = parent.left.left;
            parent.left = parent.left.right;
            return;
        }

        var parentOfNextValue = FindLeftmostParentInRightSubtree(parent.left);

        var deletedNodeRight = parentOfNextValue.left.right;
        parentOfNextValue.left.left = parent.left.left;
        parentOfNextValue.left.right = parent.left.right;
        parent.left = parentOfNextValue.left;
        parentOfNextValue.left = deletedNodeRight;
    }

    private void DeleteRightNode(TreeNode parent)
    {
        // 1 случай - нет потомков
        if (parent.right.left is null && parent.right.right is null)
        {
            parent.right = null;
            return;
        }

        // 2 случай - есть один потомок
        if (parent.right.left is not null && parent.right.right is null)
        {
            parent.right = parent.right.left;
            return;
        }

        if (parent.right.left is null && parent.right.right is not null)
        {
            parent.right = parent.right.right;
            return;
        }

        // 3 случай - есть оба потомка
        if (parent.right.right.left is null)
        {
            parent.right.right.left = parent.right.left;
            parent.right = parent.right.right;
            return;
        }

        var parentOfNextValue = FindLeftmostParentInRightSubtree(parent.right);

        var deletedNodeRight = parentOfNextValue.left.right;
        parentOfNextValue.left.left = parent.right.left;
        parentOfNextValue.left.right = parent.right.right;
        parent.right = parentOfNextValue.left;
        parentOfNextValue.left = deletedNodeRight;
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
#endregion

#region Вариант 2 - Leetcode - Runtime 0 ms, Beats 100.00%, Memory 51.21 MB, Beats 14.13%
public class Solution_450_2
{
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root is null)
        {
            return null;
        }

        if (key > root.val)
        {
            // удалить из правого поддерева
            root.right = DeleteNode(root.right, key);
        }
        else if (key < root.val)
        {
            // удалить из левого поддерева
            root.left = DeleteNode(root.left, key);
        }
        else
        {
            // удалить текущий узел
            if (root.left is null && root.right is null)
            {
                root = null;
            }
            else if (root.right is not null)
            {
                root.val = FindSuccessor(root);
                root.right = DeleteNode(root.right, root.val);
            }
            else
            {
                root.val = FindPredecessor(root);
                root.left = DeleteNode(root.left, root.val);
            }
        }

        return root;
    }

    private int FindSuccessor(TreeNode node)
    {
        node = node.right;

        while (node.left is not null)
        {
            node = node.left;
        }

        return node.val;
    }

    private int FindPredecessor(TreeNode node)
    {
        node = node.left;

        while (node.right is not null)
        {
            node = node.right;
        }

        return node.val;
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
#endregion
