// 724. Find Pivot Index
public class Solution_724
{
    public int PivotIndex(int[] nums)
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

        for (var pivot = 1; pivot < nums.Length; pivot++)
        {
            leftSum += nums[pivot - 1];
            rightSum -= nums[pivot];

            if (leftSum == rightSum)
            {
                return pivot;
            }
        }

        return -1;
    }
}