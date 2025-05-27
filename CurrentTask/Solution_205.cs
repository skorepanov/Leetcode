// 205. Isomorphic Strings
#region Вариант 1 - Runtime 12 ms, Beats 43.87%
public class Solution_205_1
{
    public bool IsIsomorphic(string s, string t)
    {
        return CheckIsomorphic(s, t) && CheckIsomorphic(t, s);
    }

    private bool CheckIsomorphic(string s1, string s2)
    {
        var symbols = new Dictionary<char, char>();

        for (var i = 0; i < s1.Length; i++)
        {
            var symbol1 = s1[i];
            var symbol2 = s2[i];

            if (!symbols.ContainsKey(symbol1))
            {
                symbols.Add(symbol1, symbol2);
            }
            else
            {
                if (symbols[symbol1] != symbol2)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
#endregion

#region Вариант 2 - Runtime 9 ms, Beats 74.66%
public class Solution_205_2
{
    public bool IsIsomorphic(string s, string t)
    {
        var symbols = new Dictionary<char, char>();
        var secondSymbols = new HashSet<char>();

        for (var i = 0; i < s.Length; i++)
        {
            var symbol1 = s[i];
            var symbol2 = t[i];

            if (!symbols.ContainsKey(symbol1))
            {
                if (secondSymbols.Contains(symbol2))
                {
                    return false;
                }

                symbols.Add(symbol1, symbol2);
                secondSymbols.Add(symbol2);
            }
            else
            {
                if (symbols[symbol1] != symbol2)
                {
                    return false;
                }
            }
        }

        return true;
    }
}
#endregion