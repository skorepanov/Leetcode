// 2343. Query Kth Smallest Trimmed Number
namespace CurrentTask;

public class Solution_2343
{
    public int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
    {
        var numLength = nums[0].Length;
        var kstMinIndices = new List<int>();

        foreach (var query in queries)
        {
            var charsToTrim = query[1];
            var startIndex = numLength - charsToTrim;

            var trimmedNumsWithIndices = new (string Num, int Index)[nums.Length];

            for (var i = 0; i < nums.Length; i++)
            {
                var trimmedNum = nums[i][startIndex..];
                trimmedNumsWithIndices[i] = (trimmedNum, i);
            }

            var sortedNumsWithIndices = trimmedNumsWithIndices
                .OrderBy(n => n.Num)
                .ToArray();

            var k = query[0];
            var kstMinIndex = sortedNumsWithIndices[k - 1].Index;

            kstMinIndices.Add(kstMinIndex);
        }

        return kstMinIndices.ToArray();
    }
}