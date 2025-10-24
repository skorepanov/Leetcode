// 22. Generate Parentheses
using System.Text;

public class Solution_22
{
    public IList<string> GenerateParenthesis(int n)
    {
        StringBuilder currentString = new StringBuilder("(");
        var parenthesisCount = 1;
        var parenthesis = new List<string>();

        GenerateParenthesis(n, ref currentString, ref parenthesisCount, parenthesis);

        return parenthesis;
    }

    private void GenerateParenthesis(
        int n,
        ref StringBuilder currentString,
        ref int parenthesisCount,
        IList<string> allParenthesis)
    {
        char[] parenthesis = ['(', ')'];

        foreach (var bracket in parenthesis)
        {
            var parenthesisModificator = bracket == '(' ? 1 : -1;
            parenthesisCount += parenthesisModificator;

            if (parenthesisCount < 0)
            {
                parenthesisCount++;
                continue;
            }

            currentString.Append(bracket);

            if (currentString.Length == n * 2)
            {
                if (parenthesisCount == 0)
                {
                    allParenthesis.Add(currentString.ToString());
                }
            }
            else
            {
                GenerateParenthesis(
                    n, ref currentString, ref parenthesisCount, allParenthesis);
            }

            currentString.Remove(currentString.Length - 1, length: 1);
            parenthesisCount -= parenthesisModificator;
        }
    }
}