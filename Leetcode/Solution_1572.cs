// 1572. Matrix Diagonal Sum
public class Solution_1572
{
    public int DiagonalSum(int[][] mat)
    {
        if (mat.Length == 1)
        {
            return mat[0][0];
        }

        var sum = 0;
        var matLength = mat.Length;

        for (var i = 0; i < matLength; i++)
        {
            sum += mat[i][i];
            sum += mat[i][matLength - 1 - i];
        }

        if (matLength % 2 == 1)
        {
            sum -= mat[matLength / 2][matLength / 2];
        }

        return sum;
    }
}