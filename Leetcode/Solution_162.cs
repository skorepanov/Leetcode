// 162. Find Peak Element
public class Solution_162
{
    public int FindPeakElement(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left < right)
        {
            var middle = left + (right - left) / 2;

            if (middle == 0)
            {
                return nums[0] > nums[1] ? 0 : 1;
            }

            if (nums[middle - 1] < nums[middle] && nums[middle] > nums[middle + 1])
            {
                return middle;
            }

            if (nums[middle - 1] > nums[middle])
            {
                right = middle;
            }
            else
            {
                left = middle + 1;
            }
        }

        return left;
    }
}
