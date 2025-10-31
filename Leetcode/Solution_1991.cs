// 1991. Find the Middle Index in Array
public class Solution_1991
{
    public int FindMiddleIndex(int[] nums)
    {
        var rightSum = 0;

        for (var i = 1; i < nums.Length; i++)
        {
            rightSum += nums[i];
        }

        if (rightSum == 0)
        {
            return 0;
        }

        var leftSum = 0;

        for (var middleIndex = 1; middleIndex < nums.Length; middleIndex++)
        {
            leftSum += nums[middleIndex - 1];
            rightSum -= nums[middleIndex];

            if (leftSum == rightSum)
            {
                return middleIndex;
            }
        }

        return -1;
    }
}