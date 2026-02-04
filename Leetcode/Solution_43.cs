// 43. Multiply Strings
using System.Text;

public class Solution_43
{
    public string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0")
        {
            return "0";
        }

        if (num1 == "1")
        {
            return num2;
        }

        if (num2 == "1")
        {
            return num1;
        }

        var multiplyOfNums = "0";

        var num2Index = num2.Length - 1;

        while (num2Index >= 0)
        {
            var degree = num2.Length - num2Index - 1;
            var digit2 = int.Parse(num2[num2Index].ToString());

            var num1Index = num1.Length - 1;

            while (num1Index >= 0)
            {
                var digit1 = int.Parse(num1[num1Index].ToString());

                var multiply = digit1 * digit2 + new string('0', degree);

                multiplyOfNums = Sum(multiplyOfNums, multiply);

                degree++;
                num1Index--;
            }

            num2Index--;
        }

        return multiplyOfNums;
    }

    private string Sum(string num1, string num2)
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

        return ReverseNum(reversedSum.ToString());
    }

    private string ReverseNum(string num)
    {
        var sumAsCharArray = num.ToCharArray();
        Array.Reverse(sumAsCharArray);
        return new string(sumAsCharArray);
    }
}