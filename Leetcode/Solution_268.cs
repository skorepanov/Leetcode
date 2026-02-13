// 268. Missing Number

#region Вариант 1 - Runtime 14 ms, Beats 21.92%
public class Solution_268_1
{
    public int MissingNumber(int[] nums)
    {
        var numsAsHashSet = nums.ToHashSet();

        for (var i = 0; i <= nums.Length; i++)
        {
            if (!numsAsHashSet.Contains(i))
            {
                return i;
            }
        }

        return nums.Length;
    }
}
#endregion

#region Вариант 2 - Runtime 25 ms, Beats 10.13%
public class Solution_268_2
{
    public int MissingNumber(int[] nums)
    {
        var orderedNums = nums.Order().ToArray();

        if (orderedNums[0] != 0)
        {
            return 0;
        }

        for (var i = 1; i < orderedNums.Length; i++)
        {
            if (orderedNums[i] - orderedNums[i - 1] > 1)
            {
                return orderedNums[i] - 1;
            }
        }

        return nums.Length;
    }
}
#endregion

#region Вариант 3 - Runtime 0 ms, Beats 100.00%
public class Solution_268_3
{
    public int MissingNumber(int[] nums)
    {
        var diff = nums.Length;

        for (var i = 0; i < nums.Length; i++)
        {
            diff = diff + i - nums[i];
        }

        return diff;
    }
}
#endregion
