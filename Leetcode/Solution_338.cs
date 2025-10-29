// 338. Counting Bits
public class Solution_338
{
    public int[] CountBits(int n)
    {
        var bits = new int[n + 1];

        for (var i = 1; i < bits.Length; i++)
        {
            var index = i & (i - 1);
            bits[i] = bits[index] + 1;
        }

        return bits;
    }
}