// 98. Validate Binary Search Tree
public class Solution_98
{
    public bool IsValidBST(TreeNode root)
    {
        return IsValidBST(root, minValue: long.MinValue, maxValue: long.MaxValue);
    }

    private bool IsValidBST(TreeNode node, long minValue, long maxValue)
    {
        if (node is null)
        {
            return true;
        }

        if (node.val <= minValue || node.val >= maxValue)
        {
            return false;
        }

        return IsValidBST(node.left, minValue, node.val)
            && IsValidBST(node.right, node.val, maxValue);
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