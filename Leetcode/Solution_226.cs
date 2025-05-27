// 226. Invert Binary Tree
public class Solution_226
{
    public TreeNode InvertTree(TreeNode root)
    {
        if (root is null)
        {
            return root;
        }

        (root.left, root.right) = (root.right, root.left);

        InvertTree(root.left);
        InvertTree(root.right);

        return root;
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}