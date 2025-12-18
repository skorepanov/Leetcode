// 198. House Robber
public class Solution_198
{
    private readonly Dictionary<int, int> _cache = new();

    public int Rob(int[] nums)
    {
        return Rob(nums, house: nums.Length - 1);
    }

    private int Rob(int[] nums, int house)
    {
        switch (house)
        {
            case 0:
                return nums[0];
            case 1:
                return Math.Max(nums[0], nums[1]);
        }

        if (_cache.TryGetValue(house, out var value))
        {
            return value;
        }

        var max = Math.Max(
            Rob(nums, house - 1),
            Rob(nums, house - 2) + nums[house]);

        _cache.Add(house, max);

        return max;
    }
}