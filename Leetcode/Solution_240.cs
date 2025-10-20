// 240. Search a 2D Matrix II
public class Solution_240
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        return SearchMatrix(
            matrix, target,
            left: 0, right: matrix[0].Length - 1,
            up: 0, down: matrix.Length - 1);
    }

    private bool SearchMatrix(int[][] matrix, int target,
        int left, int right, int up, int down)
    {
        if (left > right || up > down)
        {
            return false;
        }

        if (target < matrix[up][left] || target > matrix[down][right])
        {
            return false;
        }

        var middleColumn = left + (right - left) / 2;

        // найти такой индекс строки, что m[row-1][mid] < target < m[row][mid];
        // это позволит делать дальнейший поиск в двух подматрицах, а не в трёх
        var row = up;

        while (row <= down
            && matrix[row][middleColumn] <= target)
        {
            if (matrix[row][middleColumn] == target)
            {
                return true;
            }

            row++;
        }

        // искать в левом нижнем и правом верхнем углах
        return SearchMatrix(matrix, target,
               left: left, right: middleColumn - 1, up: row, down: down)
           || SearchMatrix(matrix, target,
               left: middleColumn + 1, right: right, up: up, down: row - 1);
    }
}