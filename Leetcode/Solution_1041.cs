// 1041. Robot Bounded In Circle
public class Solution_1041
{
    private Position _position;
    private RobotDirection _direction;
    private Dictionary<RobotDirection, int[]> _directions;

    public bool IsRobotBounded(string instructions)
    {
        var startPosition = new Position(X: 0, Y: 0);
        _position = startPosition;
        _direction = RobotDirection.North;

        _directions = new Dictionary<RobotDirection, int[]>
        {
            [RobotDirection.North] = [0, 1],
            [RobotDirection.East] = [1, 0],
            [RobotDirection.South] = [0, -1],
            [RobotDirection.West] = [-1, 0]
        };

        foreach (var instruction in instructions)
        {
            switch (instruction)
            {
                case 'R': TurnRobotRight(); break;
                case 'L': TurnRobotLeft(); break;
                case 'G': MoveRobot(); break;
            }
        }

        return _position == startPosition || _direction != RobotDirection.North;
    }

    private void TurnRobotRight()
    {
        _direction = _direction == RobotDirection.West
            ? RobotDirection.North
            : _direction + 1;
    }

    private void TurnRobotLeft()
    {
        _direction = _direction == RobotDirection.North
            ? RobotDirection.West
            : _direction - 1;
    }

    private void MoveRobot()
    {
        var nextX = _position.X + _directions[_direction][0];
        var nextY = _position.Y + _directions[_direction][1];

        _position = new Position(nextX, nextY);
    }

    private enum RobotDirection
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3
    }

    private record Position(int X, int Y);
}