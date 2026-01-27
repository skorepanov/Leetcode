// 300. Longest Increasing Subsequence
public class Solution_300
{
    public int LengthOfLIS(int[] nums)
    {
        var cache = new int[nums.Length];
        Array.Fill(cache, value: 1);

        for (var i = 1; i < nums.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                {
                    cache[i] = Math.Max(cache[i], cache[j] + 1);
                }
            }
        }

        var longest = cache.Max();

        return longest;
    }
}