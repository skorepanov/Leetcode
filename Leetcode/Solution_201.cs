// 201. Bitwise AND of Numbers Range
public class Solution_201
{
    public int RangeBitwiseAnd(int left, int right)
    {
        var shift = 0;

        while (left < right)
        {
            left = left >> 1;
            right = right >> 1;
            shift++;
        }

        return right << shift;
    }
}