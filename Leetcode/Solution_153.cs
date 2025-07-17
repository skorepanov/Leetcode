// 153. Find Minimum in Rotated Sorted Array
public class Solution_153
{
    public int FindMin(int[] nums)
    {
        var arrayLength = nums.Length;
        var left = 0;
        var right = arrayLength - 1;

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