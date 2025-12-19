// 740. Delete and Earn
public class Solution_740
{
    private readonly Dictionary<int, int> _cache = new();

    public int DeleteAndEarn(int[] nums)
    {
        var possibleEarns = nums
            .GroupBy(n => n)
            .ToDictionary(k => k.Key, v => v.Count() * v.Key);

        var maxNumber = possibleEarns.Keys.Max();
        var maxEarns = new int[maxNumber + 1];

        maxEarns[1] = possibleEarns.ContainsKey(1)
            ? possibleEarns[1]
            : 0;

        for (var i = 2; i < maxEarns.Length; i++)
        {
            var gain = possibleEarns.ContainsKey(i)
                ? possibleEarns[i]
                : 0;

            var max = Math.Max(
                maxEarns[i - 1],
                maxEarns[i - 2] + gain);

            maxEarns[i] = max;
        }

        return maxEarns[maxNumber];
    }
}