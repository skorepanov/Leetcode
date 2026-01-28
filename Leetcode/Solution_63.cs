// 63. Unique Paths II
public class Solution_63
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        if (obstacleGrid[0][0] == 1)
        {
            return 0;
        }

        var m = obstacleGrid.Length;
        var n = obstacleGrid[0].Length;

        var cache = new int[m][];

        for (var i = 0; i < cache.Length; i++)
        {
            cache[i] = new int[n];
        }

        cache[0][0] = 1;

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                if (row > 0 && obstacleGrid[row][column] == 0)
                {
                    cache[row][column] += cache[row - 1][column];
                }

                if (column > 0 && obstacleGrid[row][column] == 0)
                {
                    cache[row][column] += cache[row][column - 1];
                }
            }
        }

        return cache[m - 1][n - 1];
    }
}