// 459. Repeated Substring Pattern
public class Solution_459
{
    public bool RepeatedSubstringPattern(string s)
    {
        for (var i = 0; i < s.Length / 2; i++)
        {
            var substring = s.Substring(startIndex: 0, length: i + 1);

            var k = substring.Length;

            while (k + substring.Length <= s.Length)
            {
                if (substring != s.Substring(startIndex: k, length: substring.Length))
                {
                    break;
                }

                k += substring.Length;
            }

            if (k >= s.Length)
            {
                return true;
            }
        }

        return false;
    }
}