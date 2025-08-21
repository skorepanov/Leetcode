// 106. Construct Binary Tree from Inorder and Postorder Traversal
public class Solution_106
{
    public TreeNode BuildTree(int[] inorder, int[] postorder)
    {
        if (inorder.Length == 1)
        {
            return new TreeNode(inorder[0]);
        }

        var root = new TreeNode(postorder[^1]);

        var rootIndexInInorder = Array.IndexOf(inorder, root.val);
        var leftValuesInorder = inorder.Take(rootIndexInInorder).ToArray();
        var rightValuesInorder = inorder.Skip(rootIndexInInorder + 1).ToArray();

        if (leftValuesInorder.Length > 0)
        {
            var leftValuesPostorder = postorder.Take(leftValuesInorder.Length).ToArray();
            root.left = BuildTree(leftValuesInorder, leftValuesPostorder);
        }

        if (rightValuesInorder.Length > 0)
        {
            var rightValuesPostorder = postorder
                .Skip(leftValuesInorder.Length)
                .Take(postorder.Length - leftValuesInorder.Length - 1)
                .ToArray();
            root.right = BuildTree(rightValuesInorder, rightValuesPostorder);
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