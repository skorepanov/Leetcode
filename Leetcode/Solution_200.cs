// 200. Number of Islands

#region Solution 1 - BFS, Queue
public class Solution_200_1
{
    private const char NON_VISITED_ISLAND = '1';
    private const char VISITED_ISLAND = '2';

    private int[][] _directions =
    [
        [1, 0],
        [-1, 0],
        [0, 1],
        [0, -1]
    ];

    public int NumIslands(char[][] grid)
    {
        var islandNum = 0;
        var rowLength = grid.Length;
        var columnLength = grid[0].Length;

        for (var row = 0; row < rowLength; row++)
        {
            for (var column = 0; column < columnLength; column++)
            {
                if (grid[row][column] == NON_VISITED_ISLAND)
                {
                    VisitIsland(row, column, grid);
                    islandNum++;
                }
            }
        }

        return islandNum;
    }

    private void VisitIsland(int row, int column, char[][] grid)
    {
        var rowLength = grid.Length;
        var columnLength = grid[0].Length;

        var root = new Position(row, column);
        grid[root.X][root.Y] = VISITED_ISLAND;

        var pendingPositions = new Queue<Position>();
        pendingPositions.Enqueue(root);

        while (pendingPositions.Count > 0)
        {
            var position = pendingPositions.Dequeue();

            foreach (var direction in _directions)
            {
                var nextRow = position.X + direction[0];
                var nextColumn = position.Y + direction[1];

                if (nextRow < 0 || nextRow >= rowLength
                    || nextColumn < 0 || nextColumn >= columnLength
                    || grid[nextRow][nextColumn] != NON_VISITED_ISLAND)
                {
                    continue;
                }

                var nextPosition = new Position(nextRow, nextColumn);
                grid[nextPosition.X][nextPosition.Y] = VISITED_ISLAND;

                pendingPositions.Enqueue(nextPosition);
            }
        }
    }

    private record Position(int X, int Y);
}
#endregion

#region Solution 2 - DFS, Stack
public class Solution_200_2
{
    private const char NON_VISITED_ISLAND = '1';
    private const char VISITED_ISLAND = '2';

    private int[][] _directions =
    [
        [1, 0],
        [-1, 0],
        [0, 1],
        [0, -1]
    ];

    public int NumIslands(char[][] grid)
    {
        var islandNum = 0;
        var rowLength = grid.Length;
        var columnLength = grid[0].Length;

        for (var row = 0; row < rowLength; row++)
        {
            for (var column = 0; column < columnLength; column++)
            {
                if (grid[row][column] == NON_VISITED_ISLAND)
                {
                    VisitIsland(row, column, grid);
                    islandNum++;
                }
            }
        }

        return islandNum;
    }

    private void VisitIsland(int row, int column, char[][] grid)
    {
        var rowLength = grid.Length;
        var columnLength = grid[0].Length;

        var root = new Position(row, column);
        grid[root.X][root.Y] = VISITED_ISLAND;

        var pendingPositions = new Stack<Position>();
        pendingPositions.Push(root);

        while (pendingPositions.Count > 0)
        {
            var position = pendingPositions.Pop();

            foreach (var direction in _directions)
            {
                var nextRow = position.X + direction[0];
                var nextColumn = position.Y + direction[1];

                if (nextRow < 0 || nextRow >= rowLength
                    || nextColumn < 0 || nextColumn >= columnLength
                    || grid[nextRow][nextColumn] != NON_VISITED_ISLAND)
                {
                    continue;
                }

                var nextPosition = new Position(nextRow, nextColumn);
                grid[nextPosition.X][nextPosition.Y] = VISITED_ISLAND;

                pendingPositions.Push(nextPosition);
            }
        }
    }

    private record Position(int X, int Y);
}
#endregion