// 1071. Greatest Common Divisor of Strings
public class Solution_1071
{
    public string GcdOfStrings(string str1, string str2)
    {
        var maxPrefix = new ReadOnlySpan<char>();
        var prefixLength = 1;
        var minLength = Math.Min(str1.Length, str2.Length);

        while (prefixLength <= minLength)
        {
            var subString = str1.AsSpan(start: 0, length: prefixLength);

            if (IsDivider(str1, subString) && IsDivider(str2, subString))
            {
                maxPrefix = subString;
            }

            prefixLength++;
        }

        return maxPrefix.ToString();
    }

    private bool IsDivider(ReadOnlySpan<char> original, ReadOnlySpan<char> divider)
    {
        var index = 0;

        while (index + divider.Length <= original.Length)
        {
            var subString = original.Slice(start: index, length: divider.Length);

            if (!divider.SequenceEqual(subString))
            {
                return false;
            }

            index += divider.Length;
        }

        return index == original.Length;
    }
}