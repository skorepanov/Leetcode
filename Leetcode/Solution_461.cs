// 461. Hamming Distance
public class Solution_461
{
    public int HammingDistance(int x, int y)
    {
        var xor = x ^ y;
        var distance = 0;

        while (xor > 0)
        {
            if (xor % 2 == 1)
            {
                distance++;
            }

            xor = xor >> 1;
        }

        return distance;
    }
}