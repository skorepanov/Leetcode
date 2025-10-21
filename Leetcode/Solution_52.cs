// 52. N-Queens II
public class Solution_52
{
    private const int Empty = 0;
    private const int Queen = 1;

    private int _n;
    private int[,] _board;

    public int TotalNQueens(int n)
    {
        _n = n;
        _board = new int[n, n];

        var solutionCount = 0;
        BacktrackNQueen(row: 0, ref solutionCount);

        return solutionCount;
    }

    private void BacktrackNQueen(int row, ref int solutionCount)
    {
        for (var column = 0; column < _n; column++)
        {
            if (IsUnderAttack(row, column))
            {
                continue;
            }

            PlaceQueen(row, column);

            if (row + 1 == _n)
            {
                solutionCount++;
            }
            else
            {
                BacktrackNQueen(row + 1, ref solutionCount);
            }

            RemoveQueen(row, column);
        }
    }

    private bool IsUnderAttack(int row, int column)
    {
        var diff = 0;

        while (diff < _n)
        {
            // влево
            if (column - diff >= 0
                && _board[row, column - diff] == Queen)
            {
                return true;
            }

            // вправо
            if (column + diff < _n
                && _board[row, column + diff] == Queen)
            {
                return true;
            }

            // вниз
            if (row + diff < _n
                && _board[row + diff, column] == Queen)
            {
                return true;
            }

            // вверх
            if (row - diff >= 0
                && _board[row - diff, column] == Queen)
            {
                return true;
            }

            // вниз вправо
            if (row + diff < _n && column + diff < _n
                && _board[row + diff, column + diff] == Queen)
            {
                return true;
            }

            // вниз влево
            if (row + diff < _n && column - diff >= 0
                && _board[row + diff, column - diff] == Queen)
            {
                return true;
            }

            // вверх вправо
            if (row - diff >= 0 && column + diff < _n
                && _board[row - diff, column + diff] == Queen)
            {
                return true;
            }

            // вверх влево
            if (row - diff >= 0 && column - diff >= 0
                && _board[row - diff, column - diff] == Queen)
            {
                return true;
            }

            diff++;
        }

        return false;
    }

    private void PlaceQueen(int row, int column)
    {
        _board[row, column] = Queen;
    }

    private void RemoveQueen(int row, int column)
    {
        _board[row, column] = Empty;
    }
}