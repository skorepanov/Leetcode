// 1768. Merge Strings Alternately
using System.Text;

public class Solution_1768
{
    public string MergeAlternately(string word1, string word2)
    {
        var mergedString = new StringBuilder();

        var maxLength = Math.Max(word1.Length, word2.Length);

        for (var i = 0; i < maxLength; i++)
        {
            if (i < word1.Length)
            {
                mergedString.Append(word1[i]);
            }

            if (i < word2.Length)
            {
                mergedString.Append(word2[i]);
            }
        }

        return mergedString.ToString();
    }
}