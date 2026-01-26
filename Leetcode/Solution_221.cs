// 221. Maximal Square
public class Solution_221
{
    public int MaximalSquare(char[][] matrix)
    {
        var rowCount = matrix.Length;
        var columnCount = matrix[0].Length;

        var dp = new int[rowCount + 1][];

        for (var i = 0; i <= rowCount; i++)
        {
            dp[i] = new int[columnCount + 1];
        }

        var maxDpValue = 0;

        for (var i = 1; i <= rowCount; i++)
        {
            for (var j = 1; j <= columnCount; j++)
            {
                if (matrix[i - 1][j - 1] != '1')
                {
                    continue;
                }

                dp[i][j] = new[]
                {
                    dp[i - 1][ j - 1],
                    dp[i][j - 1],
                    dp[i - 1][j]
                }.Min() + 1;

                maxDpValue = Math.Max(maxDpValue, dp[i][j]);
            }
        }

        return maxDpValue * maxDpValue;
    }
}