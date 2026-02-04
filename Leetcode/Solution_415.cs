// 415. Add Strings
using System.Text;

public class Solution_415
{
    public string AddStrings(string num1, string num2)
    {
        if (num1 == "0")
        {
            return num2;
        }

        if (num2 == "0")
        {
            return num1;
        }

        var reversedSum = new StringBuilder();
        var carry = 0;

        var num1Index = num1.Length - 1;
        var num2Index = num2.Length - 1;

        while (num1Index >= 0 || num2Index >= 0)
        {
            var digit1 = num1Index >= 0
                ? int.Parse(num1[num1Index].ToString())
                : 0;

            var digit2 = num2Index >= 0
                ? int.Parse(num2[num2Index].ToString())
                : 0;

            var sum = (digit1 + digit2 + carry) % 10;
            carry = (digit1 + digit2 + carry) / 10;

            reversedSum.Append(sum);

            num1Index--;
            num2Index--;
        }

        if (carry > 0)
        {
            reversedSum.Append(carry);
        }

        var sumAsCharArray = reversedSum.ToString().ToCharArray();
        Array.Reverse(sumAsCharArray);
        return new string(sumAsCharArray);
    }
}