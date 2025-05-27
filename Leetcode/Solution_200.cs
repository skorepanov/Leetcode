// 200. Number of Islands
public class Solution_200
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

        var queue = new Queue<Position>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var position = queue.Dequeue();

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

                queue.Enqueue(nextPosition);
            }
        }
    }

    private record Position(int X, int Y);
}