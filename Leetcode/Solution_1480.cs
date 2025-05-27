// 1480. Running Sum of 1d Array
public class Solution_1480
{
    public int[] RunningSum(int[] nums)
    {
        var result = new int[nums.Length];
        var sum = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            result[i] = sum;
        }

        return result;
    }
}