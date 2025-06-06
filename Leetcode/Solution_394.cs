// 394. Decode String

using System.Text;

public class Solution_394
{
    public string DecodeString(string s)
    {
        var stringBuilder = new StringBuilder();

        for (var i = 0; i < s.Length; i++)
        {
            // добавить префикс
            while (i < s.Length && char.IsLetter(s[i]))
            {
                stringBuilder.Append(s[i]);
                i++;
            }

            if (i == s.Length)
            {
                break;
            }

            // определить кол-во повторений
            var substringRepeatCountAsString = string.Empty;

            while (char.IsDigit(s[i]))
            {
                substringRepeatCountAsString += s[i];
                i++;
            }

            var substringRepeatCount = int.Parse(substringRepeatCountAsString);

            // определить повторяемую подстроку
            var substring = GetRepeatableSubstring(s, i);
            var decodedSubstring = DecodeString(substring);

            var decodedSubstrings = Enumerable
                .Repeat(decodedSubstring, substringRepeatCount)
                .ToArray();

            stringBuilder.Append(string.Concat(decodedSubstrings));

            i += substring.Length + 2;

            // определить постфикс
            while (i < s.Length && char.IsLetter(s[i]))
            {
                stringBuilder.Append(s[i]);
                i++;
            }

            i--;
        }

        return stringBuilder.ToString();
    }

    private string GetRepeatableSubstring(string s, int start)
    {
        var bracketCount = 0;

        var stringLength = 0;

        for (var i = start; i < s.Length; i++)
        {
            if (s[i] == '[')
            {
                bracketCount++;
            }
            else if (s[i] == ']')
            {
                bracketCount--;

                if (bracketCount == 0)
                {
                    break;
                }
            }

            stringLength++;
        }

        return s.Substring(start + 1, stringLength - 1);
    }
}