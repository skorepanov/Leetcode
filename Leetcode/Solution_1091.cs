// 1091. Shortest Path in Binary Matrix
public class Solution_1091
{
    private const int CLEAR = 0;
    private readonly int[][] _directions = [
        [-1, -1],
        [-1, 0],
        [-1, 1],
        [0, -1],
        [0, 1],
        [1, -1],
        [1, 0],
        [1, 1]
    ];

    public int ShortestPathBinaryMatrix(int[][] grid)
    {
        if (grid.Length == 1 && grid[0].Length == 1)
        {
            return grid[0][0] == CLEAR ? 1 : -1;
        }

        var gridLength = grid.Length;

        if (grid[0][0] != CLEAR || grid[gridLength - 1][gridLength - 1] != CLEAR)
        {
            return -1;
        }

        var pathLength = 0;
        var currentPosition = new Position(Row: 0, Column: 0);

        var pendingPositions = new Queue<Position>();
        pendingPositions.Enqueue(currentPosition);

        var visitedPositions = new HashSet<Position>();
        visitedPositions.Add(currentPosition);

        while (pendingPositions.Count > 0)
        {
            var positionCount = pendingPositions.Count;
            pathLength++;

            for (var i = 0; i < positionCount; i++)
            {
                currentPosition = pendingPositions.Dequeue();

                foreach (var direction in _directions)
                {
                    var nextPositionRow = currentPosition.Row + direction[0];
                    var nextPositionColumn = currentPosition.Column + direction[1];

                    if (nextPositionRow == gridLength - 1
                        && nextPositionColumn == gridLength - 1)
                    {
                        return pathLength + 1;
                    }

                    if (nextPositionRow < 0
                        || nextPositionColumn < 0
                        || nextPositionRow >= gridLength
                        || nextPositionColumn >= gridLength
                        || grid[nextPositionRow][nextPositionColumn] != CLEAR)
                    {
                        continue;
                    }

                    var nextPosition = new Position(nextPositionRow, nextPositionColumn);

                    if (visitedPositions.Contains(nextPosition))
                    {
                        continue;
                    }

                    visitedPositions.Add(nextPosition);
                    pendingPositions.Enqueue(nextPosition);
                }
            }
        }

        return currentPosition.Row == gridLength - 1
               && currentPosition.Column == gridLength - 1
            ? pathLength
            : -1;
    }

    private record Position(int Row, int Column);
}