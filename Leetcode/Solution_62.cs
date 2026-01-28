// 62. Unique Paths

#region Вариант 1 - Bottom-up - Space complexity O(n*m)
// Runtime 0 ms, Beats 100.00%
// Memory 29.10 MB, Beats 57.35%

public class Solution_62_1
{
    public int UniquePaths(int m, int n)
    {
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
                if (row > 0)
                {
                    cache[row][column] += cache[row - 1][column];
                }

                if (column > 0)
                {
                    cache[row][column] += cache[row][column - 1];
                }
            }
        }

        return cache[m - 1][n - 1];
    }
}
#endregion

#region Вариант 2 - Bottom-up - Space complexity O(n)
// Runtime 1 ms, Beats 33.19%
// Memory 29.36 MB, Beats 32.90%

public class Solution_62_2
{
    public int UniquePaths(int m, int n)
    {
        var cache = new int[n];
        Array.Fill(cache, value: 1);

        for (var row = 1; row < m; row++)
        {
            for (var column = 1; column < n; column++)
            {
                cache[column] += cache[column - 1];
            }
        }

        return cache[n - 1];
    }
}
#endregion
