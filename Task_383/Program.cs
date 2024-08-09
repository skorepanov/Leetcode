public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var symbols = new Dictionary<char, int>();

        foreach (var symbol in magazine)
        {
            if (symbols.ContainsKey(symbol))
            {
                symbols[symbol]++;
            }
            else
            {
                symbols.Add(symbol, 1);
            }
        }

        foreach (var symbol in ransomNote)
        {
            if (symbols.ContainsKey(symbol) && symbols[symbol] > 0)
            {
                symbols[symbol]--;
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}