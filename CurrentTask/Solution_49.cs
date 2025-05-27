// 49. Group Anagrams
public class Solution_49
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var groupedStrings = new Dictionary<string, List<string>>();

        foreach (var str in strs)
        {
            var sortedSymbols = str.Order().ToArray();
            var sortedString = new string(sortedSymbols);

            if (!groupedStrings.ContainsKey(sortedString))
            {
                groupedStrings.Add(sortedString, []);
            }

            groupedStrings[sortedString].Add(str);
        }

        return new List<IList<string>>(groupedStrings.Values);
    }
}