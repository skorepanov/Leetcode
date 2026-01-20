// 73. Set Matrix Zeroes
public class Solution_73
{
    public void SetZeroes(int[][] matrix)
    {
        var rowIndices = new HashSet<int>();
        var columnIndices = new HashSet<int>();

        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 0)
                {
                    rowIndices.Add(i);
                    columnIndices.Add(j);
                }
            }
        }

        foreach (var rowIndex in rowIndices)
        {
            for (var j = 0; j < matrix[rowIndex].Length; j++)
            {
                matrix[rowIndex][j] = 0;
            }
        }

        foreach (var columnIndex in columnIndices)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                matrix[i][columnIndex] = 0;
            }
        }
    }
}