// 344. Reverse String

#region Вариант 1 - Итеративно - Runtime 0 ms, Beats 100.00%
public class Solution_344_1
{
    public void ReverseString(char[] s)
    {
        var i = 0;
        var k = s.Length - 1;

        while (i < k)
        {
            (s[i], s[k]) = (s[k], s[i]);
            i++;
            k--;
        }
    }
}
#endregion

#region Вариант 2 - Рекурсивно - Runtime 0 ms, Beats 100.00%
public class Solution_344_2
{
    public void ReverseString(char[] s)
    {
        ReverseString(s, start: 0, end: s.Length - 1);
    }

    private void ReverseString(char[] s, int start, int end)
    {
        if (end <= start)
        {
            return;
        }

        (s[start], s[end]) = (s[end], s[start]);

        start++;
        end--;

        ReverseString(s, start, end);
    }
}
#endregion
