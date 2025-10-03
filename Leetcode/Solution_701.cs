// 701. Insert into a Binary Search Tree
public class Solution_701
{
    public TreeNode InsertIntoBST(TreeNode root, int val)
    {
        if (root is null)
        {
            root = new TreeNode(val);
            return root;
        }

        var node = root;

        while (node is not null)
        {
            if (node.val < val)
            {
                if (node.right is null)
                {
                    node.right = new TreeNode(val);
                    return root;
                }

                node = node.right;
            }
            else
            {
                if (node.left is null)
                {
                    node.left = new TreeNode(val);
                    return root;
                }

                node = node.left;
            }
        }

        return root;
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