// 392. Is Subsequence
public class Solution_392
{
    public bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0)
        {
            return true;
        }

        var sIndex = 0;

        for (var tIndex = 0; tIndex < t.Length; tIndex++)
        {
            if (t[tIndex] == s[sIndex])
            {
                sIndex++;

                if (sIndex == s.Length)
                {
                    return true;
                }
            }
        }

        return false;
    }
}