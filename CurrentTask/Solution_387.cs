// 387. First Unique Character in a String
namespace CurrentTask;

#region Вариант 1 - Runtime 105 ms, Beats 5.02%
public class Solution_387_1
{
    public int FirstUniqChar(string s)
    {
        var symbolToIndexPairs = new Dictionary<char, (int Index, bool HasDuplicate)>();

        for (var i = 0; i < s.Length; i++)
        {
            var symbol = s[i];

            if (!symbolToIndexPairs.ContainsKey(symbol))
            {
                symbolToIndexPairs.Add(symbol, (i, HasDuplicate: false));
            }
            else
            {
                symbolToIndexPairs[symbol] = (i, HasDuplicate: true);
            }
        }

        var min = int.MaxValue;

        foreach (var pair in symbolToIndexPairs)
        {
            if (!pair.Value.HasDuplicate && min > pair.Value.Index)
            {
                min = pair.Value.Index;
            }
        }

        return min == int.MaxValue ? -1 : min;
    }
}
#endregion

#region Вариант 2 - Runtime 12 ms, Beats 77.88%
public class Solution_387_2
{
    public int FirstUniqChar(string s)
    {
        var symbolToIndexPairs = new Dictionary<char, int>();
        var nonDuplicateSymbols = new HashSet<char>();

        for (var i = 0; i < s.Length; i++)
        {
            var symbol = s[i];

            if (!symbolToIndexPairs.ContainsKey(symbol))
            {
                symbolToIndexPairs.Add(symbol, i);
                nonDuplicateSymbols.Add(symbol);
            }
            else
            {
                nonDuplicateSymbols.Remove(symbol);
            }
        }

        var min = int.MaxValue;

        foreach (var symbol in nonDuplicateSymbols)
        {
            var index = symbolToIndexPairs[symbol];

            if (min > index)
            {
                min = index;
            }
        }

        return min == int.MaxValue ? -1 : min;
    }
}
#endregion