// 752. Open the Lock
public class Solution_752
{
    public int OpenLock(string[] deadends, string target)
    {
        var root = "0000";
        var visitedAndDeadends = new HashSet<string>(deadends);

        if (visitedAndDeadends.Contains(root))
        {
            return -1;
        }

        if (root == target)
        {
            return 0;
        }

        var counter = 1;
        var pendingPositions = new Queue<string>();

        pendingPositions.Enqueue(root);
        visitedAndDeadends.Add(root);

        while (pendingPositions.Count > 0)
        {
            var size = pendingPositions.Count;

            for (var i = 0; i < size; i++)
            {
                var position = pendingPositions.Dequeue();

                var nextPositions = GetNextPositions(position);

                foreach (var nextPosition in nextPositions)
                {
                    if (nextPosition == target)
                    {
                        return counter;
                    }

                    if (visitedAndDeadends.Contains(nextPosition))
                    {
                        continue;
                    }

                    pendingPositions.Enqueue(nextPosition);
                    visitedAndDeadends.Add(nextPosition);
                }
            }

            counter++;
        }

        return -1;
    }

    private string[] GetNextPositions(string position)
    {
        var nextPositions = new char[][]
        {
            [GetNextUp(position[0]), position[1], position[2], position[3]],
            [GetNextDown(position[0]), position[1], position[2], position[3]],
            [position[0], GetNextUp(position[1]), position[2], position[3]],
            [position[0], GetNextDown(position[1]), position[2], position[3]],
            [position[0], position[1], GetNextUp(position[2]), position[3]],
            [position[0], position[1], GetNextDown(position[2]), position[3]],
            [position[0], position[1], position[2], GetNextUp(position[3])],
            [position[0], position[1], position[2], GetNextDown(position[3])]
        };

        return nextPositions
            .Select(p => new string(p))
            .ToArray();
    }

    private char GetNextUp(char position)
    {
        if (position == '9')
        {
            return '0';
        }

        position++;
        return position;
    }

    private char GetNextDown(char position)
    {
        if (position == '0')
        {
            return '9';
        }

        position--;
        return position;
    }
}