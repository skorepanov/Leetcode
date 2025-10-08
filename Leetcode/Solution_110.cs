// 110. Balanced Binary Tree
public class Solution_110
{
    public bool IsBalanced(TreeNode root)
    {
        if (root is null)
        {
            return true;
        }

        var leftHeight = GetHeight(root.left);
        var rightHeight = GetHeight(root.right);

        return Math.Abs(leftHeight - rightHeight) <= 1
            && IsBalanced(root.left)
            && IsBalanced(root.right);
    }

    private int GetHeight(TreeNode node)
    {
        if (node is null)
        {
            return -1;
        }

        var leftHeight = GetHeight(node.left);
        var rightHeight = GetHeight(node.right);

        return Math.Max(leftHeight, rightHeight) + 1;
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