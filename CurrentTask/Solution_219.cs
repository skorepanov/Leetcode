// 219. Contains Duplicate II
namespace CurrentTask;

public class Solution_219
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            if (!dict.ContainsKey(num))
            {
                dict.Add(num, i);
                continue;
            }

            if (i - dict[num] <= k)
            {
                return true;
            }

            dict[num] = i;
        }

        return false;
    }
}