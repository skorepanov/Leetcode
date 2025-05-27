// 249. Group Shifted Strings
public class Solution_249
{
    public IList<IList<string>> GroupStrings(string[] strings)
    {
        var groupedStrings = new Dictionary<string, List<string>>();

        foreach (var str in strings)
        {
            var baseString = ToBaseString(str);

            if (!groupedStrings.ContainsKey(baseString))
            {
                groupedStrings.Add(baseString, []);
            }

            groupedStrings[baseString].Add(str);
        }

        return new List<IList<string>>(groupedStrings.Values);
    }

    private string ToBaseString(string str)
    {
        var baseString = str.ToCharArray();

        while (baseString[0] != 'a')
        {
            for (var i = 0; i < baseString.Length; i++)
            {
                if (baseString[i] == 'z')
                {
                    baseString[i] = 'a';
                }
                else
                {
                    baseString[i]++;
                }
            }
        }

        return new string(baseString);
    }
}