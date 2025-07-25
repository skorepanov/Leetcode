// 719. Find K-th Smallest Pair Distance
public class Solution_719
{
    public int SmallestDistancePair(int[] nums, int k)
    {
        var sortedNums = nums.Order().ToArray();

        var low = 0;
        var high = sortedNums[^1] - sortedNums[0];

        while (low < high)
        {
            var middle = low + (high - low) / 2;

            var count = CountPairsWithMaxDistance(sortedNums, middle);

            if (count < k)
            {
                low = middle + 1;
            }
            else
            {
                high = middle;
            }
        }

        return low;
    }

    private int CountPairsWithMaxDistance(int[] nums, int maxDistance)
    {
        var count = 0;
        var left = 0;

        for (var right = 0; right < nums.Length; right++)
        {
            while (nums[right] - nums[left] > maxDistance)
            {
                left++;
            }

            count += right - left;
        }

        return count;
    }
}