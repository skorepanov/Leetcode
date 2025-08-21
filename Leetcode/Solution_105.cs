// 105. Construct Binary Tree from Preorder and Inorder Traversal
public class Solution_105
{
    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        if (preorder.Length == 1)
        {
            return new TreeNode(inorder[0]);
        }

        var root = new TreeNode(preorder[0]);

        var rootIndexInInorder = Array.IndexOf(inorder, root.val);
        var leftValuesInorder = inorder.Take(rootIndexInInorder).ToArray();
        var rightValuesInorder = inorder.Skip(rootIndexInInorder + 1).ToArray();

        var leftValuesPreorder = preorder
            .Skip(1)
            .Take(leftValuesInorder.Length)
            .ToArray();

        var rightValuesPreorder = preorder
            .Skip(1 + leftValuesPreorder.Length)
            .ToArray();

        if (leftValuesInorder.Length > 0)
        {
            root.left = BuildTree(leftValuesPreorder, leftValuesInorder);
        }

        if (rightValuesInorder.Length > 0)
        {
            root.right = BuildTree(rightValuesPreorder, rightValuesInorder);
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