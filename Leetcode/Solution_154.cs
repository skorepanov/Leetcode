// 154. Find Minimum in Rotated Sorted Array II

#region My solution - Runtime 0 ms, Beats 100.00%
public class Solution_154_1
{
    public int FindMin(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        var arrayLength = nums.Length;
        var left = 0;
        var right = arrayLength - 1;

        while (left < arrayLength && nums[left] == nums[right])
        {
            left++;
        }

        if (left >= arrayLength)
        {
            return nums[0];
        }

        while (left < right)
        {
            var middle = left + (right - left) / 2;

            if (nums[middle] > nums[middle + 1])
            {
                return nums[middle + 1];
            }

            if (nums[middle] > nums[arrayLength - 1])
            {
                left = middle + 1;
            }
            else
            {
                right = middle;
            }
        }

        return nums[left];
    }
}
#endregion

#region Leetcode solution - Runtime 0 ms, Beats 100.00%
public class Solution_154_2
{
    public int FindMin(int[] nums)
    {
        var low = 0;
        var high = nums.Length - 1;

        while (low < high)
        {
            var middle = low + (high - low) / 2;

            if (nums[middle] < nums[high])
            {
                high = middle;
            }
            else if (nums[middle] > nums[high])
            {
                low = middle + 1;
            }
            else
            {
                // nums[middle] == nums[high]
                high--;
            }
        }

        return nums[low];
    }
}
#endregion