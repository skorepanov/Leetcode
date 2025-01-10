// 1200. Minimum Absolute Difference
namespace CurrentTask;

public class Solution_1200
{
    public IList<IList<int>> MinimumAbsDifference(int[] arr)
    {
        var sortedArray = arr.OrderBy(x => x).ToArray();
        var minDiff = int.MaxValue;

        for (var i = 1; i < sortedArray.Length; i++)
        {
            var diff = Math.Abs(sortedArray[i - 1] - sortedArray[i]);
            minDiff = Math.Min(minDiff, diff);

            if (minDiff == 1)
            {
                break;
            }
        }

        var pairs = new List<IList<int>>();

        for (var i = 1; i < sortedArray.Length; i++)
        {
            var previous = sortedArray[i - 1];
            var current = sortedArray[i];
            var diff = Math.Abs(previous - current);

            if (diff == minDiff)
            {
                pairs.Add(new List<int> { previous, current });
            }
        }

        return pairs;
    }
}