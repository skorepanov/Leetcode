// 265. Paint House II
public class Solution_265
{
    public int MinCostII(int[][] costs)
    {
        var houseCount = costs.Length;
        var colorCount = costs[0].Length;

        var cache = new int[houseCount][];

        for (var i = 0; i < houseCount; i++)
        {
            cache[i] = new int[colorCount];
        }

        for (var j = 0; j < colorCount; j++)
        {
            cache[0][j] = costs[0][j];
        }

        for (var i = 1; i < houseCount; i++)
        {
            for (var currentColor = 0; currentColor < colorCount; currentColor++)
            {
                var minPrevCost = int.MaxValue;

                for (var prevColor = 0; prevColor < colorCount; prevColor++)
                {
                    if (currentColor == prevColor)
                    {
                        continue;
                    }

                    minPrevCost = Math.Min(minPrevCost, cache[i - 1][prevColor]);
                }

                cache[i][currentColor] = minPrevCost + costs[i][currentColor];
            }
        }

        return cache[^1].Min();
    }
}