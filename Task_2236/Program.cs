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

public class Solution
{
    public bool CheckTree(TreeNode root)
    {
        var sum = root.left.val + root.right.val;
        return root.val == sum;
    }
}