// 326. Power of Three
public class Solution_326
{
    public bool IsPowerOfThree(int n)
    {
        if (n == 0)
        {
            return false;
        }

        while (n % 3 == 0)
        {
            n /= 3;
        }

        return n == 1;
    }
}