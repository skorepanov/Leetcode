// 896. Monotonic Array
public class Solution_896
{
    public bool IsMonotonic(int[] nums)
    {
        if (nums.Length == 1)
        {
            return true;
        }

        var isIncreasing = (bool?)null;
        var isDecreasing = (bool?)null;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] < nums[i])
            {
                isDecreasing = false;
            }
            else if (nums[i - 1] > nums[i])
            {
                isIncreasing = false;
            }

            if (isIncreasing is not null && isDecreasing is not null)
            {
                return false;
            }
        }

        return true;
    }
}