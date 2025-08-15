// 104. Maximum Depth of Binary Tree
public class Solution_104
{
    public int MaxDepth(TreeNode root)
    {
        if (root is null)
        {
            return 0;
        }

        var leftDepth = MaxDepth(root.left);
        var rightDepth = MaxDepth(root.right);
        var maxDepth = Math.Max(leftDepth, rightDepth);

        return maxDepth + 1;
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