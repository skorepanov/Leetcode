// 414. Third Maximum Number
public class Solution_414
{
    public int ThirdMax(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        if (nums.Length == 2)
        {
            return Math.Max(nums[0], nums[1]);
        }

        var firstMax = nums[0];
        int? secondMax = null;
        int? thirdMax = null;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > firstMax)
            {
                thirdMax = secondMax;
                secondMax = firstMax;
                firstMax = nums[i];
            }
            else if (nums[i] < firstMax && (secondMax is null || secondMax < nums[i]))
            {
                thirdMax = secondMax;
                secondMax = nums[i];
            }
            else if (nums[i] < secondMax && (thirdMax is null || thirdMax < nums[i]))
            {
                thirdMax = nums[i];
            }
        }

        return thirdMax ?? firstMax;
    }
}