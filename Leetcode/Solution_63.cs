// 63. Unique Paths II
public class Solution_63
{
    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        if (obstacleGrid[0][0] == 1)
        {
            return 0;
        }

        var rowCount = obstacleGrid.Length;
        var columnCount = obstacleGrid[0].Length;

        var cache = new int[rowCount][];

        for (var row = 0; row < cache.Length; row++)
        {
            cache[row] = new int[columnCount];
        }

        cache[0][0] = 1;

        for (var row = 0; row < rowCount; row++)
        {
            for (var column = 0; column < columnCount; column++)
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

        return cache[rowCount - 1][columnCount - 1];
    }
}