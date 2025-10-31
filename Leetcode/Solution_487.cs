// 487. Max Consecutive Ones II
public class Solution_487
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        if (nums.Length == 1)
        {
            return 1;
        }

        var maxLength = 0;
        var chain1Length = 0;
        var chain2Length = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                chain2Length++;
            }

            var totalChainLength = chain1Length + chain2Length + 1;
            maxLength = Math.Max(maxLength, totalChainLength);

            if (nums[i] == 0)
            {
                chain1Length = chain2Length;
                chain2Length = 0;
            }
        }

        if (maxLength == 0)
        {
            maxLength++;
        }

        if (maxLength > nums.Length)
        {
            maxLength--;
        }

        return maxLength;
    }
}