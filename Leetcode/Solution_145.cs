// 145. Binary Tree Postorder Traversal
public class Solution_145
{
    public IList<int> PostorderTraversal(TreeNode root)
    {
        var traversal = new List<int>();

        Traverse(root, traversal);

        return traversal;
    }

    private void Traverse(TreeNode node, List<int> traversal)
    {
        if (node is null)
        {
            return;
        }

        Traverse(node.left, traversal);
        Traverse(node.right, traversal);
        traversal.Add(node.val);
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