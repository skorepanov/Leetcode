// 371. Sum of Two Integers
public class Solution_371
{
    public int GetSum(int a, int b)
    {
        while (b != 0)
        {
            var answer = a ^ b;
            var carry = (a & b) << 1;
            a = answer;
            b = carry;
        }

        return a;
    }
}