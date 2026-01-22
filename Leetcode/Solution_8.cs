// 8. String to Integer (atoi)
public class Solution_8
{
    public int MyAtoi(string s)
    {
        var isPositive = (bool?)null;
        var leftIndex = -1;

        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '.' || char.IsLetter(s[i]))
            {
                return 0;
            }

            if (isPositive is not null && !char.IsDigit(s[i]))
            {
                return 0;
            }

            if (s[i] == '+')
            {
                if (isPositive is not null)
                {
                    return 0;
                }

                isPositive = true;
                continue;
            }

            if (s[i] == '-')
            {
                if (isPositive is not null)
                {
                    return 0;
                }

                isPositive = false;
                continue;
            }

            if (char.IsDigit(s[i]))
            {
                leftIndex = i;
                break;
            }
        }

        if (leftIndex == -1)
        {
            return 0;
        }

        if (isPositive is null)
        {
            isPositive = true;
        }

        var rightIndex = s.Length - 1;

        for (var i = leftIndex + 1; i < s.Length; i++)
        {
            if (!char.IsDigit(s[i]))
            {
                rightIndex = i - 1;
                break;
            }
        }

        var numberAsString = s
            .Substring(
                startIndex: leftIndex,
                length: rightIndex - leftIndex + 1)
            .TrimStart(trimChar: '0');

        if (numberAsString == string.Empty)
        {
            return 0;
        }

        if (isPositive is true)
        {
            return IsLowerThanBorder(numberAsString, border: int.MaxValue.ToString())
                ? int.Parse(numberAsString)
                : int.MaxValue;
        }

        return IsLowerThanBorder($"-{numberAsString}", border: int.MinValue.ToString())
            ? int.Parse($"-{numberAsString}")
            : int.MinValue;
    }

    private bool IsLowerThanBorder(string value, string border)
    {
        if (value.Length < border.Length)
        {
            return true;
        }

        if (value.Length > border.Length)
        {
            return false;
        }

        for (var i = 0; i < value.Length; i++)
        {
            if (value[i] > border[i])
            {
                return false;
            }

            if (value[i] < border[i])
            {
                return true;
            }
        }

        return true;
    }
}