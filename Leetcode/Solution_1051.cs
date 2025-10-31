// 1051. Height Checker
public class Solution_1051
{
    public int HeightChecker(int[] heights)
    {
        var sortedHeights = heights.OrderBy(h => h).ToArray();
        var indexCount = 0;

        for (var i = 0; i < heights.Length; i++)
        {
            if (heights[i] != sortedHeights[i])
            {
                indexCount++;
            }
        }

        return indexCount;
    }
}