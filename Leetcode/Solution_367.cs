// 367. Valid Perfect Square
public class Solution_367
{
    public bool IsPerfectSquare(int num)
    {
        if (num == 1)
        {
            return true;
        }

        var left = 1;
        var right = num / 2;

        while (left <= right)
        {
            var middle = left + (right - left) / 2;
            var square = (long)middle * middle;

            if (square == num)
            {
                return true;
            }

            if (square < num)
            {
                left = middle + 1;
            }
            else
            {
                right = middle - 1;
            }
        }

        return false;
    }
}