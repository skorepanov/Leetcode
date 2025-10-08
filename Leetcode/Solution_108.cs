// 108. Convert Sorted Array to Binary Search Tree
public class Solution_108
{
    public TreeNode SortedArrayToBST(int[] nums)
    {
        return SortedArrayToBST(nums, left: 0, right: nums.Length - 1);
    }

    private TreeNode SortedArrayToBST(int[] nums, int left, int right)
    {
        if (left > right)
        {
            return null;
        }

        var middle = (left + right) / 2;

        var tree = new TreeNode(nums[middle]);
        tree.left = SortedArrayToBST(nums, left, middle - 1);
        tree.right = SortedArrayToBST(nums, middle + 1, right);

        return tree;
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