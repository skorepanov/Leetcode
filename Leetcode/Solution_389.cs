// 389. Find the Difference
public class Solution_389
{
    public char FindTheDifference(string s, string t)
    {
        var symbols = new Dictionary<char, int>();

        foreach (var symbol in s)
        {
            if (!symbols.ContainsKey(symbol))
            {
                symbols.Add(symbol, value: 1);
            }
            else
            {
                symbols[symbol]++;
            }
        }

        foreach (var symbol in t)
        {
            if (!symbols.ContainsKey(symbol)
                || symbols[symbol] == 0)
            {
                return symbol;
            }

            symbols[symbol]--;
        }

        return ' ';
    }
}