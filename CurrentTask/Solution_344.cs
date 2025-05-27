// 344. Reverse String
public class Solution_344
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