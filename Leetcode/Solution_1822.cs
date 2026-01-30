// 1822. Sign of the Product of an Array
public class Solution_1822
{
    public int ArraySign(int[] nums)
    {
        var isPositive = true;

        foreach (var num in nums)
        {
            switch (num)
            {
                case 0:
                    return 0;
                case < 0:
                    isPositive = !isPositive;
                    break;
            }
        }

        return isPositive ? 1 : -1;
    }
}