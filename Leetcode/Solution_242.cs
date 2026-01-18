// 242. Valid Anagram
public class Solution_242
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var symbols = new Dictionary<char, int>();

        foreach (var symbol in s)
        {
            if (!symbols.ContainsKey(symbol))
            {
                symbols.Add(symbol, 0);
            }

            symbols[symbol]++;
        }

        foreach (var symbol in t)
        {
            if (!symbols.ContainsKey(symbol) || symbols[symbol] <= 0)
            {
                return false;
            }

            symbols[symbol]--;
        }

        return true;
    }
}