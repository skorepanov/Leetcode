namespace CurrentTask;

#region Вариант 1 (мой) - Runtime 3 ms, Beats 58.21%
public class Solution_36_1
{
    public bool IsValidSudoku(char[][] board)
    {
        return IsValidRows(board)
            && IsValidColumns(board)
            && IsValidSquares(board);
    }

    private bool IsValidRows(char[][] board)
    {
        return board.All(row => IsValidArray(row));
    }

    private bool IsValidColumns(char[][] board)
    {
        var columnIndex = 0;

        while (columnIndex < board[0].Length)
        {
            var column = new char[board.Length];

            for (var rowIndex = 0; rowIndex < board.Length; rowIndex++)
            {
                column[rowIndex] = board[rowIndex][columnIndex];
            }

            if (!IsValidArray(column))
            {
                return false;
            }

            columnIndex++;
        }

        return true;
    }

    private bool IsValidSquares(char[][] board)
    {
        var rowIndex = 0;

        while (rowIndex < board.Length)
        {
            var columnIndex = 0;

            while (columnIndex < board[rowIndex].Length)
            {
                char[] square =
                [
                    board[rowIndex][columnIndex],
                    board[rowIndex][columnIndex + 1],
                    board[rowIndex][columnIndex + 2],
                    board[rowIndex + 1][columnIndex],
                    board[rowIndex + 1][columnIndex + 1],
                    board[rowIndex + 1][columnIndex + 2],
                    board[rowIndex + 2][columnIndex],
                    board[rowIndex + 2][columnIndex + 1],
                    board[rowIndex + 2][columnIndex + 2]
                ];

                if (!IsValidArray(square))
                {
                    return false;
                }

                columnIndex += 3;
            }

            rowIndex += 3;
        }

        return true;
    }

    private bool IsValidArray(char[] row)
    {
        var symbols = new HashSet<char>();

        foreach (var symbol in row)
        {
            if (symbol == '.')
            {
                continue;
            }

            if (symbols.Contains(symbol))
            {
                return false;
            }

            symbols.Add(symbol);
        }

        return true;
    }
}
#endregion

#region Вариант 2 (не мой) - Runtime 4 ms, Beats 43.38%
public class Solution_36_2
{
    public bool IsValidSudoku(char[][] board)
    {
        const int N = 9;

        var seen = new HashSet<string>();

        for (var rowIndex = 0; rowIndex < N; rowIndex++)
        {
            for (var columnIndex = 0; columnIndex < N; columnIndex++)
            {
                var number = board[rowIndex][columnIndex];

                if (number == '.')
                {
                    continue;
                }

                if (!seen.Add($"{number} in row {rowIndex}")
                 || !seen.Add($"{number} in column {columnIndex}")
                 || !seen.Add($"{number} in block {rowIndex / 3}-{columnIndex / 3}"))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
#endregion