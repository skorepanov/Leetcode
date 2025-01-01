// 561. Array Partition
namespace CurrentTask;

public class Solution_561
{
    public int ArrayPairSum(int[] nums)
    {
        Array.Sort(nums);

        var sum = 0;

        for (var i = 0; i < nums.Length; i += 2)
        {
            sum += nums[i];
        }

        return sum;
    }
}