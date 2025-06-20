// 1337. The K Weakest Rows in a Matrix
public class Solution_1337
{
    public int[] KWeakestRows(int[][] mat, int k)
    {
        var comparer = Comparer<(int Count, int Index)>.Create((x, y) =>
            x.Count == y.Count
                ? x.Index - y.Index
                : x.Count - y.Count);

        var matSoldiersCount = new PriorityQueue<int, (int, int)>(comparer);

        for (var i = 0; i < mat.Length; i++)
        {
            var rowSoldiersCount = 0;

            for (var j = 0; j < mat[i].Length; j++)
            {
                if (mat[i][j] == 0)
                {
                    break;
                }

                rowSoldiersCount++;
            }

            matSoldiersCount.Enqueue(i, (rowSoldiersCount, i));
        }

        var kWeakestRows = new int[k];
        var rowIndex = 0;

        while (rowIndex < k && matSoldiersCount.Count > 0)
        {
            kWeakestRows[rowIndex] = matSoldiersCount.Dequeue();
            rowIndex++;
        }

        return kWeakestRows;
    }
}