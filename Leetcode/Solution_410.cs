// 410. Split Array Largest Sum
public class Solution_410
{
    public int SplitArray(int[] nums, int k)
    {
        var left = nums.Max();
        var right = nums.Sum();
        var minimumLargestSplitSum = 0;

        while (left <= right)
        {
            var maxSumAllowed = left + (right - left) / 2;

            var minimumSplitsRequired = GetMinimumSplitsRequired(nums, maxSumAllowed);

            if (minimumSplitsRequired <= k)
            {
                right = maxSumAllowed - 1;
                minimumLargestSplitSum = maxSumAllowed;
            }
            else
            {
                left = maxSumAllowed + 1;
            }
        }

        return minimumLargestSplitSum;
    }

    private int GetMinimumSplitsRequired(int[] nums, int maxSumAllowed)
    {
        var currentSum = 0;
        var splitsRequired = 0;

        foreach (var num in nums)
        {
            if (currentSum + num <= maxSumAllowed)
            {
                currentSum += num;
            }
            else
            {
                currentSum = num;
                splitsRequired++;
            }
        }

        return splitsRequired + 1;
    }
}