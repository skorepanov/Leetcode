// 7. Reverse Integer
using System.Text;

public class Solution_7
{
    public int Reverse(int x)
    {
        var reversedX = ReverseNumber(x);

        if (x < 0)
        {
            return IsLowerThanBorder(reversedX, border: int.MinValue.ToString())
                ? int.Parse(reversedX)
                : 0;
        }

        return IsLowerThanBorder(reversedX, border: int.MaxValue.ToString())
            ? int.Parse(reversedX)
            : 0;
    }

    private string ReverseNumber(int x)
    {
        var reversedX = new StringBuilder();

        if (x < 0)
        {
            reversedX.Append('-');
        }

        var xAsString = x.ToString();
        var firstDigitIndex = x >= 0 ? 0 : 1;

        for (var i = xAsString.Length - 1; i >= firstDigitIndex; i--)
        {
            reversedX.Append(xAsString[i]);
        }

        return reversedX.ToString();
    }

    private bool IsLowerThanBorder(string value, string border)
    {
        if (value.Length < border.Length)
        {
            return true;
        }

        for (var i = 0; i < value.Length; i++)
        {
            if (value[i] > border[i])
            {
                return false;
            }

            if (value[i] < border[i])
            {
                return true;
            }
        }

        return true;
    }
}
