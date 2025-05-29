// 20. Valid Parentheses
public class Solution
{
    public bool IsValid(string s)
    {
        var inputBrackets = new Stack<char>();

        var closeToOpenBrackets = new Dictionary<char, char>()
        {
             [')'] = '(',
             ['}'] = '{',
             [']'] = '['
        };

        foreach (var bracket in s)
        {
            if (closeToOpenBrackets.ContainsValue(bracket))
            {
                inputBrackets.Push(bracket);
                continue;
            }

            var top = inputBrackets.Count == 0 ? '#' : inputBrackets.Pop();

            if (top != closeToOpenBrackets[bracket])
            {
                return false;
            }
        }

        return inputBrackets.Count == 0;
    }
}
