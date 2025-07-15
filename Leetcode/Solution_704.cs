// 704. Binary Search

#region Solution 1 - Recursively - Runtime 0 ms, Beats 100%
public class Solution_704_1
{
    public int Search(int[] nums, int target)
    {
        return Search(nums, target, 0, nums.Length - 1);
    }

    private int Search(int[] nums, int target, int from, int to)
    {
        if (from >= to)
        {
            return nums[from] == target ? from : -1;
        }

        var middleIndex = from + (to - from) / 2;

        if (nums[middleIndex] == target)
        {
            return middleIndex;
        }

        return nums[middleIndex] > target
            ? Search(nums, target, from, middleIndex - 1)
            : Search(nums, target, middleIndex + 1, to);
    }
}
#endregion

#region Solution 2 - Iteratively - Runtime 0 ms, Beats 100%
public class Solution_704_2
{
    public int Search(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var middleIndex = left + (right - left) / 2;

            if (nums[middleIndex] == target)
            {
                return middleIndex;
            }

            if (nums[middleIndex] > target)
            {
                right = middleIndex - 1;
            }
            else
            {
                left = middleIndex + 1;
            }
        }

        return -1;
    }
}
#endregion