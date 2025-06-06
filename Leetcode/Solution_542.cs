// 542. 01 Matrix
public class Solution_542
{
    const int NOT_VISITED = -1;

    private readonly int[][] _directions =
    [
        [1, 0],
        [-1, 0],
        [0, 1],
        [0, -1]
    ];

    public int[][] UpdateMatrix(int[][] mat)
    {
        var pendingPositions = new Queue<Position>();

        var rowLength = mat.Length;
        var columnLength = mat[0].Length;

        for (var row = 0; row < rowLength; row++)
        {
            for (var column = 0; column < columnLength; column++)
            {
                if (mat[row][column] == 1)
                {
                    mat[row][column] = NOT_VISITED;
                }
                else
                {
                    pendingPositions.Enqueue(new Position(row, column));
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
                    || mat[nextRow][nextColumn] != NOT_VISITED)
                {
                    continue;
                }

                var nextPosition = new Position(nextRow, nextColumn);
                mat[nextRow][nextColumn] = mat[position.X][position.Y] + 1;

                pendingPositions.Enqueue(nextPosition);
            }
        }

        return mat;
    }

    private record Position(int X, int Y);
}