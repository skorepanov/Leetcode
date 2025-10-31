// 485. Max Consecutive Ones
public class Solution_485
{
    public int FindMaxConsecutiveOnes(int[] nums)
    {
        var max = 0;
        var current = 0;

        foreach (var num in nums)
        {
            if (num == 1)
            {
                current++;

                if (current > max)
                {
                    max = current;
                }
            }
            else
            {
                current = 0;
            }
        }

        return max;
    }
}