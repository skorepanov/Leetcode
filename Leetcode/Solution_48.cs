// 48. Rotate Image
public class Solution_48
{
    public void Rotate(int[][] matrix)
    {
        var left = 0;
        var right = matrix[0].Length - 1;
        var top = 0;
        var bottom = matrix.Length - 1;

        while (top < bottom)
        {
            var offset = 0;

            while (left + offset < right)
            {
                var value = matrix[top][left + offset];
                matrix[top][left + offset] = matrix[bottom - offset][left];
                matrix[bottom - offset][left] = matrix[bottom][right - offset];
                matrix[bottom][right - offset] = matrix[top + offset][right];
                matrix[top + offset][right] = value;

                offset++;
            }

            top++;
            bottom--;
            left++;
            right--;
        }
    }
}