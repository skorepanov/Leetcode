// 65. Valid Number
public class Solution_65
{
    public bool IsNumber(string s)
    {
        var isPositiveNumber = (bool?)null;
        var isDecimalNumber = false;
        var hasNumber = false;

        var exponentIndex = (int?)null;

        for (var i = 0; i < s.Length; i++)
        {
            var symbol = s[i];

            if (symbol is '+' or '-')
            {
                if (isPositiveNumber is not null || hasNumber || isDecimalNumber)
                {
                    return false;
                }

                isPositiveNumber = symbol == '+';
                continue;
            }

            if (char.IsDigit(symbol))
            {
                hasNumber = true;
                continue;
            }

            if (symbol == '.')
            {
                if (isDecimalNumber)
                {
                    return false;
                }

                isDecimalNumber = true;
                continue;
            }

            if (symbol is 'e' or 'E')
            {
                exponentIndex = i + 1;
                break;
            }

            if (char.IsLetter(symbol))
            {
                return false;
            }
        }

        if (!hasNumber)
        {
            return false;
        }

        if (exponentIndex is null)
        {
            return true;
        }

        var isPositiveExponent = (bool?)null;
        var hasExponent = false;

        for (var i = exponentIndex.Value; i < s.Length; i++)
        {
            var symbol = s[i];

            if (symbol is '+' or '-')
            {
                if (isPositiveExponent is not null || hasExponent)
                {
                    return false;
                }

                isPositiveExponent = symbol == '+';
                continue;
            }

            if (symbol == '.' || char.IsLetter(symbol))
            {
                return false;
            }

            if (char.IsDigit(symbol))
            {
                hasExponent = true;
            }
        }

        return hasExponent;
    }
}