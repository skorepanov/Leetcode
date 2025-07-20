// 270. Closest Binary Search Tree Value
public class Solution_270
{
    public int ClosestValue(TreeNode root, double target)
    {
        var closest = root.val;
        var node = root;

        while (node != null)
        {
            var closestDiff = Math.Abs(target - closest);
            var currDiff = Math.Abs(target - node.val);

            if (currDiff == closestDiff)
            {
                closest = Math.Min(closest, node.val);
            }
            else if (currDiff < closestDiff)
            {
                closest = node.val;
            }

            node = node.val > target
                ? node.left
                : node.right;
        }

        return closest;
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