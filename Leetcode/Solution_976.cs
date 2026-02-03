// 976. Largest Perimeter Triangle
public class Solution_976
{
    public int LargestPerimeter(int[] nums)
    {
        var orderedNums = nums.OrderByDescending(n => n).ToArray();

        for (var i = 0; i < orderedNums.Length - 2; i++)
        {
            if (orderedNums[i] < orderedNums[i + 1] + orderedNums[i + 2])
            {
                return orderedNums[i] + orderedNums[i + 1] + orderedNums[i + 2];
            }
        }

        return 0;
    }
}