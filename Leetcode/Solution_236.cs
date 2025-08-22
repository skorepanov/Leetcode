// 236. Lowest Common Ancestor of a Binary Tree
public class Solution_236
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root.val == p.val || root.val == q.val)
        {
            return root;
        }

        var isPInLeft = false;
        var isQInLeft = false;

        FindValues(root.left, p.val, q.val, ref isPInLeft, ref isQInLeft);

        if (isPInLeft && isQInLeft)
        {
            return LowestCommonAncestor(root.left, p, q);
        }

        if (!isPInLeft && !isQInLeft)
        {
            return LowestCommonAncestor(root.right, p, q);
        }

        return root;
    }

    private void FindValues(TreeNode node, int p, int q, ref bool hasP, ref bool hasQ)
    {
        if (node is null)
        {
            return;
        }

        if (node.val == p)
        {
            hasP = true;
        }
        else if (node.val == q)
        {
            hasQ = true;
        }

        if (hasP && hasQ)
        {
            return;
        }

        FindValues(node.left, p, q, ref hasP, ref hasQ);
        FindValues(node.right, p, q, ref hasP, ref hasQ);
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }
}