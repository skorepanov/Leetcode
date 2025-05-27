// 67. Add Binary
public class Solution_67
{
    public string AddBinary(string a, string b)
    {
        if (a == "0")
        {
            return b;
        }

        if (b == "0")
        {
            return a;
        }

        var maxLength = Math.Max(a.Length, b.Length);
        var sum = Enumerable.Repeat('0', maxLength + 1).ToArray();

        var aIndex = a.Length - 1;
        var bIndex = b.Length - 1;

        var sumIndex = sum.Length - 1;
        var overflow = false;

        for (var i = maxLength; i >= 0; i--)
        {
            var aVal = 0 <= aIndex && aIndex < a.Length ? a[aIndex] : '0';
            var bVal = 0 <= bIndex && bIndex < b.Length ? b[bIndex] : '0';

            if (overflow)
            {
                if (aVal == '0' && bVal == '0')
                {
                    // 0+0
                    sum[sumIndex] = '1';
                    overflow = false;
                }
                else if (aVal == '1' && bVal == '0'
                      || aVal == '0' && bVal == '1')
                {
                    // 0+1 or 1+0
                    sum[sumIndex] = '0';
                }
                else
                {
                    // 1+1
                    sum[sumIndex] = '1';
                }
            }
            else
            {
                if (aVal == '0')
                {
                    // 0+x
                    sum[sumIndex] = bVal;
                }
                else if (bVal == '0')
                {
                    // x+0
                    sum[sumIndex] = aVal;
                }
                else
                {
                    // 1+1
                    sum[sumIndex] = '0';
                    overflow = true;
                }
            }

            aIndex--;
            bIndex--;
            sumIndex--;
        }

        if (overflow)
        {
            sum[0] = '1';
        }

        if (sum[0] == '0')
        {
            sum = sum.Skip(1).ToArray();
        }

        return new string(sum);
    }
}