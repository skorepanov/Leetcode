// 53. Maximum Subarray
public class Solution_53
{
    public int MaxSubArray(int[] nums)
    {
        var current = 0;
        var max = int.MinValue;

        foreach (var num in nums)
        {
            current = Math.Max(current + num, num);
            max = Math.Max(max, current);
        }

        return max;
    }
}