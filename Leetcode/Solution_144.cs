public class Solution_144
{
    public IList<int> PreorderTraversal(TreeNode root)
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

        traversal.Add(node.val);

        Traverse(node.left, traversal);
        Traverse(node.right, traversal);
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