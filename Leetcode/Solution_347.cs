// 347. Top K Frequent Elements

#region Solution 1 - С помощью Dictionary - Runtime 11 ms, Beats 34.99%
public class Solution_347_1
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
#endregion

#region Solution 2 - С помощью Dictionary и Heap - Runtime 7 ms, Beats 75.52%
public class Solution_347_2
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

        var comparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
        var heap = new PriorityQueue<int, int>(comparer);

        foreach (var frequency in frequencies)
        {
            heap.Enqueue(frequency.Key, frequency.Value);
        }

        var topKFrequent = new int[k];

        for (var i = 0; i < k; i++)
        {
            topKFrequent[i] = heap.Dequeue();
        }

        return topKFrequent;
    }
}
#endregion
