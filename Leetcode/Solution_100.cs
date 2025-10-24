public class Solution_100
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        if (p is null && q is null)
        {
            return true;
        }

        if (p?.val != q?.val)
        {
            return false;
        }

        return IsSameTree(p.left, q.left)
            && IsSameTree(p.right, q.right);
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