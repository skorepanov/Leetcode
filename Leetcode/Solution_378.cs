// 378. Kth Smallest Element in a Sorted Matrix

#region Solution 1 - Runtime 49 ms, Beats 9.73%
public class Solution_378_1
{
    public int KthSmallest(int[][] matrix, int k)
    {
        var comparer = Comparer<(int RowIndex, int ColumnIndex)>.Create((x, y)
            => matrix[y.RowIndex][y.ColumnIndex] == matrix[x.RowIndex][x.ColumnIndex]
                ? (y.RowIndex + y.ColumnIndex) - (x.RowIndex + x.ColumnIndex)
                : matrix[y.RowIndex][y.ColumnIndex] - matrix[x.RowIndex][x.ColumnIndex]);

        var orderedNums = new PriorityQueue<int, (int, int)>(comparer);

        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                orderedNums.Enqueue(matrix[i][j], (i, j));

                if (orderedNums.Count > k)
                {
                    orderedNums.Dequeue();
                }
            }
        }

        return orderedNums.Dequeue();
    }
}
#endregion

#region Solution 2 - Runtime 34 ms, Beats 36.97%
public class Solution_378_2
{
    public int KthSmallest(int[][] matrix, int k)
    {
        var comparer = Comparer<(int RowIndex, int ColumnIndex)>.Create((x, y)
            => matrix[y.RowIndex][y.ColumnIndex] == matrix[x.RowIndex][x.ColumnIndex]
                ? (y.RowIndex + y.ColumnIndex) - (x.RowIndex + x.ColumnIndex)
                : matrix[y.RowIndex][y.ColumnIndex] - matrix[x.RowIndex][x.ColumnIndex]);

        var orderedNums = new PriorityQueue<int, (int, int)>(comparer);

        for (var i = 0; i < matrix.Length; i++)
        {
            for (var j = 0; j < matrix[i].Length; j++)
            {
                if (orderedNums.Count == k && orderedNums.Peek() < matrix[i][j])
                {
                    continue;
                }

                orderedNums.Enqueue(matrix[i][j], (i, j));

                if (orderedNums.Count > k)
                {
                    orderedNums.Dequeue();
                }
            }
        }

        return orderedNums.Dequeue();
    }
}
#endregion
