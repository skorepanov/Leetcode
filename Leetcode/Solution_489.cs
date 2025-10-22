// 489. Robot Room Cleaner

/**
 * // This is the robot's control interface.
 * // You should not implement it, or speculate about its implementation
 * interface Robot {
 *     // Returns true if the cell in front is open and robot moves into the cell.
 *     // Returns false if the cell in front is blocked and robot stays in the current cell.
 *     public bool Move();
 *
 *     // Robot will stay in the same cell after calling turnLeft/turnRight.
 *     // Each turn will be 90 degrees.
 *     public void TurnLeft();
 *     public void TurnRight();
 *
 *     // Clean the current cell.
 *     public void Clean();
 * }
 */

#region Вариант 1 - Моё решение - Runtime 97 ms, Beats 11.54%
public class Solution_489_1
{
    private Robot _robot;
    private RobotDirection _direction;
    private CellState[,] _room;

    public void CleanRoom(Robot robot)
    {
        _robot = robot;
        _direction = RobotDirection.Up;
        _room = new CellState[205, 404];

        var initialPosition = new Position(X: 100, Y: 200);

        CleanRoom(initialPosition);
    }

    private void CleanRoom(Position position)
    {
        _robot.Clean();
        _room[position.X, position.Y] = CellState.Cleaned;

        var directionNumber = 0;

        while (directionNumber <= 3)
        {
            var nextPosition = GetNextPosition(position, _direction);

            if (_room[nextPosition.X, nextPosition.Y] == CellState.Cleaned
                || !_robot.Move())
            {
                // если дальше уже почищено ИЛИ стена - двигаться не надо
                TurnRobotRight();
                directionNumber++;
                continue;
            }

            var movedDirection = _direction;

            CleanRoom(nextPosition);

            ReturnRobot(movedDirection);
            TurnRobotLeft();

            directionNumber++;
        }
    }

    private Position GetNextPosition(Position position, RobotDirection direction)
    {
        return direction switch
        {
            RobotDirection.Up => position with { Y = position.Y - 1 },
            RobotDirection.Right => position with { X = position.X + 1 },
            RobotDirection.Down => position with { Y = position.Y + 1 },
            RobotDirection.Left => position with { X = position.X - 1 },
            _ => position
        };
    }

    private void ReturnRobot(RobotDirection movedDirection)
    {
        while (movedDirection != _direction)
        {
            TurnRobotRight();
        }

        TurnRobotRight();
        TurnRobotRight();
        _robot.Move();
    }

    private void TurnRobotRight()
    {
        _robot.TurnRight();

        _direction = _direction == RobotDirection.Left
            ? RobotDirection.Up
            : _direction + 1;
    }

    private void TurnRobotLeft()
    {
        _robot.TurnLeft();

        _direction = _direction == RobotDirection.Up
            ? RobotDirection.Left
            : _direction - 1;
    }

    private enum RobotDirection
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }

    private enum CellState
    {
        Uncleaned = 0,
        Cleaned = 1
    }

    private record Position(int X, int Y);

    // класс Robot реализован на стороне Leetcode
    public class Robot
    {
        public bool Move() => false;
        public void TurnLeft() { }
        public void TurnRight() { }
        public void Clean() { }
    }
}
#endregion

#region Вариант 2 - Улучшенное моё решение - Runtime 86 ms, Beats 58.97%
public class Solution_489_2
{
    private Robot _robot;
    private RobotDirection _direction;
    private HashSet<Position> _cleanedPositions;

    public void CleanRoom(Robot robot)
    {
        _robot = robot;
        _direction = RobotDirection.Up;
        _cleanedPositions = new HashSet<Position>();

        var initialPosition = new Position(X: 0, Y: 0);

        CleanRoom(initialPosition);
    }

    private void CleanRoom(Position position)
    {
        _robot.Clean();
        _cleanedPositions.Add(position);

        for (var directionNumber = 0; directionNumber <= 3; directionNumber++)
        {
            var nextPosition = GetNextPosition(position);

            if (_cleanedPositions.Contains(nextPosition) || !_robot.Move())
            {
                TurnRobotRight();
                continue;
            }

            CleanRoom(nextPosition);
            ReturnRobot();
            TurnRobotRight();
        }
    }

    private Position GetNextPosition(Position position)
    {
        return _direction switch
        {
            RobotDirection.Up => position with { Y = position.Y - 1 },
            RobotDirection.Right => position with { X = position.X + 1 },
            RobotDirection.Down => position with { Y = position.Y + 1 },
            RobotDirection.Left => position with { X = position.X - 1 },
            _ => position
        };
    }

    private void ReturnRobot()
    {
        TurnRobotRight();
        TurnRobotRight();
        _robot.Move();
        TurnRobotRight();
        TurnRobotRight();
    }

    private void TurnRobotRight()
    {
        _robot.TurnRight();

        _direction = _direction == RobotDirection.Left
            ? RobotDirection.Up
            : _direction + 1;
    }

    private enum RobotDirection
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3
    }

    private record Position(int X, int Y);

    // класс Robot реализован на стороне Leetcode
    public class Robot
    {
        public bool Move() => false;
        public void TurnLeft() { }
        public void TurnRight() { }
        public void Clean() { }
    }
}
#endregion
