// 2220. Minimum Bit Flips to Convert Number
public class Solution_2220
{
    public int MinBitFlips(int start, int goal)
    {
        var xor = start ^ goal;
        var flipCount = 0;

        while (xor > 0)
        {
            if (xor % 2 == 1)
            {
                flipCount++;
            }

            xor = xor >> 1;
        }

        return flipCount;
    }
}