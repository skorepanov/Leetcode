// 250. Count Univalue Subtrees
public class Solution_250
{
    public int CountUnivalSubtrees(TreeNode root)
    {
        var count = 0;

        IsUnivalSubtree(root, ref count);

        return count;
    }

    private bool IsUnivalSubtree(TreeNode node, ref int count)
    {
        if (node is null)
        {
            return true;
        }

        var isLeftUnival = IsUnivalSubtree(node.left, ref count);
        var isRightUnival = IsUnivalSubtree(node.right, ref count);

        if (isLeftUnival && isRightUnival
            && (node.left is null || node.val == node.left.val)
            && (node.right is null || node.val == node.right.val))
        {
            count++;
            return true;
        }

        return false;
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