// 918. Maximum Sum Circular Subarray
public class Solution_918
{
    public int MaxSubarraySumCircular(int[] nums)
    {
        var currentMax = 0;
        var currentMin = 0;
        var maxSum = nums[0];
        var minSum = nums[0];
        var totalSum = 0;

        foreach (var num in nums)
        {
            // Normal Kadane's
            currentMax = Math.Max(currentMax + num, num);
            maxSum = Math.Max(maxSum, currentMax);

            // Kadane's but with min to find minimum subarray
            currentMin = Math.Min(currentMin + num, num);
            minSum = Math.Min(minSum, currentMin);

            totalSum += num;
        }

        // если минимальный подмассив содержит все элементы,
        // например, если все элементы отрицательные
        if (totalSum == minSum)
        {
            return maxSum;
        }

        return Math.Max(maxSum, totalSum - minSum);
    }
}