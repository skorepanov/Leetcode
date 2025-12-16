// 1631. Path With Minimum Effort
public class Solution_1631
{
    private readonly int[][] _directions =
    [
        [1, 0],
        [-1, 0],
        [0, 1],
        [0, -1]
    ];

    public int MinimumEffortPath(int[][] heights)
    {
        var rowCount = heights.Length;
        var columnCount = heights[0].Length;

        var differenceMatrix = new int[rowCount][];

        for (var i = 0; i < rowCount; i++)
        {
            differenceMatrix[i] = new int[columnCount];
            Array.Fill(differenceMatrix[i], int.MaxValue);
        }

        differenceMatrix[0][0] = 0;

        var queue = new PriorityQueue<Cell, int>();
        queue.Enqueue(new Cell(X: 0, Y: 0, Difference: 0), priority: 0);

        while (queue.Count > 0)
        {
            var currentCell =  queue.Dequeue();

            if (currentCell.X == rowCount - 1 && currentCell.Y == columnCount - 1)
            {
                return currentCell.Difference;
            }

            foreach (var direction in _directions)
            {
                var adjacentX = currentCell.X + direction[0];
                var adjacentY = currentCell.Y + direction[1];

                if (!IsValidCell(adjacentX, adjacentY, rowCount, columnCount))
                {
                    continue;
                }

                var currentDifference = Math.Abs(
                    heights[adjacentX][adjacentY] - heights[currentCell.X][currentCell.Y]);

                var maxDifference = Math.Max(
                    currentDifference,
                    differenceMatrix[currentCell.X][currentCell.Y]);

                if (differenceMatrix[adjacentX][adjacentY] > maxDifference)
                {
                    differenceMatrix[adjacentX][adjacentY] = maxDifference;

                    queue.Enqueue(
                        new Cell(adjacentX, adjacentY, maxDifference),
                        maxDifference);
                }
            }
        }

        return differenceMatrix[^1][^1];
    }

    private bool IsValidCell(int x, int y, int rowCount, int columnCount)
    {
        return x >= 0 && x <= rowCount - 1
            && y >= 0 && y <= columnCount - 1;
    }

    private record Cell(int X, int Y, int Difference);
}