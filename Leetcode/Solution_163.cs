// 163. Missing Ranges
public class Solution_163
{
    public IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
    {
        if (nums.Length == 0)
        {
            return [[lower, upper]];
        }

        if (upper < nums[0] || nums[^1] < lower)
        {
            return [];
        }

        var missingRanges = new List<IList<int>>();

        if (lower < nums[0])
        {
            missingRanges.Add([lower, nums[0] - 1]);
        }

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] - nums[i - 1] == 1)
            {
                continue;
            }

            missingRanges.Add([
                nums[i - 1] + 1,
                nums[i] - 1]);
        }

        if (nums[^1] < upper)
        {
            missingRanges.Add([nums[^1] + 1, upper]);
        }

        return missingRanges;
    }
}