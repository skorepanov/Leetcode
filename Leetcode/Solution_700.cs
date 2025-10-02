// 700. Search in a Binary Search Tree

#region Вариант 1 - Рекурсивно - Runtime 0 ms, Beats 100.00%; Memory: 50.90 MB, Beats 94.30%
public class Solution_700_1
{
    public TreeNode SearchBST(TreeNode root, int val)
    {
        if (root is null)
        {
            return null;
        }

        if (root.val == val)
        {
            return root;
        }

        return root.val > val
            ? SearchBST(root.left, val)
            : SearchBST(root.right, val);
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

#region Вариант 2 - Итеративно - Runtime 0 ms, Beats 100.00%; Memory: 51.33 MB, Beats 34.83%
public class Solution_700_2
{
    public TreeNode SearchBST(TreeNode root, int val)
    {
        var node = root;

        while (node is not null && node.val != val)
        {
            node = val < node.val ? node.left : node.right;
        }

        return node;
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
