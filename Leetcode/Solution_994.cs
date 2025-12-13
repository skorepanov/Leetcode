// 994. Rotting Oranges
public class Solution_994
{
    private const int FRESH = 1;
    private const int ROTTEN = 2;

    private readonly int[][] _directions = [
        [-1, 0],
        [1, 0],
        [0, -1],
        [0, 1]
    ];

    public int OrangesRotting(int[][] grid)
    {
        var (rottenPositions, freshCount) = GetRottenAndFreshOranges(grid);

        if (freshCount == 0)
        {
            return 0;
        }

        if (rottenPositions.Count == 0)
        {
            return -1;
        }

        var minutes = RotOranges(grid, rottenPositions, ref freshCount);

        return freshCount == 0
            ? minutes
            : -1;
    }

    private (List<Position> rotten, int freshCount) GetRottenAndFreshOranges(int[][] grid)
    {
        var rottenPositions = new List<Position>();
        var freshCount = 0;

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == ROTTEN)
                {
                    rottenPositions.Add(new Position(Row: i, Column: j));
                }
                else if (grid[i][j] == FRESH)
                {
                    freshCount++;
                }
            }
        }

        return (rottenPositions, freshCount);
    }

    private int RotOranges(
        int[][] grid, List<Position> rottenPositions, ref int freshCount)
    {
        var minutes = -1;
        var pendingPositions = new Queue<Position>();

        foreach (var position in rottenPositions)
        {
            pendingPositions.Enqueue(position);
        }

        while (pendingPositions.Count > 0)
        {
            var positionCount = pendingPositions.Count;
            minutes++;

            for (var i = 0; i < positionCount; i++)
            {
                var currentPosition = pendingPositions.Dequeue();

                foreach (var direction in _directions)
                {
                    var nextPositionRow = currentPosition.Row + direction[0];
                    var nextPositionColumn = currentPosition.Column + direction[1];

                    if (nextPositionRow < 0
                        || nextPositionColumn < 0
                        || nextPositionRow >= grid.Length
                        || nextPositionColumn >= grid[0].Length
                        || grid[nextPositionRow][nextPositionColumn] != FRESH)
                    {
                        continue;
                    }

                    grid[nextPositionRow][nextPositionColumn] = ROTTEN;
                    freshCount--;

                    var nextPosition = new Position(nextPositionRow, nextPositionColumn);
                    pendingPositions.Enqueue(nextPosition);
                }
            }
        }

        return minutes;
    }

    private record Position(int Row, int Column);
}