// 69. Sqrt(x)
public class Solution_69
{
    public int MySqrt(int x)
    {
        if (x < 2)
        {
            return x;
        }

        var left = 1;
        var right = x / 2;

        while (left <= right)
        {
            var middle = left + (right - left) / 2;

            if (middle <= x / middle
                && x / (middle + 1) < middle + 1)
            {
                return middle;
            }

            if (middle > x / middle)
            {
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }

        return 0;
    }
}
