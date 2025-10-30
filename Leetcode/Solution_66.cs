// 66. Plus One
public class Solution_66
{
    public int[] PlusOne(int[] digits)
    {
        digits[^1]++;

        var i = digits.Length - 1;

        while (i >= 0)
        {
            if (digits[i] >= 10 && i != 0)
            {
                digits[i] -= 10;
                digits[i - 1]++;
            }

            i--;
        }

        if (digits[0] == 10)
        {
            var newDigits = new int[digits.Length + 1];
            newDigits[0] = 1;
            return newDigits;
        }

        return digits;
    }
}