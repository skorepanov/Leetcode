// 1765. Map of Highest Peak
public class Solution_1765
{
    private const int WATER = 0;
    const int NOT_VISITED = -1;

    private readonly int[][] _directions =
    [
        [1, 0],
        [-1, 0],
        [0, 1],
        [0, -1]
    ];

    public int[][] HighestPeak(int[][] isWater)
    {
        var pendingPositions = new Queue<Position>();

        var rowLength = isWater.Length;
        var columnLength = isWater[0].Length;

        int[][] highestPeak = new int[rowLength][];

        for (var row = 0; row < rowLength; row++)
        {
            highestPeak[row] = new int[columnLength];

            for (var column = 0; column < columnLength; column++)
            {
                if (isWater[row][column] == 1)
                {
                    highestPeak[row][column] = WATER;
                    pendingPositions.Enqueue(new Position(row, column));
                }
                else
                {
                    highestPeak[row][column] = NOT_VISITED;
                }
            }
        }

        while (pendingPositions.Count > 0)
        {
            var position = pendingPositions.Dequeue();

            foreach (var direction in _directions)
            {
                var nextRow = position.X + direction[0];
                var nextColumn = position.Y + direction[1];

                if (nextRow < 0 || nextRow >= rowLength
                    || nextColumn < 0 || nextColumn >= columnLength
                    || highestPeak[nextRow][nextColumn] != NOT_VISITED)
                {
                    continue;
                }

                var nextPosition = new Position(nextRow, nextColumn);
                highestPeak[nextRow][nextColumn] = highestPeak[position.X][position.Y] + 1;

                pendingPositions.Enqueue(nextPosition);
            }
        }

        return highestPeak;
    }

    private record Position(int X, int Y);
}