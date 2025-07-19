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

            if (nums[middle] > nums[middle + 1])
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
