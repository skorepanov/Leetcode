// 3. Longest Substring Without Repeating Characters
namespace CurrentTask;

#region Вариант 1 (мой) - Runtime 79 ms, Beats 12.80%
public class Solution_3_1
{
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        var lengthOfLongestSubstring = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var usedSymbols = new HashSet<char>();
            usedSymbols.Add(s[i]);

            for (var j = i + 1; j < s.Length; j++)
            {
                if (usedSymbols.Contains(s[j]))
                {
                    break;
                }

                usedSymbols.Add(s[j]);
            }

            lengthOfLongestSubstring = Math.Max(lengthOfLongestSubstring, usedSymbols.Count);
        }

        return lengthOfLongestSubstring;
    }
}
#endregion

#region Вариант 2 (мой) - Runtime 102 ms, Beats 8.11%
public class Solution_3_2
{
    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        var lengthOfLongestSubstring = 0;

        for (var i = 0; i < s.Length; i++)
        {
            if (s.Length - lengthOfLongestSubstring < i)
            {
                break;
            }

            var usedSymbols = new HashSet<char>();
            usedSymbols.Add(s[i]);

            for (var j = i + 1; j < s.Length; j++)
            {
                if (usedSymbols.Contains(s[j]))
                {
                    break;
                }

                usedSymbols.Add(s[j]);
            }

            lengthOfLongestSubstring = Math.Max(lengthOfLongestSubstring, usedSymbols.Count);
        }

        return lengthOfLongestSubstring;
    }
}
#endregion

#region Вариант 3 (не мой) - Runtime 6 ms, Beats 58.99%
public class Solution_3_3
{
    public int LengthOfLongestSubstring(string s)
    {
        var symbolToPositionPairs = new Dictionary<char, int>();
        var start = 0;
        var length = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var symbol = s[i];

            if (symbolToPositionPairs.ContainsKey(symbol)
             && symbolToPositionPairs[symbol] >= start)
            {
                start = symbolToPositionPairs[symbol] + 1;
            }

            length = Math.Max(length, i - start + 1);
            symbolToPositionPairs[symbol] = i;
        }

        return length;
    }
}
#endregion