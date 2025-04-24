// 202. Happy Number
namespace CurrentTask;

public class Solution_202
{
    public bool IsHappy(int n)
    {
        var consideredNumbers = new HashSet<int>();
        var currentSumOfDigitSquares = n;

        while (currentSumOfDigitSquares != 1)
        {
            if (consideredNumbers.Contains(currentSumOfDigitSquares))
            {
                return false;
            }

            consideredNumbers.Add(currentSumOfDigitSquares);

            currentSumOfDigitSquares = GetSumOfDigitSquares(currentSumOfDigitSquares);
        }

        return true;
    }

    private int GetSumOfDigitSquares(int n)
    {
        var digitSquaresSum = 0;
        var currentN = n;

        while (currentN > 0)
        {
            var digit = currentN % 10;
            digitSquaresSum += digit * digit;

            currentN /= 10;
        }

        return digitSquaresSum;
    }
}