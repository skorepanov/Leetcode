// 101. Symmetric Tree
public class Solution_101
{
    public bool IsSymmetric(TreeNode root)
    {
        return IsSymmetric(root.left, root.right);
    }

    private bool IsSymmetric(TreeNode left, TreeNode right)
    {
        if (left is null && right is null)
        {
            return true;
        }

        if (left is null || right is null || left.val != right.val)
        {
            return false;
        }

        return IsSymmetric(left.left, right.right)
            && IsSymmetric(left.right, right.left);
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