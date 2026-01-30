// 58. Length of Last Word

#region Вариант 1 - Built-in funcitons
// Runtime 0 ms, Beats 100.00%
// Memory 39.99 MB, Beats 46.67%

public class Solution_58_1
{
    public int LengthOfLastWord(string s)
    {
        return s.TrimEnd().Split(separator: " ").Last().Length;
    }
}
#endregion

#region Вариант 2
// Runtime 0 ms, Beats 100.00%
// Memory 39.63 MB, Beats 84.46%

public class Solution_58_2
{
    public int LengthOfLastWord(string s)
    {
        var length = 0;

        for (var i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] != ' ')
            {
                length++;
                continue;
            }

            if (length != 0)
            {
                break;
            }
        }

        return length;
    }
}
#endregion
