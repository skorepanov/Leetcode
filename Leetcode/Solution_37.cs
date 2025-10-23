// 37. Sudoku Solver
public class Solution_37
{
    private const char EMPTY = '.';
    private char[][] _board;
    private readonly List<Position> _emptyPositions = [];

    public void SolveSudoku(char[][] board)
    {
        _board = board;
        FillEmptyPositions();
        SolveSudoku();
    }

    private bool SolveSudoku()
    {
        var emptyPosition = _emptyPositions
            .FirstOrDefault(p => _board[p.X][p.Y] == EMPTY);

        if (emptyPosition is null)
        {
            return true;
        }

        var possibleNumbers = GetPossibleNumbersForPosition(emptyPosition);

        foreach (var number in possibleNumbers)
        {
            _board[emptyPosition.X][emptyPosition.Y] = number;

            if (SolveSudoku())
            {
                return true;
            }

            _board[emptyPosition.X][emptyPosition.Y] = EMPTY;
        }

        return false;
    }

    private void FillEmptyPositions()
    {
        for (var row = 0; row < _board.Length; row++)
        {
            for (var column = 0; column < _board[row].Length; column++)
            {
                if (_board[row][column] == EMPTY)
                {
                    _emptyPositions.Add(new Position(row, column));
                }
            }
        }
    }

    private List<char> GetPossibleNumbersForPosition(Position position)
    {
        List<char> numbers = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];

        for (var row = 0; row < _board.Length; row++)
        {
            numbers.Remove(_board[row][position.Y]);
        }

        for (var column = 0; column < _board[position.X].Length; column++)
        {
            numbers.Remove(_board[position.X][column]);
        }

        var rowBlock = position.X / 3 * 3;
        var columnBlock = position.Y / 3 * 3;

        for (var row = 0; row < 3; row++)
        {
            for (var column = 0; column < 3; column++)
            {
                numbers.Remove(_board[row + rowBlock][column + columnBlock]);
            }
        }

        return numbers;
    }

    private record Position(int X, int Y);
}