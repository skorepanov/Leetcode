// 1349. Maximum Students Taking Exam

#region 2 ваирант - С помощью битовых операций - Runtime 4 ms, Beats 88.89%
public class Solution_1349_2
{
    public int MaxStudents(char[][] seats)
    {
        var rowCount = seats.Length;
        var columnCount = seats[0].Length;

        var validRows = new int[rowCount];

        for (var i = 0; i < rowCount; i++)
        {
            for (var j = 0; j < columnCount; j++)
            {
                validRows[i] = (validRows[i] << 1) + (seats[i][j] == '.' ? 1 : 0);
            }
        }

        // There are 2^n states for n columns in binary format
        var stateSize = 1 << columnCount;

        var dp = new int[rowCount][];

        for (var i = 0; i < rowCount; i++)
        {
            dp[i] = new int[stateSize];
            Array.Fill(dp[i], -1);
        }

        var maxStudentCount = 0;

        for (var i = 0; i < rowCount; i++)
        {
            for (var j = 0; j < stateSize; j++)
            {
                // (j & valid) == j: check if j is a subset of valid
                // !(j & (j >> 1)): check if there is no adjacent students in the row
                if (((j & validRows[i]) == j) && ((j & (j >> 1)) == 0))
                {
                    if (i == 0)
                    {
                        dp[i][j] = BitCount(j);
                    }
                    else
                    {
                        for (var k = 0; k < stateSize; k++)
                        {
                            // !(j & (k >> 1)): no students in the upper left positions
                            // !((j >> 1) & k): no students in the upper right positions
                            // dp[i-1][k] != -1: the previous state is valid
                            if ((j & (k >> 1)) == 0
                             && ((j >> 1) & k) == 0
                             && dp[i-1][k] != -1)
                            {
                                dp[i][j] = Math.Max(dp[i][j], dp[i - 1][k] + BitCount(j));
                            }
                        }
                    }

                    maxStudentCount = Math.Max(maxStudentCount, dp[i][j]);
                }
            }
        }

        return maxStudentCount;
    }

    private int BitCount(int n)
    {
        var count = 0;

        while (n != 0)
        {
            // clear the least significant bit set
            n = n & (n - 1);
            count++;
        }

        return count;
    }
}
#endregion

#region 1 вариант - Рекурсия с возвратом - Слишком медленно
public class Solution_1349_1
{
    private const char EMPTY = '.';
    private const char STUDENT = '_';

    private char[][] _seats;
    private int _maxStudentCount = 0;
    private readonly List<Position> _emptyPositions = [];

    public int MaxStudents(char[][] seats)
    {
        _seats = seats;

        FillEmptyPositions();

        var currentStudentCount = 0;
        PlaceStudents(positionIndex: 0, ref currentStudentCount);

        return _maxStudentCount;
    }

    private void FillEmptyPositions()
    {
        for (var row = 0; row < _seats.Length; row++)
        {
            for (var column = 0; column < _seats[row].Length; column++)
            {
                if (_seats[row][column] == EMPTY)
                {
                    _emptyPositions.Add(new Position(row, column));
                }
            }
        }
    }

    private void PlaceStudents(int positionIndex, ref int currentStudentCount)
    {
        if (positionIndex >= _emptyPositions.Count)
        {
            return;
        }

        for (var i = positionIndex; i < _emptyPositions.Count; i++)
        {
            var possiblePositionCount = _emptyPositions.Count - i;
            var maxPossibleStudentCount = currentStudentCount + possiblePositionCount;

            if (maxPossibleStudentCount <= _maxStudentCount)
            {
                return;
            }

            var position = _emptyPositions[i];

            if (!CanPlaceStudent(position.X, position.Y))
            {
                continue;
            }

            _seats[position.X][position.Y] = STUDENT;
            currentStudentCount++;

            PlaceStudents(positionIndex: i + 1, ref currentStudentCount);

            _maxStudentCount = Math.Max(_maxStudentCount, currentStudentCount);
            _seats[position.X][position.Y] = EMPTY;
            currentStudentCount--;
        }
    }

    private bool CanPlaceStudent(int row, int column)
    {
        var left = column - 1;
        var right = column + 1;
        var front = row - 1;

        // слева
        if (left >= 0 && _seats[row][left] == STUDENT)
        {
            return false;
        }

        // справа
        if (right < _seats[row].Length && _seats[row][right] == STUDENT)
        {
            return false;
        }

        if (front >= 0)
        {
            // слева спереди
            if (left >= 0 && _seats[front][left] == STUDENT)
            {
                return false;
            }

            // справа спереди
            if (right < _seats[front].Length && _seats[front][right] == STUDENT)
            {
                return false;
            }
        }

        return true;
    }

    private record Position(int X, int Y);
}
#endregion
