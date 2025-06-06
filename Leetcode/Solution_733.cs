// 733. Flood Fill
public class Solution_733
{
    private int[][] _directions =
    [
        [1, 0],
        [-1, 0],
        [0, 1],
        [0, -1]
    ];

    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        var colorToChange = image[sr][sc];

        if (colorToChange == color)
        {
            return image;
        }

        var rowLength = image.Length;
        var columnLength = image[0].Length;

        var root = new Position(sr, sc);
        image[root.X][root.Y] = color;

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
                    || image[nextRow][nextColumn] != colorToChange)
                {
                    continue;
                }

                var nextPosition = new Position(nextRow, nextColumn);
                image[nextPosition.X][nextPosition.Y] = color;

                pendingPositions.Enqueue(nextPosition);
            }
        }

        return image;
    }

    private record Position(int X, int Y);
}