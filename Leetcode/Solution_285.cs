// 285. Inorder Successor in BST
public class Solution_285
{
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
    {
        TreeNode successor = null;
        var node = root;

        while (node is not null)
        {
            if (node.val <= p.val)
            {
                node = node.right;
            }
            else
            {
                successor = node;
                node = node.left;
            }
        }

        return successor;
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