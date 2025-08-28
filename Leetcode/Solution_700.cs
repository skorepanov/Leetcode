// 700. Search in a Binary Search Tree
public class Solution_700
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