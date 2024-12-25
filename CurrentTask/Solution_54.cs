namespace CurrentTask;

public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        if (matrix is null || matrix.Length == 0)
        {
            return null;
        }

        var result = new List<int>();
        var totalCount = matrix.Length * matrix[0].Length;

        var i = 0;
        var k = 0;

        var left = -1;
        var right = matrix[0].Length;
        var top = -1;
        var bottom = matrix.Length;

        var resultIndex = 0;

        var direction = Direction.Right;

        while (resultIndex < totalCount)
        {
            result.Add(matrix[i][k]);
            resultIndex++;

            switch (direction)
            {
                case Direction.Right:
                    if (k + 1 >= right)
                    {
                        direction = Direction.Bottom;
                        top++;
                        i++;
                    }
                    else
                    {
                        k++;
                    }
                    break;
                case Direction.Bottom:
                    if (i + 1 >= bottom)
                    {
                        direction = Direction.Left;
                        right--;
                        k--;
                    }
                    else
                    {
                        i++;
                    }
                    break;
                case Direction.Left:
                    if (k - 1 <= left)
                    {
                        direction = Direction.Up;
                        bottom--;
                        i--;
                    }
                    else
                    {
                        k--;
                    }
                    break;
                case Direction.Up:
                    if (i - 1 <= top)
                    {
                        direction = Direction.Right;
                        left++;
                        k++;

                    }
                    else
                    {
                        i--;
                    }
                    break;
            }
        }

        return result;
    }

    private enum Direction
    {
        Left = 0,
        Right = 1,
        Up = 2,
        Bottom = 3
    }
}