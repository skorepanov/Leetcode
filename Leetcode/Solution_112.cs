// 112. Path Sum
public class Solution_112
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root is null)
        {
            return false;
        }

        return HasPathSum(root, targetSum, 0);
    }

    private bool HasPathSum(TreeNode node, int targetSum, int currentSum)
    {
        currentSum += node.val;

        if (node.left is null && node.right is null)
        {
            return currentSum == targetSum;
        }

        return node.left is not null && HasPathSum(node.left, targetSum, currentSum)
            || node.right is not null && HasPathSum(node.right, targetSum, currentSum);
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