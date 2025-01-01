// 498. Diagonal Traverse
namespace CurrentTask;

public class Solution_498
{
    public int[] FindDiagonalOrder(int[][] mat)
    {
        var result = new int[mat.Length * mat[0].Length];

        var matIndex = 0;
        var shift = 0;
        var isForward = true;

        while (shift < mat.Length + mat[0].Length - 1)
        {
            if (isForward)
            {
                var i = shift < mat.Length
                    ? shift
                    : mat.Length - 1;

                var k = shift < mat.Length
                    ? 0
                    : shift - mat.Length + 1;

                while (i >= 0 && k < mat[0].Length)
                {
                    result[matIndex] = mat[i][k];
                    matIndex++;

                    i--;
                    k++;
                }
            }
            else
            {
                var i = shift < mat[0].Length
                    ? 0
                    : shift - mat[0].Length + 1;

                var k = shift < mat[0].Length
                    ? shift
                    : mat[0].Length - 1;

                while (i < mat.Length && k >= 0)
                {
                    result[matIndex] = mat[i][k];
                    matIndex++;

                    i++;
                    k--;
                }
            }

            shift++;
            isForward = !isForward;
        }

        return result;
    }
}