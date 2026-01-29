// 256. Paint House
public class Solution_256
{
    public int MinCost(int[][] costs)
    {
        var houseCount = costs.Length;

        var cache = new int[houseCount][];

        cache[0] = new int[3];
        cache[0][0] = costs[0][0];
        cache[0][1] = costs[0][1];
        cache[0][2] = costs[0][2];

        for (var i = 1; i < houseCount; i++)
        {
            cache[i] =
            [
                Math.Min(cache[i - 1][1], cache[i - 1][2])
                    + costs[i][0],
                Math.Min(cache[i - 1][0], cache[i - 1][2])
                    + costs[i][1],
                Math.Min(cache[i - 1][0], cache[i - 1][1])
                    + costs[i][2]
            ];
        }

        return cache[^1].Min();
    }
}