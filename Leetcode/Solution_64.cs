// 64. Minimum Path Sum
public class Solution_64
{
    public int MinPathSum(int[][] grid)
    {
        var rowCount = grid.Length;
        var columnCount = grid[0].Length;

        var cache = new int[rowCount][];

        for (var row = 0; row < cache.Length; row++)
        {
            cache[row] = new int[columnCount];
        }

        cache[0][0] = grid[0][0];

        for (var row = 1; row < rowCount; row++)
        {
            cache[row][0] = cache[row - 1][0] + grid[row][0];
        }

        for (var column = 1; column < columnCount; column++)
        {
            cache[0][column] = cache[0][column - 1] + grid[0][column];
        }

        for (var row = 1; row < rowCount; row++)
        {
            for (var column = 1; column < columnCount; column++)
            {
                cache[row][column] = grid[row][column]
                    + Math.Min(cache[row - 1][column], cache[row][column - 1]);
            }
        }

        return cache[rowCount - 1][columnCount - 1];
    }
}