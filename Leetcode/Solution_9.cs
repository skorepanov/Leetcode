#region Вариант 2 - Runtime 1 ms, Beats 99.98%
public class Solution_9_2
{
    public bool IsPalindrome(int x)
    {
        if (x == 0)
        {
            return true;
        }

        if (x < 0 || x % 10 == 0)
        {
            return false;
        }

        var revertedX = 0;

        while (x > revertedX)
        {
            revertedX = revertedX * 10 + x % 10;
            x /= 10;
        }

        // Проверка x == revertedX / 10 нужна для чисел с нечётной длиной, н-р, 12321.
        // Для них можно не проверять центральную цифру.
        return x == revertedX || x == revertedX / 10;
    }
}
#endregion

#region Вариант 1 - Runtime 4 ms, Beats 25.30%
public class Solution_9_1
{
    public bool IsPalindrome(int x)
    {
        if (x == 0)
        {
            return true;
        }

        if (x < 0 || x % 10 == 0)
        {
            return false;
        }

        var tempX = x;
        var totalLength = 0;

        while (tempX > 0)
        {
            totalLength++;
            tempX /= 10;
        }

        if (totalLength == 1)
        {
            return true;
        }

        var currLength = totalLength;
        tempX = x;

        while (currLength > totalLength / 2)
        {
            var right = tempX % 10;
            var left = (int)(x / Math.Pow(10, currLength - 1)) % 10;

            if (left != right)
            {
                return false;
            }

            currLength--;
            tempX /= 10;
        }

        return true;
    }
}
#endregion