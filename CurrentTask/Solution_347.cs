// 347. Top K Frequent Elements
namespace CurrentTask;

public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var frequencies = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (frequencies.ContainsKey(num))
            {
                frequencies[num]++;
            }
            else
            {
                frequencies.Add(num, 1);
            }
        }

        var topKFrequent = frequencies
            .OrderByDescending(f => f.Value)
            .Take(k)
            .Select(f => f.Key)
            .ToArray();

        return topKFrequent;
    }
}