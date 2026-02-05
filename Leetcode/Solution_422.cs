// 422. Valid Word Square
public class Solution_422
{
    public bool ValidWordSquare(IList<string> words)
    {
        var length = words.Count;

        if (words.Any(word => word.Length > length))
        {
            return false;
        }

        if (length == 1)
        {
            return true;
        }

        for (var row = 0; row < length; row++)
        {
            for (var column = row + 1; column < length; column++)
            {
                var symbol1 = words[row].Length > column
                    ? words[row][column]
                    : ' ';

                var symbol2 = words[column].Length > row
                    ? words[column][row]
                    : ' ';

                if (symbol1 != symbol2)
                {
                    return false;
                }
            }
        }

        return true;
    }
}