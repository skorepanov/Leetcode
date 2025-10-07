// 235. Lowest Common Ancestor of a Binary Search Tree
public class Solution_235
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if ((p.val <= root.val && root.val <= q.val)
         || (q.val <= root.val && root.val <= p.val))
        {
            return root;
        }

        return p.val < root.val && q.val < root.val
            ? LowestCommonAncestor(root.left, p, q)
            : LowestCommonAncestor(root.right, p, q);
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