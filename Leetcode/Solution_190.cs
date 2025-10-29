// 190. Reverse Bits

#region Вариант 1 - Без битовых операций - Runtime 32 ms, Beats 12.85%
public class Solution_190_1
{
    public int ReverseBits(int n)
    {
        var reversedNumBase2 = new int[32];
        var position = 0;

        while (n > 0)
        {
            reversedNumBase2[position] = n % 2;
            position++;
            n /= 2;
        }

        var reversedNumBase10 = 0;
        var degree = -1;

        for (var i = reversedNumBase2.Length - 1; i >= 0; i--)
        {
            degree++;

            if (reversedNumBase2[i] == 0)
            {
                continue;
            }

            reversedNumBase10 += (int)Math.Pow(2, degree);
        }

        return reversedNumBase10;
    }
}
#endregion

#region Вариант 2 - С битовыми операциями - Runtime 23 ms, Beats 74.59%
public class Solution_190_2
{
    public int ReverseBits(int n)
    {
        var reversedNum = 0;
        var power = 31;

        while (n != 0)
        {
            reversedNum += (n & 1) << power;
            n = n >>> 1;
            power--;
        }

        return reversedNum;
    }
}
#endregion
