// 931. Minimum Falling Path Sum
public class Solution_931
{
    public int MinFallingPathSum(int[][] matrix)
    {
        if (matrix.Length == 1)
        {
            return matrix[0].Min();
        }

        var length = matrix.Length;

        var cache = new int[length][];

        for (var i = 0; i < length; i++)
        {
            cache[i] = new int[length];
            cache[0][i] = matrix[0][i];
        }

        var minimumSum = int.MaxValue;

        for (var row = 1; row < length; row++)
        {
            for (var column = 0; column < length; column++)
            {
                var option1 = column > 0
                    ? cache[row - 1][column - 1]
                    : int.MaxValue;

                var option2 = cache[row - 1][column];

                var option3 = column < length - 1
                    ? cache[row - 1][column + 1]
                    : int.MaxValue;

                cache[row][column] = new [] { option1, option2, option3 }.Min()
                                     + matrix[row][column];

                if (row == length - 1)
                {
                    minimumSum = Math.Min(minimumSum, cache[row][column]);
                }
            }
        }

        return minimumSum;
    }
}