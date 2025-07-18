// 34. Find First and Last Position of Element in Sorted Array
public class Solution_34
{
    public int[] SearchRange(int[] nums, int target)
    {
        if (nums.Length == 0)
        {
            return [-1, -1];
        }

        var rangeStart = GetRangeStart(nums, target);

        if (rangeStart < 0)
        {
            return [-1, -1];
        }

        var rangeEnd = GetRangeEnd(nums, target);

        return [rangeStart, rangeEnd];
    }

    private int GetRangeStart(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var middle = left + (right - left) / 2;

            if (nums[middle] > target)
            {
                right = middle - 1;
            }
            else if (nums[middle] < target)
            {
                left = middle + 1;
            }
            else
            {
                if (middle == left || nums[middle - 1] != target)
                {
                    return middle;
                }

                right = middle - 1;
            }
        }

        return -1;
    }

    private int GetRangeEnd(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left <= right)
        {
            var middle = left + (right - left) / 2;

            if (nums[middle] > target)
            {
                right = middle - 1;
            }
            else if (nums[middle] < target)
            {
                left = middle + 1;
            }
            else
            {
                if (middle == right || nums[middle + 1] != target)
                {
                    return middle;
                }

                left = middle + 1;
            }
        }

        return -1;
    }
}