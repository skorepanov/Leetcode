// 345. Reverse Vowels of a String
using System.Text;

public class Solution
{
    public string ReverseVowels(string s)
    {
        var vovels = new HashSet<char>
        {
            'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U'
        };

        var reversedString = new StringBuilder();

        var right = s.Length;

        for (var left = 0; left < s.Length; left++)
        {
            if (!vovels.Contains(s[left]))
            {
                reversedString.Append(s[left]);
                continue;
            }

            right--;

            while (right >= 0 && !vovels.Contains(s[right]))
            {
                right--;
            }

            if (right >= 0)
            {
                reversedString.Append(s[right]);
            }
        }

        return reversedString.ToString();
    }
}