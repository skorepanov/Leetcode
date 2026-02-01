// 1275. Find Winner on a Tic Tac Toe Game
public class Solution_1275
{
    public string Tictactoe(int[][] moves)
    {
        var grid = new char[3, 3];

        var aChar = 'A';
        var bChar = 'B';

        var isA = true;

        foreach (var move in moves)
        {
            grid[move[0], move[1]] = isA ? aChar : bChar;
            isA = !isA;
        }

        if (IsRowFilled(aChar, grid)
            || IsColumnFilled(aChar, grid)
            || IsDiagonalFilled(aChar, grid))
        {
            return aChar.ToString();
        }

        if (IsRowFilled(bChar, grid)
            || IsColumnFilled(bChar, grid)
            || IsDiagonalFilled(bChar, grid))
        {
            return bChar.ToString();
        }

        return moves.Length == 9
            ? "Draw"
            : "Pending";
    }

    private bool IsRowFilled(char playerChar, char[,] grid)
    {
        for (var row = 0; row < 3; row++)
        {
            var isRowFilled = true;

            for (var column = 0; column < 3; column++)
            {
                if (grid[row, column] != playerChar)
                {
                    isRowFilled = false;
                    break;
                }
            }

            if (isRowFilled)
            {
                return true;
            }
        }

        return false;
    }

    private bool IsColumnFilled(char playerChar, char[,] grid)
    {
        for (var column = 0; column < 3; column++)
        {
            var isColumnFilled = true;

            for (var row = 0; row < 3; row++)
            {
                if (grid[row, column] != playerChar)
                {
                    isColumnFilled = false;
                    break;
                }
            }

            if (isColumnFilled)
            {
                return true;
            }
        }

        return false;
    }

    private bool IsDiagonalFilled(char playerChar, char[,] grid)
    {
        if (grid[1, 1] != playerChar)
        {
            return false;
        }

        if (grid[0, 0] == playerChar && grid[2, 2] == playerChar
         || grid[2, 0] == playerChar && grid[0, 2] == playerChar)
        {
            return true;
        }

        return false;
    }
}