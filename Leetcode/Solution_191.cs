// 191. Number of 1 Bits
public class Solution_191
{
    public int HammingWeight(int n)
    {
        var countOf1 = 0;

        while (n > 0)
        {
            if (n % 2 == 1)
            {
                countOf1++;
            }

            n /= 2;
        }

        return countOf1;
    }
}