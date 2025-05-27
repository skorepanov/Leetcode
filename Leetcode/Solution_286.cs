// 286. Walls and Gates

#region 1 вариант - считать пути отдельно для каждых ворот - Runtime 135 ms, Beats 5,69%
public class Solution_286_1
{
    public void WallsAndGates(int[][] rooms)
    {
        for (var i = 0; i < rooms.Length; i++)
        {
            for (var j = 0; j < rooms[i].Length; j++)
            {
                if (rooms[i][j] == 0)
                {
                    SetDistancesToGate(i, j, rooms);
                }
            }
        }
    }

    private void SetDistancesToGate(int i, int j, int[][] rooms)
    {
        var distance = 0;
        var root = new Position(i, j);

        var queue = new Queue<Position>();
        queue.Enqueue(root);

        var visited = new HashSet<Position>();
        visited.Add(root);

        while (queue.Count > 0)
        {
            var size = queue.Count;

            for (var k = 0; k < size; k++)
            {
                var position = queue.Dequeue();

                if (rooms[position.X][position.Y] == -1)
                {
                    continue;
                }

                if (position != root)
                {
                    if (rooms[position.X][position.Y] == 0 || visited.Contains(position))
                    {
                        continue;
                    }

                    visited.Add(position);
                }

                if (rooms[position.X][position.Y] > distance)
                {
                    rooms[position.X][position.Y] = distance;
                }

                var top = new Position(position.X - 1, position.Y);
                if (top.X >= 0 && !visited.Contains(top))
                {
                    queue.Enqueue(top);
                }

                var left = new Position(position.X, position.Y - 1);
                if (left.Y >= 0 && !visited.Contains(left))
                {
                    queue.Enqueue(left);
                }

                var bottom = new Position(position.X + 1, position.Y);
                if (bottom.X < rooms.Length && !visited.Contains(bottom))
                {
                    queue.Enqueue(bottom);
                }

                var right = new Position(position.X, position.Y + 1);
                if (right.Y < rooms[position.X].Length && !visited.Contains(right))
                {
                    queue.Enqueue(right);
                }
            }

            distance++;
        }
    }

    private record Position(int X, int Y);
}
#endregion

#region 2 вариант - считать пути для всех ворот параллельно - Runtime 7 ms, Beats 82,11%
public class Solution_286_2
{
    private const int GATE = 0;
    private const int EMPTY = int.MaxValue;

    private int[][] _directions =
    [
        [1, 0],
        [-1, 0],
        [0, 1],
        [0, -1]
    ];

    public void WallsAndGates(int[][] rooms)
    {
        var rowLength = rooms.Length;
        var columnLength = rooms[0].Length;
        var queue = new Queue<Position>();

        for (var row = 0; row < rowLength; row++)
        {
            for (var column = 0; column < columnLength; column++)
            {
                if (rooms[row][column] == GATE)
                {
                    queue.Enqueue(new Position(row, column));
                }
            }
        }

        while (queue.Count > 0)
        {
            var position = queue.Dequeue();

            foreach (var direction in _directions)
            {
                var row = position.X + direction[0];
                var column = position.Y + direction[1];

                if (row < 0 || column < 0 || row >= rowLength || column >= columnLength
                    || rooms[row][column] != EMPTY)
                {
                    continue;
                }

                rooms[row][column] = rooms[position.X][position.Y] + 1;
                queue.Enqueue(new Position(row, column));
            }
        }
    }

    private record Position(int X, int Y);
}
#endregion