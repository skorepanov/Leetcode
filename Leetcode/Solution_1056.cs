// 1056. Confusing Number
public class Solution_1056
{
    public bool ConfusingNumber(int n)
    {
        var tempN = n;
        var rotatedN = 0;

        var rotation = new Dictionary<int, int>
        {
            [0] = 0,
            [1] = 1,
            [6] = 9,
            [8] = 8,
            [9] = 6
        };

        while (tempN > 0)
        {
            var digit = tempN % 10;

            if (!rotation.TryGetValue(digit, out var rotatedDigit))
            {
                return false;
            }

            rotatedN = rotatedN * 10 + rotatedDigit;
            tempN /= 10;
        }

        return n != rotatedN;
    }
}